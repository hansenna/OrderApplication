using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplication.Models
{
    public class ReceiptItem
    {
        public string ItemDescription { get; private set; }

        public int ItemQuantity { get; private set; }

        public float ItemPrice { get; private set; }

        /// <summary>
        /// discount is null if no discount has been applied to this item.
        /// </summary>
        public Discount discount { get; private set; }

        public ReceiptItem(string itemDescription, int itemQuantity, float itemPrice, Discount discount)
        {
            this.ItemDescription = itemDescription;
            this.ItemQuantity = itemQuantity;
            this.ItemPrice = itemPrice;
            this.discount = discount;
        }

        public float ItemCostOriginal()
        {
            return ItemQuantity * ItemPrice;
        }

        public float ItemDiscount()
        {
            float discountFraction = (null == discount) ? 0 : discount.DiscountFraction;
            return ItemCostOriginal() * discountFraction;
        }

        public float ItemCostDiscounted()
        {
            return ItemCostOriginal() - ItemDiscount();
        }

        public float ItemSalesTax(float taxFraction)
        {
            return ItemCostDiscounted() * taxFraction;
        }

        public float ItemCostSalesTaxed(float taxFraction)
        {
            return ItemCostDiscounted() + ItemSalesTax(taxFraction);
        }
    }
}
