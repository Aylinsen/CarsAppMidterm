using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Owner
    {
        public int id {  get; set; }

        [Required]
        [StringLength(60)]
        public string name { get; set; }


        [Required]
        [StringLength(60)]
        public string surName { get; set; }

        public List<CarOwner> CarOwners { get; set; } = new List<CarOwner>();
    }
}
