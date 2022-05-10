using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Thrifty.Areas.Identity.Data;

namespace Thrifty.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        public int pId { get; set; }
        public virtual Products Product{get; set;}

        [Required]
        public ThriftyUser User { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        [Required]
        public int TotalQuantity{ get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TotalPrice { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string OrderStatus { get; set; }
    }
}
