using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DAL
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]

      
        public string Brand { get; set; }


        public bool IsDamaged { get; set; } 

        public DateTime? modelYear {  get; set; }    

       
        public int CarTypeId { get; set; }

        public TypeCar TypeCar { get; set; }  // navigational 

        public List<CarOwner> CarOwners {  get; set; } = new List<CarOwner>();

    }
}
