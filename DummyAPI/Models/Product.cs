using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DummyAPI.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("stock")]
        public int Stock { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("discountPercentage")]
        public double DiscountPercentage { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        public override string ToString()
        {
            string tagsFormatadas = Tags != null ? string.Join(", ", Tags) : "Sem tags";

            return $"[{Id:000}] {Title} - ${Price:F2} (Estoque: {Stock} | Nota: {Rating})\n" +
                   $"      Categoria: {Category} | Marca: {Brand ?? "Sem Marca"}\n" +
                   $"      Tags: [{tagsFormatadas}]\n" +
                   $"      --------------------------------------------------";
        }


    }
}
