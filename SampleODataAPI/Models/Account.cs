using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleODataAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required]
        public Decimal Balance { get; set; }
        [Required, StringLength(75)]
        public string Address { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        public string Email { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
    }
}
