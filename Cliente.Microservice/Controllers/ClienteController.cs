using Cliente.Microservice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IApplicationDbContext _context;

        public ClienteController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChanges();
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _context.Clientes.ToListAsync();
            if (clientes == null) return NotFound();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _context.Clientes.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (cliente == null) return NotFound();
            _context.Clientes.Remove(cliente);
            await _context.SaveChanges();
            return Ok(cliente.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Models.Cliente clienteDados)
        {
            var cliente = _context.Clientes.Where(a => a.Id == id).FirstOrDefault();

            if (cliente == null) return NotFound();
            else
            {
                cliente.Nome = clienteDados.Nome;
                cliente.Telefone = clienteDados.Telefone;
                cliente.Email = clienteDados.Email;
                cliente.Cidade = clienteDados.Cidade;
                await _context.SaveChanges();
                return Ok(cliente.Id);
            }
        }
    }
}
