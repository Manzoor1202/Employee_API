using System.ComponentModel.DataAnnotations;

namespace Shared_Library.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Designation { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;

    }
}
