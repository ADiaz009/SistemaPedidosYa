using SistemaPedidosYa.Schemes.DTO;

namespace SistemaPedidosYa.Interfaces
{
    public interface IPedidoRepository
    {
        Task<List<PedidosDetalleDTO>> ObtenerTodos(); // Agregada la 's' para coincidir con el repo
        Task<PedidosDetalleDTO> ObtenerPorId(Guid id);
        Task Crear(PedidosDetalleDTO pedido);

        // Este es el que te falta implementar en el Repositorio:
        Task Actualizar(PedidosDetalleDTO pedido);

        Task ActualizarEstado(Guid id, string nuevoEstado);
        Task Eliminar(Guid id);

    }
}
