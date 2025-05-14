using Lab_09_Roman_Qquelcca.DTOs;
using Lab_09_Roman_Qquelcca.Services.LINQ;
using Microsoft.AspNetCore.Mvc;

namespace Lab_09_Roman_Qquelcca.Controllers
{
    [Route("api/qquelcca/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly GetSalesByClient _getSalesByClient;

        public SalesController(GetSalesByClient getSalesByClient)
        {
            _getSalesByClient = getSalesByClient;
        }

        [HttpGet("sales-by-client")]
        public ActionResult<List<SalesByClientDto>> GetSalesByClient()
        {
            var sales = _getSalesByClient.Execute();

            if (sales == null || !sales.Any())
            {
                return NotFound("No se encontraron ventas por cliente.");
            }

            return Ok(sales);
        }
    }
}