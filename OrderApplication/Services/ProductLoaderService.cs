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
    public class ProductLoaderService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public string JsonFilename {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");
            }
        }

        public ProductLoaderService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFilename))
            {
                return JsonSerializer.Deserialize<Product[]>(
                    jsonFileReader.ReadToEnd()
                );
            }
        }
    }
}
