using System.Net;
using UMFG.MinhaPrimeira.API.Dominio.DTO;
using UMFG.MinhaPrimeira.API.Dominio.Entidades;
using UMFG.MinhaPrimeira.API.Dominio.Interfaces.Servicos;
using UMFG.MinhaPrimeira.API.Servico.Classes;

namespace UMFG.MinhaPrimeira.API.Apresentacao.MinimalAPI
{
    public class Program
    {
        private static IProdutoServico _servico 
            = new ProdutoServico();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("v1/produto", ObterTodosProdutos);
            app.MapGet("v1/produto/{ean}", ObterProdutoPorEan);
            app.MapPost("v1/produto/", CadastrarProduto);
            app.MapDelete("v1/produto/{ean}", RemoverProdutoPorEan);

            app.Run();
        }

        private static async Task RemoverProdutoPorEan(HttpContext context)
        {
            try
            {
                if (!context.Request.RouteValues.TryGetValue("ean", out object ean))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync("Código ean não informado!");

                    return;
                }

                _servico.RemoverPorEan(ean.ToString());
                await context.Response.WriteAsync($"Produto {ean} removido com sucesso!");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
        }

        private static async Task CadastrarProduto(HttpContext context)
        {
            try
            {
                var produto = await context.Request.ReadFromJsonAsync<ProdutoDto>();

                if (produto == null)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync("Não foi possivel efetuar o cadastro! Verifique.");
                    
                    return;
                }

                context.Response.StatusCode = (int)HttpStatusCode.Created;

                await context.Response.WriteAsJsonAsync(_servico.CadastrarProduto(new Produto(produto.EAN,
                    produto.Descricao,
                    produto.PrecoCusto,
                    produto.PrecoVenda,
                    produto.Usuario)));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
        }

        private static async Task ObterProdutoPorEan(HttpContext context)
        {
            try
            {
                if (!context.Request.RouteValues.TryGetValue("ean", out object ean))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync("Código ean não informado!");

                    return;
                }

                await context.Response.WriteAsJsonAsync(_servico.ObterPorEan(ean.ToString()));
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
        }

        private static async Task ObterTodosProdutos(HttpContext context) 
            => await context.Response.WriteAsJsonAsync(_servico.ObterTodos());
    }
}