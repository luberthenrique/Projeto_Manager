using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Projeto_Manager.api.Controllers;
using Projeto_Manager.api.Data;
using Projeto_Manager.api.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto_Manager.test
{
    /// <summary>
    /// Classe utilizada para implementação de testes de cadastros e comparações dos parâmetros Left e Right
    /// </summary>
    public class DiferencaApiTest
    {
        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new Dado
                {
                    Left = "Teste 1 insert Left",
                    Right = "Teste 1 insert Rigth"
                }
            },
            new object[]
            {
                new Dado
                {
                    Left = "Teste 2 insert Left",
                    Right = "Teste 2 insert Rigth"
                }
            },
            new object[]
            {
                new Dado
                {
                    Left = "Teste 3 insert Left",
                    Right = "Teste 3 insert Rigth"
                }
            }
        };

        /// <summary>
        /// Método utilizado para verificação de erro forçado para parâmetro Right vazio
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Erro_RigthVazio()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;
                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                //Verificar Erro LEFT Vaziio
                using (var context = new ApplicationDbContext(options))
                {
                    var dado = new Dado() { Left = "Teste 1 insert Left" };
                    var service = new DiferencaController(context);

                    var retorno = await service.Post_Left(dado);

                    Assert.IsType<Retorno>(retorno.Value);
                    retorno = await service.Get_Diferenca();
                    Assert.Equal("RIGHT_VAZIO", ((Retorno)retorno.Value).Situacao);

                }
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Método utilizado para verificação de erro forçado para parâmetro Left vazio
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Erro_LeftVazio()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;
                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                //Verificar Erro LEFT Vaziio
                using (var context = new ApplicationDbContext(options))
                {
                    var dado = new Dado() { Left = "Teste 1 insert Right" };
                    var service = new DiferencaController(context);

                    var retorno = await service.Post_Right(dado);

                    Assert.IsType<Retorno>(retorno.Value);
                    retorno = await service.Get_Diferenca();
                    Assert.Equal("LEFT_VAZIO", ((Retorno)retorno.Value).Situacao);

                }
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Método utilizado para verificação de sucesso na comparação de dados idênticos para os parâmetros Left e Right
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Valores_Identicos()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;
                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                //Verificar Erro LEFT Vaziio
                using (var context = new ApplicationDbContext(options))
                {
                    var dado = new Dado() { Left = "Teste 1 insert valores", Right = "Teste 1 insert valores" };
                    var service = new DiferencaController(context);

                    await service.Post_Left(dado);
                    await service.Post_Right(dado);

                    var retorno = await service.Get_Diferenca();

                    Assert.IsType<Dado>(retorno.Value);
                    Assert.Equal("APROVADO", ((Dado)retorno.Value).Situacao);

                }
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Método utilizado para verificação de erro forçado na comparação de dados de tamanhos diferêntes para os parâmetros Left e Right
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Valores_TamanhosDiferentes()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;
                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                //Verificar Erro LEFT Vaziio
                using (var context = new ApplicationDbContext(options))
                {
                    var dado = new Dado() { Left = "aaaaabbbbbccccc", Right = "aaaaabbbbbcccc" };
                    var service = new DiferencaController(context);

                    await service.Post_Left(dado);
                    await service.Post_Right(dado);

                    var retorno = await service.Get_Diferenca();

                    Assert.IsType<Dado>(retorno.Value);
                    Assert.Equal("REPROVADO", ((Dado)retorno.Value).Situacao);
                    Assert.Equal("Valor Left e Right pussuem tamanhos diferentes!", ((Dado)retorno.Value).Descricao);

                }
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Método utilizado para verificação de erro forçado na comparação de dados de valores diferêntes para os parâmetros Left e Right
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Valores_ValoresDiferentes()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;
                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                //Verificar Erro LEFT Vaziio
                using (var context = new ApplicationDbContext(options))
                {
                    var dado = new Dado() { Left = "testando minha aplicaçaa", Right = "testando minna aplicacão" };
                    var service = new DiferencaController(context);

                    await service.Post_Left(dado);
                    await service.Post_Right(dado);

                    var retorno = await service.Get_Diferenca();

                    Assert.IsType<Dado>(retorno.Value);
                    Assert.Equal("REPROVADO", ((Dado) retorno.Value).Situacao);
                    Assert.Equal("Valor Left e Right possuem alteracao do(s) carastere(s) h/n - çaa/cão nos respectivos caracteres de número 13 - 22", ((Dado)retorno.Value).Descricao);

                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
