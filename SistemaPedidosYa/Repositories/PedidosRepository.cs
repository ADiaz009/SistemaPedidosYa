using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SistemaPedidosYa.AppContext;
using SistemaPedidosYa.Interfaces;
using SistemaPedidosYa.Schemes.DTO;

namespace SistemaPedidosYa.Repositories
{
    public class PedidosRepository : IPedidoRepository
    {
        private readonly IMongoCollection<PedidosDetalleDTO> _pedidos;

        public PedidosRepository(MongoDBContext context, IOptions<MongoDBSettings> settings)
        {
            _pedidos = context.GetCollection<PedidosDetalleDTO>(settings.Value.PedidosCollectionName);
        }

        public async Task<List<PedidosDetalleDTO>> ObtenerTodos() =>
            await _pedidos.Find(p => true).ToListAsync();

        public async Task<PedidosDetalleDTO> ObtenerPorId(Guid id) =>
            await _pedidos.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task Crear(PedidosDetalleDTO pedido) =>
            await _pedidos.InsertOneAsync(pedido);

        // --- ESTO ES LO QUE TENÉS QUE AGREGAR ---
        public async Task Actualizar(PedidosDetalleDTO pedido)
        {
            var filter = Builders<PedidosDetalleDTO>.Filter.Eq(p => p.Id, pedido.Id);
            await _pedidos.ReplaceOneAsync(filter, pedido);
        }
        // ----------------------------------------

        public async Task ActualizarEstado(Guid id, string nuevoEstado)
        {
            var filter = Builders<PedidosDetalleDTO>.Filter.Eq(p => p.Id, id);
            var update = Builders<PedidosDetalleDTO>.Update.Set(p => p.Estado, nuevoEstado);
            await _pedidos.UpdateOneAsync(filter, update);
        }

        public async Task Eliminar(Guid id) =>
            await _pedidos.DeleteOneAsync(p => p.Id == id);
    }
}
