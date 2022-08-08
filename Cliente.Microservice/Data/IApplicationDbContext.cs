
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cliente.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Models.Cliente> Clientes { get; set; }
        Task<int> SaveChanges();
    }
}
