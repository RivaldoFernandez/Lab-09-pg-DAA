using Lab_09_Roman_Qquelcca.Models;
using Lab_09_Roman_Qquelcca.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Lab_09_Roman_Qquelcca.Services
{
    public class GetClientsWithProductCount
    {
        private readonly LinQDBContext _context;

        public GetClientsWithProductCount(LinQDBContext context)
        {
            _context = context;
        }

        public List<ClientProductCountDto> Execute()
        {
            // Consulta para obtener clientes y el total de productos que han comprado
            var clientsWithProductCount = _context.Clients
                .AsNoTracking()
                .Select(client => new ClientProductCountDto
                {
                    ClientName = client.Name,
                    TotalProducts = client.Orders
                        .Sum(order => order.Orderdetails.Sum(detail => detail.Quantity))
                })
                .ToList();

            return clientsWithProductCount;
        }
    }
}