using Microsoft.AspNetCore.Mvc;
using SistemaPedidosYa.Interfaces;
using SistemaPedidosYa.Schemes;
using SistemaPedidosYa.Schemes.DTO;

namespace SistemaPedidosYa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _repository;

        public ProductoController(IProductoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDTO>>> Get() =>
            Ok(await _repository.ObtenerTodos());

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetById(Guid id)
        {
            var producto = await _repository.ObtenerPorId(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoDTO producto)
        {
            await _repository.Crear(producto);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductoDTO producto)
        {
            // Buena práctica: nos aseguramos que el ID de la URL sea el mismo del objeto
            producto.Id = id;

            // Ahora esta llamada coincide con la Interfaz
            await _repository.Actualizar(producto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.Eliminar(id);
            return NoContent();
        }
    }
}
