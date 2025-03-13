using Database_First.Contexts;
using Database_First.Models;

namespace Database_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Session 04 
           using MyNorthwindDbContext dbContext = new MyNorthwindDbContext();
            #region stored Procedure
            //MyNorthwindDbContextProcedures db = new MyNorthwindDbContextProcedures(dbContext);
            //var Cust5Orders = db.CustOrderHistAsync("ALFKI").Result;

            //foreach (var order in Cust5Orders)
            //    Console.WriteLine(order.Total);
            #endregion

            #region View
            //var Result = dbContext.ProductsByCategories.ToList();

            
            #endregion



            #endregion

        }
    }
}
