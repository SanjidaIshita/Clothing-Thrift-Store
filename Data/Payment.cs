using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thrifty.Data
{
    public class Payment
    {
        public Payment()
        {
            PaymentStatus = "Processing";            
        }

        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(11)")]
        public string PhoneNo { get; set; }
        
        public DateTime? PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PaymentMethod { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PaymentStatus { get; set; }
    }
}
