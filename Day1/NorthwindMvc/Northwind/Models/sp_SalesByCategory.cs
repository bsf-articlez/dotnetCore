using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindMvc.Northwind.Models
{
    public class SalesByCategoryResult
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Column("TotalPurchase")]
        public decimal Total { get; set; }
    }
}
