using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CatalogoApi.Models
{
    public class RespuestaProducto
    {
        [JsonPropertyName("products")]
        public List<Producto> Productos { get; set; } = new List<Producto>();
        public int Total { get; set; }
    }
}
