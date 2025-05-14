using Lab_09_Roman_Qquelcca.DTOs;
using Lab_09_Roman_Qquelcca.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_09_Roman_Qquelcca.Services.LINQ
{
    public class GetSalesByClient
    {
        private readonly LinQDBContext _context;

        public GetSalesByClient(LinQDBContext context)
        {
            _context = context;
        }

        public List<SalesByClientDto> Execute()
        {
            var clients = _context.Clients.ToList();

            var salesByClient = _context.Orders
                .Include(order => order.Orderdetails)
                .ThenInclude(orderDetail => orderDetail.Product)
                .AsNoTracking()
                .GroupBy(order => order.ClientId)
                .Select(group => new
                {
                    ClientId = group.Key,
                    TotalSales = group.Sum(order => order.Orderdetails
                        .Sum(detail => detail.Quantity * detail.Product.Price))
                })
                .OrderByDescending(s => s.TotalSales)
                .ToList();

            var result = salesByClient.Select(s => new SalesByClientDto
            {
                ClientName = clients.FirstOrDefault(c => c.ClientId == s.ClientId)?.Name ?? "Desconocido",
                TotalSales = s.TotalSales
            }).ToList();

            return result;
        }
    }
}