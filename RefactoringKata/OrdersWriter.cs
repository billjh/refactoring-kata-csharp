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
            return JsonConvert.SerializeObject(new OrdersView(_orders), new JsonSerializerSettings
            {
                ContractResolver = new OrdersContractResolver()
            });
        }
    }
}