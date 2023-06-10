using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DigiShop.Models;
using DigiShop.DAL;


namespace DigiShop.Test
{
    /// <summary>
    /// Descrição resumida para PedidoUnitTest
    /// </summary>
    [TestClass]
    public class PedidoUnitTest
    {
        [TestMethod]
        public void Incluir()
        {
            var pedido = new Pedido();
            pedido.Data = DateTime.Now;
            pedido.Cliente = new Cliente() {Id = "9d0f62fe-8bc0-4953-87a4-233e000efe53", Nome = "Armando Abilio Lauriano", Telefone = "(11) 0887-08000", Email= "armando.abilio@gmail.com" };
            pedido.FormaPagamento = FormaPagamentoEnum.Dinheiro;
            pedido.Items = new List<Pedido.Item>();  
            
            var item = new Pedido.Item();

            item.Produto = new Produto() { Id = "002fe1f7-13e7-4a94-bed5-af6276310d75", Nome = "Câmera USB", Preco = 150, Estoque= 450 };
            item.Quantidade = 2;
            item.Ordem = 1;
            item.Preco = 300;

            pedido.Items.Add(item);

            var dal = new PedidoDAL();
            dal.Incluir(pedido);
        }
    }

}
