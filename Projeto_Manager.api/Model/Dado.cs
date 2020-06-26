using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Manager.api.Model
{
    /// <summary>
    /// Classe usada para serialização dos dados json recebidos pelo usuário, retorno de dados serializados e armazenamento no banco de dados sqllite.
    /// </summary>
    public class Dado
    {
        /// <summary>
        /// Propriedade utilizado para controle por chave primaria do banco de dados
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// Propriedade de entrada de usúario Left
        /// </summary>
        [JsonProperty("left")]
        public string Left { get; set; }
        /// <summary>
        /// Propriedade de entrada de usuario Right
        /// </summary>
        [JsonProperty("right")]
        public string Right { get; set; }
        /// <summary>
        /// Propriedade utilizado para identificação de aprovação, reprovação e erros na comparação dos atributos Left e Right
        /// </summary>
        [JsonProperty("situacao")]
        public string Situacao { get; set; }
        /// <summary>
        /// Propriedade utilizado para descrição da aprovação, reprovação e erros na comparação dos atributos Left e Right
        /// </summary>
        [JsonProperty("descricao")]
        public string Descricao { get; set; }
        /// <summary>
        /// Propriedade utilizado para armazenar data e hora da comparação dos atributos Left e Right
        /// </summary>
        [JsonProperty("data_consulta")]
        public DateTime DataHora { get; set; }
    }
}
