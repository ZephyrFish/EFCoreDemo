using System.ComponentModel.DataAnnotations;

namespace EFCoreDataLibrary.Models
{
    public class Address
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string StreetAddress { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }
    }
}