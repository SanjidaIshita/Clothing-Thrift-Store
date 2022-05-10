using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thrifty.Data
{
    public class Products
    {
        public Products()
        {
            pPrice = 250;
            pQuantity = 1;
        }

        [Key]
        public int pId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string pName { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string pSection { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string pType { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string pFabric { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string pSize { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string pColor { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string pFashion { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string pCondition { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal pPrice { get; set; }

        public string pImage { get; set; }

        [Required]
        public int pQuantity { get; set; }

        public DateTime? pCreatedOn { get; set; }
    }
}

