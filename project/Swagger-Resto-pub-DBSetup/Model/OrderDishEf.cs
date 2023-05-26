using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swagger_Resto_pub_DBSetup.Model
{
    public class OrderDishEf
    {
        public int OrderId { get; set; }
        public OrderEf Order { get; set; }

        public int DishId { get; set; }
        public DishEf Dish { get; set; }
    }
}
