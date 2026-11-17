using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using CatalogoApi.Models;

namespace CatalogoApi.Services
{
    static class ProductoService
    {
        private const string Url = "https://dummyjson.com/products/?limit=20&select=title,price,thumbnail";

        private static readonly HttpClient cliente = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
        private static readonly JsonSerializerOptions opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static async Task<List<Producto>> ObtenerProductosAsync()
        {
            string json=await cliente.GetStringAsync(Url);
            RespuestaProducto? respuesta = JsonSerializer.Deserialize<RespuestaProducto>(json, opciones);
            return respuesta?.Productos ?? new List<Producto>();
        }
    }
}
