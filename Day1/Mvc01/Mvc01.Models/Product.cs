using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mvc01.Models
{
    public class Product
    {
        [Key] // Set primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Set no generate auto increment
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 999999)] // Range data
        [Column("Price", TypeName = "decimal(18, 4)")] // Fix data column
        public decimal Price { get; set; }
        public ICollection<ProductPicture> Pictures { get; set; } = new HashSet<ProductPicture>();
        public DateTime CreateDate { get; set; }
    }
}
