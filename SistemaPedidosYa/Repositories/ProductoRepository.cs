using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SistemaPedidosYa.AppContext;
using SistemaPedidosYa.Interfaces;
using SistemaPedidosYa.Schemes;
using SistemaPedidosYa.Schemes.DTO;

namespace SistemaPedidosYa.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IMongoCollection<ProductoDTO> _productos;
        public ProductoRepository(MongoDBContext context, IOptions<MongoDBSettings> settings)
        {
            _productos = context.GetCollection<ProductoDTO>(settings.Value.ProductosCollectionName);
        }

        public async Task<List<ProductoDTO>> ObtenerTodos() =>
            await _productos.Find(p => true).ToListAsync();

        public async Task<ProductoDTO> ObtenerPorId(Guid id) =>
            await _productos.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task Crear(ProductoDTO producto) => 
            await _productos.InsertOneAsync(producto);

        public async Task Actualizar(ProductoDTO producto)
        {
            // Usamos el ID que ya viene en el DTO
            var filter = Builders<ProductoDTO>.Filter.Eq(p => p.Id, producto.Id);

            // Reemplazamos todo el documento en Mongo
            await _productos.ReplaceOneAsync(filter, producto);
        }

        public async Task Eliminar(Guid id) =>
            await _productos.DeleteOneAsync(p => p.Id == id);
    }
}
