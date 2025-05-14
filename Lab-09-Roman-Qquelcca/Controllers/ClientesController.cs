using Lab_09_Roman_Qquelcca.DTOs;
using Lab_09_Roman_Qquelcca.Services;
using Lab_09_Roman_Qquelcca.Services.LINQ;
using Microsoft.AspNetCore.Mvc;

namespace Lab_09_Roman_Qquelcca.Controllers
{
    [Route("api/qquelcca/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly GetClientsWithOrders _getClientsWithOrders;
        private readonly GetClientsWithProductCount _getClientsWithProductCountService;

        public ClientesController(GetClientsWithOrders getClientsWithOrders, GetClientsWithProductCount getClientsWithProductCountService)
        {
            _getClientsWithOrders = getClientsWithOrders;
            _getClientsWithProductCountService = getClientsWithProductCountService;
        }

        [HttpGet("clients-with-orders")]
        public ActionResult<List<ClientOrderDto>> GetClientsWithOrders()
        {
            var clientOrders = _getClientsWithOrders.Execute();

            if (clientOrders == null || !clientOrders.Any())
            {
                return NotFound("No se encontraron clientes con pedidos.");
            }

            return Ok(clientOrders);
        }

        [HttpGet("clients-with-product-count")]
        public ActionResult<List<ClientProductCountDto>> GetClientsWithProductCount()
        {
            var clientsWithProductCount = _getClientsWithProductCountService.Execute();

            if (clientsWithProductCount == null || !clientsWithProductCount.Any())
            {
                return NotFound("No clients found.");
            }

            return Ok(clientsWithProductCount);
        }
    }
}