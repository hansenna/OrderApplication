using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderApplication.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public float Price { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Product>(this);
        }

        public static Product GetProduct(IEnumerable<Product> products, int productId)
        {
            foreach (var product in products)
            {
                if (productId == product.Id)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
