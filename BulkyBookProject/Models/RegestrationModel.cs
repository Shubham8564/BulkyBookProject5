using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookProject.Models
{
    public class RegestrationModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }
        [Required]
        public string? EmployeeType { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MaxLength(12)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        
        public string ConfirmPassword { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
