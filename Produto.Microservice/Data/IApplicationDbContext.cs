
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Produto.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Models.Produto> Produtos { get; set; }
        Task<int> SaveChanges();
    }
}
