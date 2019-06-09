using System.ComponentModel.DataAnnotations;
using BoardApp.Models.enums;

namespace BoardApp.Models
{
    public class Equipment
    {
        [Key]
        public long Id { get; set; }
        public EquipmentType Type { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public Owner Owner { get; set; }
    }
}