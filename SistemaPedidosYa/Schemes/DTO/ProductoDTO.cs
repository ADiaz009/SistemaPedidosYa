using MongoDB.Bson.Serialization.Attributes;

namespace SistemaPedidosYa.Schemes
{
    public class ProductoDTO
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Al asignar = string.Empty, ya no es nula al salir del constructor
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public string Categoria { get; set; } = string.Empty;

        public bool EstaDisponible { get; set; } = true;

        public string ImagenUrl { get; set; } = string.Empty;
    }
}