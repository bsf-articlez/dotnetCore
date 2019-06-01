using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindMvc.Northwind.Models
{
    public partial class AppDb
    {
        public virtual DbQuery<vw_CategorySalesFor1997> vw_CategorySaleFor1997 { get; set; }
        public virtual DbQuery<SalesByCategoryResult> SalesByCategoryResults { get; set; }

        public IQueryable<SalesByCategoryResult> sp_SalesByCategories(string categoryName, int orderYear)
        {
            //this.Database.ExecuteSqlCommand("....");
            return this.SalesByCategoryResults.FromSql($"EXEC SalesByCategory {categoryName}, {orderYear}");
        }
    }
}
