using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookProject.Models
{
    public class AdminModel
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? EmailAddress { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
