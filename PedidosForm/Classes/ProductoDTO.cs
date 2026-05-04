namespace SistemaPedidosYa.WinForms.Models
{
    public class ProductoDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool EstaDisponible { get; set; } = true;
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
