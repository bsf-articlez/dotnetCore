using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindMvc.Northwind.Models
{
    [Table("Category Sales for 1997")]
    public class vw_CategorySalesFor1997
    {
        [Column("CategoryName")]
        public string Name { get; set; }
        public decimal CategorySales { get; set; }
    }
}
