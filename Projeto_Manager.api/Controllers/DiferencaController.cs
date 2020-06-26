using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Manager.api.Model;
using DiffMatchPatch;
using Projeto_Manager.api.Data;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Manager.api.Controllers
{
    /// <summary>
    /// Classe usada para implementação dos endpoints junto com suas respectivas lógicas 
    /// </summary>
    [Route("v1/diff")]
    [ApiController]
    public class DiferencaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DiferencaController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método utilizado para identificar diferenças em dois parâmetros binários previamente cadastrados no sistema
        /// </summary>
        /// <returns>Retorna um objeto do tipo Retorno ou Dado, a depender de possíveis preenchimentos incompletos ou da comparação efetuada</returns>
        [HttpGet]
        public async Task<ActionResult<object>> Get_Diferenca()
        {
            //Pesquisa no banco de dados o último dado existente
            var _dado = await _context.Dado.Where(c => string.IsNullOrEmpty(c.Situacao)).LastOrDefaultAsync();
            //E caso não exista, instancia uma nova classe Dado
            _dado = _dado == null ? new Dado() : _dado;

            if (string.IsNullOrEmpty(_dado.Left))
            {
                return new Retorno { Situacao = "LEFT_VAZIO", Descricao = "Valor Left ainda não cadastrado!" };
            }
            else if (string.IsNullOrEmpty(_dado.Right))
            {
                return new Retorno { Situacao = "RIGHT_VAZIO", Descricao = "Valor Right ainda não cadastrado!" };
            }
            else
            {
                var retorno = new Retorno();
                if (_dado.Left.Equals(_dado.Right))
                {
                    retorno = new Retorno { Situacao = "APROVADO", Descricao = "Valor Left e Right são idênticos!" };
                }
                else if (_dado.Left.ToString().Length != _dado.Right.ToString().Length)
                {
                    retorno = new Retorno { Situacao = "REPROVADO", Descricao = "Valor Left e Right pussuem tamanhos diferentes!" };
                }
                else
                {
                    var dmp = DiffMatchPatchModule.Default;
                    var diffs = dmp.DiffMain(_dado.Left, _dado.Right);

                    var lengthAlterado = diffs.Where(c => c.Operation == Operation.Equal).ToList();
                    var alteracaoLeft = diffs.Where(c => c.Operation == Operation.Delete).ToList();
                    var alteracaoRight = diffs.Where(c => c.Operation == Operation.Insert).ToList();

                    var texto = "Valor Left e Right possuem alteração do(s) carastere(s) ";

                    for (int i = 0; i < alteracaoLeft.Count(); i++)
                    {
                        texto+= alteracaoLeft[i].Text + "/" + alteracaoRight[i].Text + (i < alteracaoLeft.Count() - 1 ? " - " : "");
                    }                    

                    texto = texto + " no(s) respectivo(s) caractere(s) de posição ";
                    var legth = 0;

                    for (int i = 0; i < lengthAlterado.Count(); i++)
                    {
                        legth+= lengthAlterado[i].Text.Length;
                        texto+= (legth + 1)  + (i < lengthAlterado.Count() - 1 ? " - " : "");

                        legth += alteracaoLeft[i].Text.Length;
                    }

                    retorno = new Retorno { Situacao = "REPROVADO", Descricao = texto};
                }

                _dado.Situacao = retorno.Situacao;
                _dado.Descricao = retorno.Descricao;
                _dado.DataHora = DateTime.Now;

                _context.Dado.Update(_dado);
                await _context.SaveChangesAsync();
                return _dado;
            }

        }

        /// <summary>
        /// Método utilizado para consultar todas os resultados de alterações já realizadas
        /// </summary>
        /// <returns>/// <returns>Retorna uma lista de objetos do tipo Dado que já foram comparadas anteriormente e estão salvas no BD</returns>
        [HttpGet]
        [Route("comparacoes")]
        public async Task<ActionResult<object>> Get_Comparacoes()
        {
            return await _context.Dado.ToListAsync();            
        }

        /// <summary>
        /// Método utilizado para gravar o parametro Left para sua posterior comparação
        /// </summary>
        /// <param name="dado">Classe serializada para entrada do parametro Left</param>
        /// <returns>Retorna um objeto do tipo Retorno com mensagem de sucesso ou erro em seu cadastro</returns>
        [HttpPost]
        [Route("left")]
        public async Task<ActionResult<object>> Post_Left(Dado dado)
        {
            //Verifica se o parâmetro left recebido não está nulo ou vazio
            if (!string.IsNullOrEmpty(dado.Left))
            {
                //Caso exista dados no banco que ainda não foram comparadas a diferença, subistituir o valor Left mesmo, se não adicionar um novo dado no banco
                var dados = await _context.Dado.Where(c => string.IsNullOrEmpty(c.Situacao)).ToListAsync();
                if (dados.Any())
                {
                    var dadoBd = dados.Last();
                    dadoBd.Left = dado.Left;
                    _context.Dado.Update(dadoBd);
                }
                else
                {
                    var dadoBd = new Dado { Left = dado.Left };
                    await _context.Dado.AddAsync(dadoBd);
                }

                await _context.SaveChangesAsync();

                return new Retorno { Situacao = "SUCESSO", Descricao = "Valor Left cadastrado com sucesso!" };
            }
            else
            {
                //Retorna mensagem de erro caso o mesmo esteja nulo ou vazio
                return new Retorno { Situacao = "ERRO", Descricao = "Valor Left nulo ou vazio!" };
            }

        }

        /// <summary>
        /// Método utilizado para gravar o parametro Right para sua posterior comparação
        /// </summary>
        /// <param name="dado">Classe serializada para entrada do parametro Right</param>
        /// <returns>Retorna um objeto do tipo Retorno com mensagem de sucesso ou erro em seu cadastro</returns>
        [HttpPost]
        [Route("right")]
        public async Task<ActionResult<object>> Post_Right(Dado dado)
        {
            //Verifica se o parâmetro right recebido não está nulo ou vazio
            if (!string.IsNullOrEmpty(dado.Right))
            {
                //Caso exista dados no banco que ainda não foram comparadas a diferença, subistituir o valor right mesmo, se não adicionar um novo dado no banco
                var dados = await _context.Dado.Where(c => string.IsNullOrEmpty(c.Situacao)).ToListAsync();
                if (dados.Any())
                {
                    var dadoBd = dados.Last();
                    dadoBd.Right = dado.Right;
                    _context.Dado.Update(dadoBd);
                }
                else
                {
                    var dadoBd = new Dado { Right = dado.Right };
                    await _context.Dado.AddAsync(dadoBd);
                }

                await _context.SaveChangesAsync();

                return new Retorno { Situacao = "SUCESSO", Descricao = "Valor Right cadastrado com sucesso!" };
            }
            else
            {
                //Retorna mensagem de erro caso o mesmo esteja nulo ou vazio
                return new Retorno { Situacao = "ERRO", Descricao = "Valor Right nulo ou vazio!" };
            }
        }
    }
}