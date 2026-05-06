using SistemaPedidosYa.WinForms.Models;
using System.Net.Http.Json;

namespace SistemaPedidosYa.WinForms.Services
{
    public class PedidoService
    {
        private readonly HttpClient _httpClient;
        // Puerto 7086 para ser consistentes con tu UsuarioService
        private const string UrlApiPedidos = "https://localhost:7086/api/pedidos";

        public PedidoService()
        {
            _httpClient = new HttpClient();
        }

        // LEER: Obtener todos los detalles de pedidos
        public async Task<List<PedidosDetalleDTO>> ObtenerTodosAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<PedidosDetalleDTO>>(UrlApiPedidos)
                       ?? new List<PedidosDetalleDTO>();
            }
            catch { return new List<PedidosDetalleDTO>(); }
        }

        // CREAR: El que faltaba, usando PedidosDetalleDTO
        public async Task<bool> CrearPedidoAsync(PedidosDetalleDTO detalle)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(UrlApiPedidos, detalle);
                return response.IsSuccessStatusCode;
            }
            catch { return false; }
        }

        // ACTUALIZAR: Modificar un detalle existente
        public async Task<bool> ActualizarPedidoAsync(Guid id, PedidosDetalleDTO detalle)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{UrlApiPedidos}/{id}", detalle);
                return response.IsSuccessStatusCode;
            }
            catch { return false; }
        }

        // ELIMINAR: Borrar registro
        public async Task<bool> EliminarPedidoAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{UrlApiPedidos}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch { return false; }
        }

        // --- ALIAS PARA COMPATIBILIDAD CON TU CODIGO ACTUAL ---
        public async Task<List<PedidosDetalleDTO>> GetPedidosAsync() => await ObtenerTodosAsync();
        public async Task<bool> ActualizarEstadoAsync(Guid id, PedidosDetalleDTO detalle) => await ActualizarPedidoAsync(id, detalle);
    }
}