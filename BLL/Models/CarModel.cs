using BLL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CarModel
    {
        public Car record { get; set; }
        public string Brand => record.Brand;

        [DisplayName("Car_situation")]

        public string IsDamaged => record.IsDamaged ? "Demaged" : "Solid";

        public string ModelYear => record.modelYear.HasValue
            ? record.modelYear.Value.Year.ToString() 
            : "N/A"; public string TypeCar => record.TypeCar != null ? record.TypeCar.Name : "No Type Assigned";

        public int CarTypeId { get; set; }


    }
}
