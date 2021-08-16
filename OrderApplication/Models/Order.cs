using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderApplication.Models
{
    public class Order
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("orderitems")]
        public OrderItem[] OrderItems { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Order>(this);
        }
    }
}
