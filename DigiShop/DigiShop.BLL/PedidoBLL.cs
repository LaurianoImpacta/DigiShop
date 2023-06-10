using System;
using System.Collections.Generic;
using System.Text;
using DigiShop.Models;
using DigiShop.DAL;

namespace DigiShop.BLL
{
    public class PedidoBLL : IPedidosDados
    {
        private IPedidosDados dal;
        public PedidoBLL(IPedidosDados pedidosDados)
        {
            this.dal = pedidosDados;
        }
        public void Aletrar(Pedido pedido)
        {
            dal.Aletrar(pedido);
        }

        public void Excluir(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int pedidoId)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Pedido pedido)
        {
            dal.Incluir(pedido);
        }

        public Pedido ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
