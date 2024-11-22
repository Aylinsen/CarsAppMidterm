using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
namespace BLL.Services
{

    public interface ITypeService
    {
        public IQueryable<TypeCarModel> Query();

        public ServiceBase Create(TypeCar record);
        public ServiceBase Update(TypeCar record);

        public ServiceBase Delete(int id);

    }
    public class TypeService : ServiceBase,ITypeService
    {
        public TypeService(Db db) : base(db)
        {

        }

        public ServiceBase Create(TypeCar record)
        {
            if (_db.TypeCars.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Car type name with the same name exists");
            record.Name= record.Name?.Trim();
            _db.TypeCars.Add(record);
            _db.SaveChanges();
            return Succsess("car type name created :)");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.TypeCars.Include(s => s.Cars).SingleOrDefault(s => s.Id == id);
            if (entity == null)
                return Error(" can not found");
            if (entity.Cars.Any())
                return Error("Car has relational recors");
            _db.TypeCars.Remove(entity);
            _db.SaveChanges() ;
            return Succsess("cars deleted ");
        }

        public IQueryable<TypeCarModel> Query()
        {
            return _db.TypeCars.OrderBy(s => s.Name).Select(s => new TypeCarModel() { Record = s });
        }

        public ServiceBase Update(TypeCar record)
        {
            if (_db.TypeCars.Any(s=>s.Id !=record.Id && s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Car type name with the same name exists");
            var entity = _db.TypeCars.SingleOrDefault(s=>s.Id == record.Id);
            if (entity == null)
                return Error(" cant found");
            entity.Name = record.Name?.Trim();
            _db.TypeCars.Update(entity);
            _db.SaveChanges();
            return Succsess("car type updated :)");
          
        }
    }
}
