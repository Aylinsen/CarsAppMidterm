using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CarServices : ServiceBase, IService<Car, CarModel>
    {
        public CarServices(Db db) : base(db)
        {
        
        
        
        }

        public ServiceBase Create(Car record)
        {
            if (_db.Cars.Any(c => c.Brand.ToLower() == record.Brand.ToLower().Trim() && c.IsDamaged == record.IsDamaged && c.modelYear == record.modelYear))
                 
              return Error("same car exists !");
            
            record.Brand=record.Brand?.ToLower();    
            
            _db.Cars.Add(record);
            _db.SaveChanges();
            return Succsess(" new car created :)");

        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Cars.Include(c => c.CarOwners).SingleOrDefault(c => c.Id == id);

            if (entity == null)
            {
                return Error("The car cannot be found.");
            }

            _db.CarOwners.RemoveRange(entity.CarOwners);

            _db.Cars.Remove(entity);

            _db.SaveChanges();

            return Succsess("The car has been deleted successfully.");
        }

        public IQueryable<CarModel> Query()
        {
            
            return _db.Cars
        .Include(c => c.TypeCar) // Ensure TypeCar is loaded
        .Select(c => new CarModel() { record = c });
        }

        public ServiceBase Update(Car record)
        {
            if (_db.Cars.Any(c => c.CarTypeId != record.CarTypeId && c.Brand.ToLower() == record.Brand.ToLower().Trim() && c.modelYear == record.modelYear))

              return Error("same car exists !");

            record.Brand = record.Brand?.ToLower();

            _db.Cars.Update(record);
            _db.SaveChanges();
            return Succsess(" new car updated :)");
        }
    }
}
