
using DummyAPI.Models;
using System.Net.Http.Json;

using var client = new HttpClient();
var BASE_URL = "https://dummyjson.com/products";

try
{
    Console.WriteLine("Buscando dados na API..");

    var resultado = await client.GetFromJsonAsync<ProductResponse>(BASE_URL);

    
    if (resultado != null)
    {

        #region Consultas LINQ

        var primeirosVinte = resultado?.Products.Take(10).ToList();
        var produtosGucci = resultado?.Products.Where(x => x.Brand == "Gucci").Take(100).ToList();
        var produtosAcimaDeCemReais = resultado?.Products.Where(x => x.Price < 100m).Take(20).ToList();
        var nomeDosPrimeriosDezProdtuos = resultado?.Products.Select(x => x.Title).Take(10).ToList();
        var primeiroProdutoAcimaDeCemReais = resultado?.Products.FirstOrDefault(x => x.Price > 100m);
        var primeirosDezProdutosOrdenadosPorPreco = resultado?.Products.OrderBy(x => x.Price).Take(10).ToList();

        //Ao utilizar o GroupBy criamos uma nova Lista Enumerable de IGrouping, agrupando os dados pela categoria
        var produtosAgrupadosPelaCategoria = resultado?.Products.GroupBy(x => x.Category).Take(10).ToList();

        //Aqui realizamos um agrupamento pela categoria e utilizamos o select para projetar um novo objeto com os dados da lista
        var nomesDosProdutosSeparadosPorCategoria = resultado?.Products
            .GroupBy(x => x.Category)
            .Select(grupo => new
            {
                NomeDaCategoria = grupo.Key,
                TitulosDosProdutos = grupo.Select(p => p.Title).ToList()

            }).ToList();

        //Aqui realizamos um agrupamento pela categoria e utilizamos o SelectMany para achatar a lista de tags, desta forma tendo apenas 2 listas,
        //uma com a chave (categoria) e a outra com as tags
        var tagsAgrupadosPelaCategoria = resultado?.Products
            .GroupBy(x => x.Category)
            .Select(x => new {
                Categoria = x.Key,
                Tags = x.SelectMany(produto => produto.Tags)
                .Distinct()
                .ToList()
            })
            .ToList();

        var existeAlgumProdutoSemEstoque = resultado?.Products.Any(x => x.Stock == 0);
        var todosOsProdutosTemNotaMaiorQueTres = resultado?.Products.All(x => x.Rating > 3);

        var ordenandoProdutosPeloTituloEPreco = resultado?.Products.OrderBy(x => x.Title).ThenBy(x => x.Price).ToList();


        #endregion

        Console.WriteLine("Resultado obtido: ");

        //if (todosOsProdutosTemNotaMaiorQueTres)
        //{
        //    Console.WriteLine("Todos os produtos tem nota maior que três");
        //}
        //else
        //{
        //    Console.WriteLine("Nem todos os produtos tem nota maior que três");
        //}

        foreach (var produto in ordenandoProdutosPeloTituloEPreco)
        {
            Console.WriteLine("");
            Console.WriteLine(produto.ToString());
        }

        //foreach (var item in tagsAgrupadosPelaCategoria)
        //{
        //    Console.WriteLine("");
        //    Console.WriteLine($"--- Categoria: {item.Categoria} ---");
        //    foreach (var produto in item.Tags)
        //    {
        //        Console.WriteLine(produto.ToString());
        //    }
        //}

        //Console.WriteLine(primeiroProdutoAcimaDeCemReais);
    }
}
catch (HttpRequestException e)
{
    Console.WriteLine($"Erro - Exceção encontrada: {e.Message}");
}
