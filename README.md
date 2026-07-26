# 🚀 Praticando LINQ no C# com Dummy API

Este repositório é um mini-projeto dedicado ao estudo prático e aprofundado de **LINQ (Language Integrated Query)** em C#. O objetivo é dominar a manipulação de coleções e dados utilizando uma abordagem declarativa, escrevendo códigos mais limpos, expressivos e eficientes.

Para simular um cenário do mundo real, o projeto consome dados reais (como produtos e categorias) através da [DummyJSON API](https://dummyjson.com/).

---

## 🎯 Objetivo do Projeto

Sair do básico das iterações comuns (como múltiplos laços `foreach` aninhados) e aplicar os 15 métodos mais utilizados do LINQ no dia a dia do desenvolvimento .NET. O projeto foca em transformar estruturas de dados complexas em saídas formatadas e prontas para uso em interfaces de usuário ou outras camadas de uma aplicação.

## 🛠️ Tecnologias e Conceitos Abordados

| Tecnologia / Conceito | Descrição |
|---|---|
| **C# & .NET** | Base do projeto e consumo da API REST. |
| **Dummy API** | Fornecimento de dados aninhados (Produtos, Categorias, Tags). |
| **Projeções** | Uso de `Select` e tipos anônimos para moldar o retorno dos dados. |
| **Achatamento** | Uso de `SelectMany` para extrair e unificar sub-listas. |
| **Agrupamento** | Uso de `GroupBy` para categorizar as respostas da API. |

---

## 🧠 Destaque de Código: Agrupamento e Achatamento

Um dos principais desafios resolvidos neste repositório foi a extração de dados aninhados sem criar "escadinhas de loops" (nested loops). 

O exemplo abaixo demonstra como o projeto agrupa produtos por categoria e utiliza o `SelectMany` para achatar as listas de *Tags*, garantindo uma lista única e sem duplicatas (`Distinct`) para cada categoria:

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
