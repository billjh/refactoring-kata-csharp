using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RefactoringKata.Extensions;
using RefactoringKata.Serialization;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;

        private readonly JsonSerializerSettings _serializationSetting;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
            _serializationSetting = new JsonSerializerSettings
            {
                ContractResolver = new OrdersContractResolver()
            };
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
                sb.Append(string.Join(",", order.GetProducts().Select(p => JsonConvert.SerializeObject(p, _serializationSetting))));
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