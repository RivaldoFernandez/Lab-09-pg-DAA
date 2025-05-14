using Lab_09_Roman_Qquelcca.DTOs;
using Lab_09_Roman_Qquelcca.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_09_Roman_Qquelcca.Services.LINQ
{
    public class GetOrdersWithDetails
    {
        private readonly LinQDBContext _context;

        public GetOrdersWithDetails(LinQDBContext context)
        {
            _context = context;
        }

        public List<OrderDetailsDto> Execute()
        {
            var ordersWithDetails = _context.Orders
                .Include(order => order.Orderdetails)
                .ThenInclude(orderDetail => orderDetail.Product)
                .AsNoTracking()
                .Select(order => new OrderDetailsDto
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    Products = order.Orderdetails
                        .Where(od => od.Product != null)
                        .Select(od => new ProductDto
                        {
                            ProductName = od.Product.Name,
                            Quantity = od.Quantity,
                            Price = od.Product.Price
                        })
                        .ToList()
                })
                .ToList();

            return ordersWithDetails;
        }
    }
}