using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoApi.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public double Price { get; set; }
        public string Thumbnail { get; set; } = "";
    }
}
