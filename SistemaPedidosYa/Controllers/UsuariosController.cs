using Microsoft.AspNetCore.Mvc;
using SistemaPedidosYa.Interfaces;
using SistemaPedidosYa.Schemes.DTO;

namespace SistemaPedidosYa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase // Cambié 'Controller' por 'ControllerBase' que es mejor para APIs
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login([FromBody] LoginRequest request)
        {
            var usuario = await _repository.Login(request.NombreUsuario, request.Password);

            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos, dog." });
            }

            if (!usuario.Activo)
            {
                return StatusCode(403, "Este usuario está desactivado.");
            }

            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            var usuarios = await _repository.ObtenerTodos();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuario)
        {
            if (usuario.Id == Guid.Empty) usuario.Id = Guid.NewGuid();
            await _repository.Crear(usuario);
            return Ok(new { mensaje = "Usuario creado exitosamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UsuarioDTO usuario)
        {
            usuario.Id = id;
            await _repository.Actualizar(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.Eliminar(id);
            return NoContent();
        }
    } // Aquí cierra la clase UsuariosController

    // ESTA CLASE DEBE ESTAR AQUÍ, DENTRO DEL NAMESPACE PERO FUERA DE LA CLASE ANTERIOR
    public class LoginRequest
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
} // Aquí cierra el namespace