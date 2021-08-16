using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderApplication.Models
{
    public class Discount
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("productid")]
        public int ProductId { get; set; }

        [JsonPropertyName("minamount")]
        public int MinAmount { get; set; }

        [JsonPropertyName("discountfraction")]
        public float DiscountFraction { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize<Discount>(this);
        }

        /// <summary>
        /// Retrieves a valid discount from a collection of possible discounts using product ID and product quantity.
        /// </summary>
        /// <param name="discounts"></param>
        /// <param name="productId"></param>
        /// <param name="productQuantity"></param>
        /// <returns>A valid relevant discount or null if none was found.</returns>
        public static Discount GetDiscount(IEnumerable<Discount> discounts, int productId, int productQuantity)
        {
            foreach (var discount in discounts) {
                if ((productId == discount.ProductId) && (productQuantity >= discount.MinAmount))
                {
                    return discount;
                }
            }
            return null;
        }
    }
}
