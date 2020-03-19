using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OnlineRealEstate.Entity
{
    public class User
    {
        [Required]
        [MaxLength(30)]
         [Key]
        public string Name { get; set; }
        [Index(IsUnique = true)] 
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [MaxLength(10)]
        public string Role { get; set; }
        [Required]
        [MaxLength(20)]
        public string Location { get; set; }

    }
}
