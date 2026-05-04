using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SistemaPedidosYa.WinForms.Models; // Asegúrate de que apunte a tus DTOs

namespace SistemaPedidosYa.WinForms.Services
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService()
        {
            _httpClient = new HttpClient();
            // Revisa que este puerto coincida con el que lanza tu API en la UNI
            _httpClient.BaseAddress = new Uri("https://localhost:7086/api/producto");
        }

        // --- MÉTODOS DEL CRUD ---

        public async Task<List<ProductoDTO>> ObtenerTodoAsync()
        {
            try
            {
                var productos = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/productos");
                return productos ?? new List<ProductoDTO>();
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
                // Enviamos el objeto completo (incluyendo ImagenUrl)
                var response = await _httpClient.PostAsJsonAsync("api/productos", producto);
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
                // PUT: api/productos/{id}
                var response = await _httpClient.PutAsJsonAsync($"api/productos/{id}", producto);
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
                // DELETE: api/productos/{id}
                var response = await _httpClient.DeleteAsync($"api/productos/{id}");
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