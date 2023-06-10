using System;
using System.Collections.Generic;
using System.Text;

namespace DigiShop.Models
{
    public interface IPedidosDados
    {
        void Incluir(Pedido pedido);
        void Aletrar(Pedido pedido);
        void Excluir(int pedidoId);

        List<Pedido> ObterTodos();
        Pedido ObterPorId(int id);

    }
}
