using System.ComponentModel.DataAnnotations;

namespace BoardApp.Models
{
    public class Owner
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}