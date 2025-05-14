using Lab_09_Roman_Qquelcca.DTOs;
using Lab_09_Roman_Qquelcca.Services.LINQ;
using Microsoft.AspNetCore.Mvc;

namespace Lab_09_Roman_Qquelcca.Controllers
{
    [Route("api/qquelcca/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly GetOrdersWithDetails _getOrdersWithDetails;

        public OrdenesController(GetOrdersWithDetails getOrdersWithDetails)
        {
            _getOrdersWithDetails = getOrdersWithDetails;
        }

        [HttpGet("orders-with-details")]
        public ActionResult<List<OrderDetailsDto>> GetOrdersWithDetails()
        {
            try
            {
                var ordersWithDetails = _getOrdersWithDetails.Execute();

                if (ordersWithDetails != null && ordersWithDetails.Count > 0)
                {
                    return Ok(ordersWithDetails);
                }

                return NotFound("No orders found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}