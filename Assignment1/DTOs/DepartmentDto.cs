using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Department Name")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Department Description")]
        public string? Description { get; set; }
    }
}
