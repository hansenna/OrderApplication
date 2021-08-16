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
    public class OrderLoaderService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public string JsonFilename
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "order.json");
            }
        }

        public OrderLoaderService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public Order GetOrder()
        {
            using (var jsonFileReader = File.OpenText(JsonFilename))
            {
                return JsonSerializer.Deserialize<Order>(
                    jsonFileReader.ReadToEnd()
                );
            }
        }
    }
}
