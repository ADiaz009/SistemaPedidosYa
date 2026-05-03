using SistemaPedidosYa.Schemes.DTO;

namespace SistemaPedidosYa.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioDTO> Login(string username, string password); // Vital para el Login
        Task<List<UsuarioDTO>> ObtenerTodos();
        Task<UsuarioDTO> ObtenerPorId(Guid id);
        Task Crear(UsuarioDTO usuario);

        // CAMBIO: Solo pasamos el objeto, el ID ya va dentro del DTO
        Task Actualizar(UsuarioDTO usuario);

        Task Eliminar(Guid id);
    }
}
