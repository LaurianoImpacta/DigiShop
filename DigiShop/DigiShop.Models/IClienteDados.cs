using System;
using System.Collections.Generic;
using System.Text;

namespace DigiShop.Models
{
    public interface IClienteDados
    {
        void Incluir(Cliente cliente);
        void Alterar(Cliente cliente);
        void Excluir(string Id);
        List<Cliente> ObterTodos();
        Cliente ObterPorId(string Id);
        Cliente ObterPorEmail(string email);
    }
}
