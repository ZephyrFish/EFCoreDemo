using System.ComponentModel.DataAnnotations;

namespace EFCoreDataLibrary.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddess { get; set; }
    }
}