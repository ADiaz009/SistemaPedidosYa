using SistemaPedidosYa.WinForms.Models;

namespace SistemaPedidosYa.WinForms.Utils
{
    public static class Sesion
    {
        // Aquí guardaremos al usuario que hizo login exitoso
        public static UsuarioDTO? UsuarioActual { get; set; }
    }
}