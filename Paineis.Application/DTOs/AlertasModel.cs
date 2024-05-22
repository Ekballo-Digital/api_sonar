using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace Paineis.Application.DTOs
{
    public class AlertasModel
    {
        //[JsonProperty("mensagem")]
        public string? Mensagem { get; set; }
        //[JsonProperty("codigoArea")]
        public int CodigoArea { get; set; }
        //[JsonProperty("alerta")]
        public int? Alerta { get; set; }
        //[JsonProperty("prioridade")]
        public int? Prioridade { get; set; }
        //[JsonProperty("cor")]
        public string? Cor { get; set; }

        // Método para desserializar o JSON para uma lista de AlertasModel
        /*public static List<AlertasModel> DeserializeFromJson(string json)
        {
            // Configurar opções do serializador, se necessário
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Opção para tornar as propriedades insensíveis a maiúsculas e minúsculas
            };

            // Desserializar o JSON para uma lista de AlertasModel
            return System.Text.Json.JsonSerializer.Deserialize<List<AlertasModel>>(json, options);
        }*/
    }
}