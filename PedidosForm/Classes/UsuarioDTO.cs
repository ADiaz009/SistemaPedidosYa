namespace SistemaPedidosYa.WinForms.Models
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = "Mesero";
        public bool Activo { get; set; } = true;
    }
}