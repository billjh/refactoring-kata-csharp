using System.Collections.Generic;
using System.Linq;
using RefactoringKata.Extensions;

namespace RefactoringKata.Serialization
{
    public class OrderView
    {
        public readonly int Id;
        public readonly IReadOnlyList<Product> Products;

        public OrderView(Order order)
        {
            Id = order.GetOrderId();
            Products = order.GetProducts().ToList();
        }
    }
}