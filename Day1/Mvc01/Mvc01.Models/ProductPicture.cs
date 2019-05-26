using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mvc01.Models
{
    //[Table("ProductPictures")]
    public class ProductPicture
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [Required]
        [StringLength(512)]
        public string Url { get; set; }
    }
}
