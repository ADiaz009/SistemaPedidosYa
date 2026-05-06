namespace SistemaPedidosYa.WinForms.Models
{
    public class PedidosDetalleDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NumeroOrden { get; set; } = string.Empty;
        public string Mesa { get; set; } = string.Empty;
        public string Mesero { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";
        public List<ItemPedidoDTO> Items { get; set; } = new List<ItemPedidoDTO>();

        // Lógica de cálculos espejo de la API
        public decimal Subtotal => Items.Sum(i => i.Subtotal);
        public decimal PorcentajeIVA { get; set; } = 0.15m;
        public decimal MontoIVA => Subtotal * PorcentajeIVA;
        public decimal Total => Subtotal + MontoIVA;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}