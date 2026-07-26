# 🚀 Praticando LINQ no C# com Dummy API

Este repositório é um mini-projeto dedicado ao estudo prático e aprofundado de **LINQ (Language Integrated Query)** em C#. O objetivo é dominar a manipulação de coleções e dados utilizando uma abordagem declarativa, escrevendo códigos mais limpos, expressivos e eficientes.

Para simular um cenário do mundo real, o projeto consome dados reais (como produtos e categorias) através da [DummyJSON API](https://dummyjson.com/) utilizando `HttpClient`.

---

## 🎯 Objetivo do Projeto

Sair do básico das iterações comuns (como múltiplos laços `foreach` aninhados) e aplicar os principais métodos do LINQ no dia a dia do desenvolvimento .NET. O projeto foca em extrair, transformar, ordenar e validar estruturas de dados complexas prontas para uso em interfaces de usuário ou outras camadas de uma aplicação.

---

## 🛠️ Métodos LINQ Explorados

Este projeto cobre um vasto "cinto de utilidades" do LINQ. Abaixo estão os métodos implementados e estudados:

### 🔍 Filtros e Buscas
* **`Where`**: Filtragem de coleções baseada em condições (ex: produtos por marca ou faixa de preço).
* **`Take`**: Limitação do número de registros retornados (essencial para paginação).
* **`FirstOrDefault`**: Busca segura do primeiro elemento que satisfaz uma condição, retornando nulo caso não encontre (evitando exceções).

### 📐 Projeção e Transformação
* **`Select`**: Projeção de dados para criar novos formatos de saída (incluindo o uso de *Tipos Anônimos*).
* **`SelectMany`**: Achatamento (*flattening*) de coleções aninhadas (transformando `List<List<T>>` em `List<T>`).
* **`Distinct`**: Remoção de registros duplicados em listas recém-achatadas.

### 📦 Agrupamento e Ordenação
* **`GroupBy`**: Separação de dados em categorias lógicas (criando listas baseadas em uma chave comum).
* **`OrderBy` e `ThenBy`**: Aplicação de ordenação composta (ex: ordenar primeiro por título de forma alfabética e, em caso de empate, ordenar por preço).

### ✅ Validações Booleanas Rápidas
* **`Any`**: Retorna `true` se *pelo menos um* elemento atender à regra (ex: verificar se há produtos com estoque zerado).
* **`All`**: Retorna `true` apenas se *todos* os elementos atenderem à regra (ex: garantir que todos os produtos tenham uma nota de avaliação mínima).

---

## 🧠 Destaque de Código: Agrupamento e Achatamento

Um dos principais desafios resolvidos neste repositório foi a extração de dados aninhados sem criar "escadinhas de loops" (nested loops). 

O exemplo abaixo demonstra como o projeto agrupa produtos por categoria e utiliza o `SelectMany` para achatar as listas de *Tags*, garantindo uma lista única e sem duplicatas para cada categoria:

```csharp
var tagsAgrupadosPelaCategoria = resultado?.Products
    .GroupBy(x => x.Category)
    .Select(x => new 
    {
        Categoria = x.Key,
        Tags = x.SelectMany(produto => produto.Tags)
                 .Distinct()
                 .ToList() 
    })
    .ToList();
