using System.Collections.Generic;

namespace RefactoringKata.Extensions
{
    public static class OrdersExtensions
    {
        public static IEnumerable<Order> GetOrders(this Orders orders)
        {
            for (var i = 0; i < orders.GetOrdersCount(); i++)
            {
                yield return orders.GetOrder(i);
            }
        }
    }
}