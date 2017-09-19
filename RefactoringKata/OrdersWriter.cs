﻿using System.Text;
using RefactoringKata.Enums;
using RefactoringKata.Extensions;

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
            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                var order = _orders.GetOrder(i);
                sb.Append("{");
                sb.Append("\"id\": ");
                sb.Append(order.GetOrderId());
                sb.Append(", ");
                sb.Append("\"products\": [");

                for (var j = 0; j < order.GetProductsCount(); j++)
                {
                    var product = order.GetProduct(j);
                    sb.Append("{");
                    sb.Append("\"code\": \"");
                    sb.Append(product.Code);
                    sb.Append("\", ");
                    sb.Append("\"color\": \"");
                    sb.Append(product.Color.ToString().SplitCamelCase().ToLower());
                    sb.Append("\", ");

                    if (product.Size != ProductSize.SIZE_NOT_APPLICABLE)
                    {
                        sb.Append("\"size\": \"");
                        sb.Append(product.Size);
                        sb.Append("\", ");
                    }

                    sb.Append("\"price\": ");
                    sb.Append(product.Price);
                    sb.Append(", ");
                    sb.Append("\"currency\": \"");
                    sb.Append(product.Currency);
                    sb.Append("\"}, ");
                }

                if (order.GetProductsCount() > 0)
                {
                    sb.Remove(sb.Length - 2, 2);
                }

                sb.Append("]");
                sb.Append("}, ");
            }

            if (_orders.GetOrdersCount() > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.Append("]}").ToString();
        }
    }
}