using Examen_Roman_Qquelcca.Repositories.Interfaces;
using Lab_09_Roman_Qquelcca.Models;

namespace Lab_09_Roman_Qquelcca.Repositories.Unit;

public class UnitOfWork : IUnitOfWork
{
    private readonly LinQDBContext _context;

    public IGenericRepository<Client> Clients { get; private set; }
    public IGenericRepository<Product> Products { get; private set; }
    public IGenericRepository<Order> Orders { get; private set; }
    public IGenericRepository<Orderdetail> Orderdetails { get; private set; }


    public UnitOfWork(LinQDBContext context)
    {
        _context = context;
        Clients = new GenericRepository<Client>(_context);
        Products = new GenericRepository<Product>(_context);
        Orders = new GenericRepository<Order>(_context);
        Orderdetails = new GenericRepository<Orderdetail>(_context);
    }


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}