using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Manager.api.Model
{
    public class Retorno
    {
        [JsonProperty("situacao")]
        public string Situacao { get; set; }
        [JsonProperty("tipo", NullValueHandling = NullValueHandling.Ignore)]
        public string Tipo { get; set; }
        [JsonProperty("descriçao", NullValueHandling = NullValueHandling.Ignore)]
        public string Descricao { get; set; }
    }
}
