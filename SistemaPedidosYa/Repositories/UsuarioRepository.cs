using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SistemaPedidosYa.AppContext;
using SistemaPedidosYa.Interfaces;
using SistemaPedidosYa.Schemes.DTO;

namespace SistemaPedidosYa.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<UsuarioDTO> _usuarios;
        public UsuarioRepository(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _usuarios = database.GetCollection<UsuarioDTO>("Usuarios");
        }
        public async Task<List<UsuarioDTO>> ObtenerTodos()
        {
            return await _usuarios.Find(_ => true).ToListAsync();
        }
        public async Task<UsuarioDTO> ObtenerPorId(Guid id)
        {
            return await _usuarios.Find(u => u.Id == id).FirstOrDefaultAsync();
        }
        public async Task Crear(UsuarioDTO usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
        }
        public async Task Actualizar(UsuarioDTO usuario)
        {
            // Filtramos por el ID que trae el objeto
            var filter = Builders<UsuarioDTO>.Filter.Eq(u => u.Id, usuario.Id);

            // Reemplazamos el documento en la colección de Usuarios
            await _usuarios.ReplaceOneAsync(filter, usuario);
        }

        public async Task<UsuarioDTO> Login(string username, string password)
        {
            return await _usuarios.Find(u => u.NombreUsuario == username && u.Password == password)
                                  .FirstOrDefaultAsync();
        }
        public async Task Eliminar(Guid id)
        {
            await _usuarios.DeleteOneAsync(u => u.Id == id);
        }
    }
}
