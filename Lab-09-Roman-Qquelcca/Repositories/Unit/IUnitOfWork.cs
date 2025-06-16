using Lab_09_Roman_Qquelcca.Models;
using Lab_09_Roman_Qquelcca.Repositories;


namespace Examen_Roman_Qquelcca.Repositories.Interfaces;

    public interface IUnitOfWork
    {
        IGenericRepository<Client> Clients { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Orderdetail> Orderdetails { get; }


        Task<int> SaveAsync();
    }
