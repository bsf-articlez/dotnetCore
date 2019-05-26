using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mvc01.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Required]
        public Machine Machine { get; set; }
        public Product Product { get; set; }
    }
}
