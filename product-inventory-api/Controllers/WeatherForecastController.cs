using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using product.inventory.dto;
using product.inventory.service;

namespace product_inventory_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProductService _productService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var test = await _productService.GetProducts().ConfigureAwait(false);

            var rng = new Random();
            return test;
        }
    }
}
