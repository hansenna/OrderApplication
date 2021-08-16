using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderApplication.Models
{
    public class OrderItem
    {
        [JsonPropertyName("productid")]
        public int ProductId { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<OrderItem>(this);
        }
    }
}
