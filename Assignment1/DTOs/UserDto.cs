using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Assignment1.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Middle Name")]
        public string? MiddleName { get; set; }
        [Required]
        [MaxLength(250)]
        [DisplayName("Address Name")]

        public string? Address { get; set; }
    }
}
