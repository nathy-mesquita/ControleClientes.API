using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleClientes.API.Application.Models.ViewModels
{
    public class CepViewModel
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("service")]
        public string Service { get; set; }
    }
}
