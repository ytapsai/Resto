using System;
using System.ComponentModel.DataAnnotations;

namespace Swagger_Resto_pub_DBSetup.Model
{
    public class DishEf
    {
        [Key]
        public int Id { get; set; }

        public Guid ReferenceCode { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }

        public List<OrderDishEf> OrderDishes { get; set; }
    }
}
