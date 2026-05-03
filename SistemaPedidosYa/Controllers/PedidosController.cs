using Microsoft.AspNetCore.Mvc;
using SistemaPedidosYa.Schemes.DTO;
using SistemaPedidosYa.Interfaces;

namespace SistemaPedidosYa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _repository;

        public PedidosController(IPedidoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/pedidos
        [HttpGet]
        public async Task<ActionResult<List<PedidosDetalleDTO>>> Get()
        {
            // Usamos ObtenerTodos() con 's' como está en tu repositorio
            var pedidos = await _repository.ObtenerTodos();
            return Ok(pedidos);
        }

        // GET: api/pedidos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosDetalleDTO>> GetPorId(Guid id)
        {
            var pedido = await _repository.ObtenerPorId(id);
            if (pedido == null) return NotFound(new { mensaje = "Pedido no encontrado" });
            return Ok(pedido);
        }

        // POST: api/pedidos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidosDetalleDTO pedido)
        {
            if (pedido.Id == Guid.Empty) pedido.Id = Guid.NewGuid();

            // Sincronizado con tu DTO: FechaCreacion
            pedido.FechaCreacion = DateTime.Now;

            if (string.IsNullOrEmpty(pedido.Estado)) pedido.Estado = "Pendiente";

            await _repository.Crear(pedido);
            return Ok(new { mensaje = "Pedido creado exitosamente", id = pedido.Id });
        }

        // PUT: api/pedidos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PedidosDetalleDTO pedido)
        {
            pedido.Id = id;
            // Llama al método Actualizar que acabamos de agregar al repo
            await _repository.Actualizar(pedido);
            return NoContent();
        }

        // PATCH: api/pedidos/{id}/estado
        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> PatchEstado(Guid id, [FromBody] string nuevoEstado)
        {
            var pedido = await _repository.ObtenerPorId(id);
            if (pedido == null) return NotFound();

            await _repository.ActualizarEstado(id, nuevoEstado);
            return Ok(new { mensaje = $"Estado actualizado a {nuevoEstado}" });
        }

        // DELETE: api/pedidos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.Eliminar(id);
            return NoContent();
        }
    }
}