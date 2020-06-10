using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleODataAPI.Models;

namespace SampleODataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Product> _products = new List<Product>()
        {
            new Product{ ProductId=1, ProductName="Asus Vivobook Laptop", ProductPrice=40000.00m},
            new Product{ ProductId=2, ProductName="Moto X4 Smartphone", ProductPrice=20000.00m},
            new Product{ ProductId=3, ProductName="Phillips BT Speaker", ProductPrice=4500.50m},
            new Product{ ProductId=4, ProductName="Asus Printer", ProductPrice=6000.00m},
        };
        [HttpGet]
        //[EnableQuery()]
        public IEnumerable<Product> Get()
        {
            return _products;
        }
    }
}
