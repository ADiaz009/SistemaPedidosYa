using SistemaPedidosYa.WinForms.Models;
using System.Net.Http.Json;

namespace SistemaPedidosYa.WinForms.Services
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7086/");
        }

        public async Task<List<ProductoDTO>> ObtenerTodoAsync()
        {
            try
            {
                return await _httpClient
                    .GetFromJsonAsync<List<ProductoDTO>>("api/producto")
                    ?? new List<ProductoDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener: {ex.Message}");
                return new List<ProductoDTO>();
            }
        }

        public async Task<bool> CrearProductoAsync(ProductoDTO producto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/producto", producto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ActualizarProductoAsync(Guid id, ProductoDTO producto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/producto/{id}", producto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EliminarProductoAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/producto/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar: {ex.Message}");
                return false;
            }
        }
    }
}