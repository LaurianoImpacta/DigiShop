using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigiShop.BLL;
using DigiShop.Models;
using DigiShop.UI.Web.Models;

namespace DigiShop.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        [HttpPost]
        public ActionResult Incluir(PedidoViewModel pedido)
        {
                var bllProduto = AppContainer.ObterProdutoBLL();
                var bllCliente = AppContainer.ObterClienteBLL();

                pedido.Clientes = bllCliente.ObterTodos();
                pedido.Produtos = bllProduto.ObterTodos();
                pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();

            if (Request.Form["incluirProduto"] == "Incluir")
            {
                var item = new PedidoViewModel.Item();
                item.ProdutoId = pedido.NovoItemProdutoId;
                item.Quantidade = pedido.NovoItemQuantidade;

                var produto=bllProduto.ObterPorId(item.ProdutoId);
                item.Valor = produto.Preco;
                item.ProdutoNome = produto.Nome;
                pedido.Items.Add(item);


            }
            else if (Request.Form["Gravar"] == "Gravar")
            {
                //var bll = AppContainer.ObterPedidoBLL();
            }

            return View(pedido);
        }
        
        public ActionResult Incluir()
        {

            var bllCliente = AppContainer.ObterClienteBLL();
            var bllProduto = AppContainer.ObterProdutoBLL();


            var pedido = new PedidoViewModel();
                pedido.Clientes = bllCliente.ObterTodos();    
                pedido.Produtos= bllProduto.ObterTodos();



                pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();
            
            


            return View(pedido);
        }
    }
}