using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swagger_Resto_pub_DBSetup.Model
{
    public class OrderEf
    {
       [Key]
        public int Id { get; set; }

        public Guid ReferenceCode { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime? PaymentDateTime { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public ClientEf Client { get; set; }

        public List<OrderDishEf> OrderDishes { get; set; }
    }
}
