using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Thrifty.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Please enter valid email!")]
        [Required(ErrorMessage = "Please enter your email.")]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [Column(TypeName = "varchar(300)")]
        public string Message { get; set; }
    }
}