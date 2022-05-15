using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreDataLibrary.Models
{
    public class Person
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        public int Age { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Email> Emails { get; set; }
    }
}