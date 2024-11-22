using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class CarOwner
    {
        public int Id {  get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public  Owner Owner  { get; set; }  

    }
}
