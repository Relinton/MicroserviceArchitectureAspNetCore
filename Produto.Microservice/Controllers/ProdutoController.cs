using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produto.Microservice.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Produto.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IApplicationDbContext _context;
        public ProdutoController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Models.Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChanges();
            return Ok(produto.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _context.Produtos.ToListAsync();
            if (produtos == null) return NotFound();
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _context.Produtos.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (produto == null) return NotFound();
            return Ok(produto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (produto == null) return NotFound();
            _context.Produtos.Remove(produto);
            await _context.SaveChanges();
            return Ok(produto.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Models.Produto produtoDados)
        {
            var produto = _context.Produtos.Where(a => a.Id == id).FirstOrDefault();
            if (produto == null) return NotFound();
            else
            {
                produto.Nome = produtoDados.Nome;
                produto.Preco = produtoDados.Preco;
                await _context.SaveChanges();
                return Ok(produto.Id);
            }
        }
    }
}
