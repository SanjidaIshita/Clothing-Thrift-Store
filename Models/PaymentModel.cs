using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thrifty.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Please enter the product no!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your address!")]
        [Column(TypeName = "varchar(150)")]
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Please enter valid email!")]
        [Required(ErrorMessage = "Please enter your email!")]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
                
        [Required(ErrorMessage = "Please enter your phone number!")]
        [Column(TypeName = "varchar(11)")]
        public string PhoneNo { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Required(ErrorMessage = "Please enter the payment method!")]
        [Column(TypeName = "varchar(50)")]
        public string PaymentMethod { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PaymentStatus { get; set; }
    }
}
