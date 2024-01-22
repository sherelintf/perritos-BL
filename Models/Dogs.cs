using System.ComponentModel.DataAnnotations;

namespace BL.Models
{
    public class Dog
    {

        

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        public Guid OwnerId { get; set; }
    }
}
