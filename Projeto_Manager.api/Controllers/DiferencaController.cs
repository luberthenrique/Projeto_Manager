using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Manager.api.Model;

namespace Projeto_Manager.api.Controllers
{
    [Route("v1/diff")]
    [ApiController]
    public class DiferencaController : ControllerBase
    {
        private static Dado dado = new Dado();
        public DiferencaController()
        {

        }
        [HttpGet]
        public async Task<ActionResult<object>> Get_Diferenca()
        {
            if (dado.Left == 0)
            {
                return new Retorno { Situacao = "INVÁLIDO", Descricao = "Dado Left ainda não cadastrado!" };
            }
            else if (dado.Right == 0)
            {
                return new Retorno { Situacao = "INVÁLIDO", Descricao = "Dado Rigth ainda não cadastrado!" };
            }
            else
            {
                if (dado.Left.Equals(dado.Right))
                {
                    return new Retorno { Situacao = "SUCESSO", Descricao = "Dado Left e Right são idênticos!" };
                }
                else if (dado.Left.ToString().Length != dado.Right.ToString().Length)
                {
                    return new Retorno { Situacao = "ERRO", Descricao = "Dado Left e Right pussuem tamanhos diferentes!" };
                }
                else
                {
                    return new Retorno { Situacao = "ERRO", Descricao = "Dado Left e Right pussuem tamanhos diferentes!" };
                }
            }

           
        }

        [HttpPost]
        [Route("left ")]
        public async Task<ActionResult<object>> Post_Left(double valor)
        {
            dado.Left = valor;

            return new Retorno { Situacao = "SUCESSO", Descricao = "Dado Left cadastrado com sucesso!" };
        }

        [HttpPost]
        [Route("right")]
        public async Task<ActionResult<object>> Post_Right(double valor)
        {
            dado.Right = valor;

            return new Retorno { Situacao = "SUCESSO", Descricao = "Dado Right cadastrado com sucesso!" };
        }
    }
}