using SistemaPedidosYa.WinForms.Models;
using System.Net.Http.Json;

namespace SistemaPedidosYa.WinForms.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private const string UrlAPIAuth = "https://localhost:7086/api/usuarios"; // Ajustá el puerto de tu API

        public AuthService()
        {
            _http = new HttpClient();
        }

        public async Task<UsuarioDTO?> LoginAsync(string username, string password)
        {
            try
            {
                // Enviamos un objeto con los nombres que espera tu API
                var loginData = new { NombreUsuario = username, Password = password };
                var response = await _http.PostAsJsonAsync($"{UrlAPIAuth}/login", loginData);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<UsuarioDTO>();

                return null;
            }
            catch { return null; }
        }
    }
}