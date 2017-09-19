using System.Collections.Generic;

namespace RefactoringKata.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<Product> GetProducts(this Order order)
        {
            for (var i = 0; i < order.GetProductsCount(); i++)
            {
                yield return order.GetProduct(i);
            }
        }
    }
}