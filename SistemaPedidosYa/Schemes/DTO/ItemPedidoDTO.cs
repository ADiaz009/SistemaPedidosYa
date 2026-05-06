using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaPedidosYa.Schemes.DTO
{
    public class ItemPedidoDTO
    {
        [BsonRepresentation(BsonType.String)]
        public Guid ProductoId { get; set; } = Guid.NewGuid();
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
