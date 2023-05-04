using System;
using System.Collections.Generic;
using System.Text;
using DigiShop.Models;
using DigiShop.DAL;

namespace DigiShop.BLL
{
    public class ProdutoBLL : IProdutoDados
    {
        private ProdutoDAL dal;
        public ProdutoBLL()
        {
            this.dal = new ProdutoDAL();
        }
        public void Alterar(Produto produto)
        {
            Validar(produto);
            if (string.IsNullOrEmpty(produto.Id))
            {
                throw new Exception("O Id deve ser informado")
;
            }
            dal.Alterar(produto);
        }

        public void Excluir(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("O Id deve ser informado")
;
            }
            dal.Excluir(Id);
        }

        public void Incluir(Produto produto)
        {
            Validar(produto);
            if (string.IsNullOrEmpty(produto.Id))
            {
                produto.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(produto);
        }

        private static void Validar(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
            {
                throw new ApplicationException("O nome deve ser informado");
            }
        }

        public Produto ObterPorId(string Id)
        {
            return dal.ObterPorId(Id);
        }

        public List<Produto> ObterTodos()
        {

            var lista = dal.ObterTodos();
            return lista;
        }
    }
}
