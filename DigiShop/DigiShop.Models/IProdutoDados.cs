using System;
using System.Collections.Generic;
using System.Text;

namespace DigiShop.Models
{
    public interface IProdutoDados
    {
        void Incluir(Produto produto);
        void Alterar(Produto produto);
        void Excluir(string Id);
        List<Produto> ObterTodos();
        Produto ObterPorId(string Id);
    }
}
