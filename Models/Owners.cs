using System.ComponentModel.DataAnnotations;

namespace BL.Models
{
    public class Owner
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
