using MongoDB.Bson.Serialization.Attributes;

namespace SistemaPedidosYa.Schemes.DTO
{
    public class PedidosDetalleDTO
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string NumeroOrden { get; set; } = string.Empty;
        public string Mesa { get; set; } = string.Empty;
        public string Mesero { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;  
        public List<ItemPedidoDTO> Items { get; set; } = new List<ItemPedidoDTO>();
        public decimal Subtotal => Items.Sum(i => i.Subtotal);
        public decimal PorcentajeIVA { get; set; } = 0.15m;
        public decimal MontoIVA => Subtotal * PorcentajeIVA;
        public decimal Total => Subtotal + MontoIVA;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
