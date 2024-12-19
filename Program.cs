using System;
using Projeto_Web_Lh_Pets_versão_1;

namespace Projeto_Web_Lh_Pets_versão_1  // Defina o namespace corretamente
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Projeto Web-LH Pets versão 1");

            app.UseStaticFiles();
            app.MapGet("/index", (HttpContext contexto) => {
                contexto.Response.Redirect("index.html", false);
            });

            // Criando a instância de Banco
            Banco dba = new Banco();

            // Endpoint para retornar a lista de clientes como HTML
            app.MapGet("/listaClientes", (HttpContext contexto) =>
            {
                contexto.Response.WriteAsync(dba.GetListaString());
            });

            // Endpoint para exibir a lista no console
            app.MapGet("/imprimirLista", (HttpContext contexto) =>
            {
                dba.ImprimirListaConsole();  // Imprime a lista no console
                contexto.Response.WriteAsync("Lista de clientes impressa no console.");
            });

            app.Run();
        }
    }
}
