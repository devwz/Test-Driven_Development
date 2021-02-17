using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test_Driven_Development
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        public Produto(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }

    public class CarrinhoDeCompras
    {
        public List<Produto> Produtos;

        public CarrinhoDeCompras()
        {
            Produtos = new List<Produto>();
        }

        public void Adiciona(Produto produto)
        {
            Produtos.Add(produto);
        }
    }

    public class MaiorEMenor
    {
        public Produto Menor { get; set; }
        public Produto Maior { get; set; }

        public void Encontra(CarrinhoDeCompras carrinho)
        {
            foreach (var produto in carrinho.Produtos)
            {
                if (Menor == null || produto.Valor < Menor.Valor)
                {
                    Menor = produto;
                }
                if (Maior == null || produto.Valor > Maior.Valor)
                {
                    Maior = produto;
                }
            }
        }
    }

    [TestClass]
    public class TestaMaiorEMenor
    {
        [TestMethod]
        public void ApenasUmProduto()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            carrinho.Adiciona(new Produto("Geladeira", 450.0));

            MaiorEMenor algoritmo = new MaiorEMenor();
            algoritmo.Encontra(carrinho);

            Assert.AreEqual("Geladeira", algoritmo.Menor.Nome);
            Assert.AreEqual("Geladeira", algoritmo.Maior.Nome);
        }
    }
}
