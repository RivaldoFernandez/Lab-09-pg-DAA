using Lab_09_Roman_Qquelcca.DTOs;
using Lab_09_Roman_Qquelcca.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_09_Roman_Qquelcca.Services.LINQ
{
    public class GetClientsWithOrders
    {
        private readonly LinQDBContext _context;

        public GetClientsWithOrders(LinQDBContext context)
        {
            _context = context;
        }

        public List<ClientOrderDto> Execute()
        {
            var clientOrders = _context.Clients
                .AsNoTracking()
                .Include(c => c.Orders)
                .Select(client => new ClientOrderDto
                {
                    ClientName = client.Name,
                    Orders = client.Orders.Select(order => new OrderDto
                    {
                        OrderId = order.OrderId,
                        OrderDate = order.OrderDate
                    }).ToList()
                })
                .ToList();

            return clientOrders;
        }
    }
}