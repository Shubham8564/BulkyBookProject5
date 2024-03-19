using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? EmailAddress { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Password { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
