using SistemaPedidosYa.Schemes;

namespace SistemaPedidosYa.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<ProductoDTO>> ObtenerTodos();
        Task<ProductoDTO> ObtenerPorId(Guid id);
        Task Crear(ProductoDTO producto);
        Task Actualizar(ProductoDTO producto);
        Task Eliminar(Guid id);
    }
}
