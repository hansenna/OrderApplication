using Microsoft.AspNetCore.Hosting;
using OrderApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderApplication.Services
{
    public class DiscountLoaderService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public string JsonFilename
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "discounts.json");
            }
        }

        public DiscountLoaderService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Discount> GetDiscounts()
        {
            using (var jsonFileReader = File.OpenText(JsonFilename))
            {
                return JsonSerializer.Deserialize<Discount[]>(
                    jsonFileReader.ReadToEnd()
                );
            }
        }
    }
}
