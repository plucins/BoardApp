using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardApp.Models
{
    public class Worker
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}