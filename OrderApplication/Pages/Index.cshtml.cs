using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OrderApplication.Models;
using OrderApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public ProductLoaderService ProductLoaderService;
        public IEnumerable<Product> Products { get; private set; }

        public DiscountLoaderService DiscountLoaderService;
        public IEnumerable<Discount> Discounts { get; private set; }

        public OrderLoaderService OrderLoaderService;
        public Order Order { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            ProductLoaderService productLoaderService,
            DiscountLoaderService discountLoaderService,
            OrderLoaderService orderLoaderService)
        {
            _logger = logger;
            ProductLoaderService = productLoaderService;
            DiscountLoaderService = discountLoaderService;
            OrderLoaderService = orderLoaderService;
        }

        public void OnGet()
        {
            Products = ProductLoaderService.GetProducts();
            Discounts = DiscountLoaderService.GetDiscounts();
            Order = OrderLoaderService.GetOrder();
        }
    }
}
