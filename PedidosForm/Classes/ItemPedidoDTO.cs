using System.ComponentModel.DataAnnotations;

namespace SistemaPedidosYa.WinForms.Models
{
    public class ItemPedidoDTO
    {
        public Guid ProductoId { get; set; } = Guid.NewGuid();
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        
        public string Categoria { get; set; }
        
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}