using System.Text;
using Newtonsoft.Json;
using RefactoringKata.Serialization;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContents()
        {
            var sb = new StringBuilder("{\"orders\":[");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                var order = _orders.GetOrder(i);
                sb.Append("{");
                sb.Append("\"id\":");
                sb.Append(order.GetOrderId());
                sb.Append(",");
                sb.Append("\"products\":[");

                for (var j = 0; j < order.GetProductsCount(); j++)
                {
                    var product = order.GetProduct(j);
                    sb.Append(JsonConvert.SerializeObject(product, new JsonSerializerSettings
                    {
                        ContractResolver = new OrdersContractResolver()
                    }));
                    sb.Append(", ");
                }

                if (order.GetProductsCount() > 0)
                {
                    sb.Remove(sb.Length - 2, 2);
                }

                sb.Append("]");
                sb.Append("},");
            }

            if (_orders.GetOrdersCount() > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.Append("]}").ToString();
        }
    }
}