using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class TypeCar
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]

        public string Name { get; set; }

        public List<TypeCar> Cars { get; set; } = new List<TypeCar>();  
    }
}