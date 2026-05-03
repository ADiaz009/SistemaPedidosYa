namespace SistemaPedidosYa.AppContext
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PedidosCollectionName { get; set; } = null!;
        public string ProductosCollectionName { get; set; } = null!;
        public string UsuariosCollectionName { get; set; } = null!;
    }
}
