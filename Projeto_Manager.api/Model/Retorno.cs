using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Manager.api.Model
{
    /// <summary>
    /// Classe usada para serialização de retorno dos status de armazenamento dos parametros Left e Right
    /// </summary>
    public class Retorno
    {
        /// <summary>
        /// Propriedade utilizado para identificação de sucesso ou erros no preenchimento ou comparação dos atributos Left e Right
        /// </summary>
        [JsonProperty("situacao")]
        public string Situacao { get; set; }
        /// <summary>
        /// Propriedade utilizado para identificação do tipo de erro ocorrido
        /// </summary>
        [JsonProperty("tipo", NullValueHandling = NullValueHandling.Ignore)]
        public string Tipo { get; set; }
        /// <summary>
        /// Propriedade utilizado para descrição do sucesso ou erros no preenchimento ou comparação dos atributos Left e Right
        /// </summary>
        [JsonProperty("descriçao", NullValueHandling = NullValueHandling.Ignore)]
        public string Descricao { get; set; }
    }
}
