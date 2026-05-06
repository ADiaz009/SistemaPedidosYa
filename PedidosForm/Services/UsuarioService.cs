using SistemaPedidosYa.WinForms.Models;
using System.Net.Http.Json;

namespace SistemaPedidosYa.WinForms.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        private const string UrlApiUsuarios = "https://localhost:7086/api/usuarios";

        public UsuarioService()
        {
            _httpClient = new HttpClient();
        }

        // LEER: Listar todos los usuarios
        public async Task<List<UsuarioDTO>> ObtenerTodosAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<UsuarioDTO>>(UrlApiUsuarios)
                       ?? new List<UsuarioDTO>();
            }
            catch { return new List<UsuarioDTO>(); }
        }

        // CREAR: Registrar un nuevo empleado
        public async Task<bool> CrearUsuarioAsync(UsuarioDTO usuario)
        {
            var response = await _httpClient.PostAsJsonAsync(UrlApiUsuarios, usuario);
            return response.IsSuccessStatusCode;
        }

        // ACTUALIZAR: Modificar datos de un usuario existente
        public async Task<bool> ActualizarUsuarioAsync(Guid id, UsuarioDTO usuario)
        {
            var response = await _httpClient.PutAsJsonAsync($"{UrlApiUsuarios}/{id}", usuario);
            return response.IsSuccessStatusCode;
        }

        // ELIMINAR: Quitar a un usuario del sistema
        public async Task<bool> EliminarUsuarioAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{UrlApiUsuarios}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}