using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplication.Models
{
    public class Receipt
    {
        public float salesTax { get; private set; }

        public DateTime timestamp { get; private set; }

        public ReceiptItem[] receiptItems { get; private set; }

        public Receipt(ReceiptItem[] receiptItems, DateTime timestamp, float salesTax)
        {
            this.salesTax = salesTax;
            this.timestamp = timestamp;
            this.receiptItems = receiptItems;
        }

        public float Subtotal()
        {
            float result = 0.0f;
            foreach (var receiptItem in receiptItems)
            {
                result += receiptItem.ItemCostDiscounted();
            }
            return result;
        }

        public float SalesTaxTotal()
        {
            float result = 0.0f;
            foreach (var receiptItem in receiptItems)
            {
                result += receiptItem.ItemSalesTax(salesTax);
            }
            return result;
        }

        public float Total()
        {
            float result = 0.0f;
            foreach (var receiptItem in receiptItems)
            {
                result += receiptItem.ItemCostSalesTaxed(salesTax);
            }
            return result;
        }

        public float TotalDiscounts()
        {
            float result = 0.0f;
            foreach (var receiptItem in receiptItems)
            {
                result += receiptItem.ItemDiscount();
            }
            return result;
        }

        public static Receipt MakeReceipt(IEnumerable<OrderItem> orderItems, IEnumerable<Discount> discounts, IEnumerable<Product> products)
        {
            var receiptItems = new List<ReceiptItem>();
            foreach (var orderItem in orderItems)
            {
                Discount discount = Discount.GetDiscount(discounts, orderItem.ProductId, orderItem.Amount);
                Product product = Product.GetProduct(products, orderItem.ProductId);
                receiptItems.Add(new ReceiptItem(product.Title + " - " +product.Description, orderItem.Amount, product.Price, discount));
            }

            float salesTax = 0.1f;
            return new Receipt(receiptItems.ToArray(), DateTime.Now, salesTax);
        }
    }
}
