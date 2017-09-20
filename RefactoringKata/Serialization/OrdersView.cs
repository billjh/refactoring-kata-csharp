using System.Collections.Generic;
using System.Linq;
using RefactoringKata.Extensions;

namespace RefactoringKata.Serialization
{
    public class OrdersView
    {
        public readonly IReadOnlyList<OrderView> Orders;

        public OrdersView(Orders orders)
        {
            Orders = (orders.GetOrders() ?? new List<Order>()).Select(o => new OrderView(o)).ToList();
        }
    }
}