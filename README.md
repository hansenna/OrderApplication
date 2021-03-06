## OrderApplication ##

A proof-of-concept for generating a receipt from a sample order.

HTML and Text representations are generated for the receipt.

---
### Models Directory

Contains the classes representing an ordering system, including:

- **Product.cs** (Stores description and unit price.)
- **Discount.cs** (Discounts a product cost according to the amount that has been ordered.)
- **OrderItem.cs** (Represents a **Product** with quantity and **Discount**.)
- **Order.cs** (Contains a collection of **OrderItem**s.)
- **Receipt.cs** (Contains a collection of **ReceiptItem**s.  Has aggregation functions for calculating costs, discounts and taxes for **ReceiptItem**s)
- **ReceiptItem.cs** (Encapsulates **Product**s, quantities, and any applied discounts.)

### Pages Directory

Contains the different pages of the site:

- **Index.cshtml** (Shows a HTML representation of the receipt.)
- **ReceiptText.cshtml** (Shows a text representation of the receipt.)

### Data Directory (wwwroot/data)

Contains json files used in lieu of databases:

- **products.json** A collection of available **Product**s.
- **discounts.json** A collection of available **Discount**s.
- **order.json** A sample **Order** that will be used to generate a **Receipt**.

### Screenshots

*HTML Receipt:*

![HTMLReceipt](<./Screenshot Receipt HTML - OrderApplication.png> "HTMLReceipt")

*Text Receipt:*

![HTMLReceipt](<./Screenshot Receipt Text - OrderApplication.png> "HTMLReceipt")