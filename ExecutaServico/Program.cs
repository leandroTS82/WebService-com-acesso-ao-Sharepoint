using System;

namespace ExecutaServico
{
    class Program
    {
        static void Main(string[] args)
        {
            webService_Sharepoint.WebServiceSharepoint webService = new webService_Sharepoint.WebServiceSharepoint();
            var retorno = webService.ObtemLista();
            Console.WriteLine($"Retornado {retorno.Itens.Length} itens e {retorno.Erros.Length} erros");
            if (retorno.Itens.Length > 0)
            {
                foreach (var item in retorno.Itens)
                {
                    Console.WriteLine($"Titulo do item: {item.Title}\n ID da pessoa: {item.ID_Pessoa}\n Nome da Pessoa: {item.Nome_Pessoa} ");
                }
            }
            Console.ReadKey();
        }
    }
}
