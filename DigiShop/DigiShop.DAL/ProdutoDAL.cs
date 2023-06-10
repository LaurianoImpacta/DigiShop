using DigiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiShop.DAL
{
    public class ProdutoDAL : IProdutosDados
    {
        private LojaContext db = new LojaContext();
        public void Alterar(Produto produto)
        {
           var produtoOriginal = ObterPorId(produto.Id);
            if(produtoOriginal != null) 
            {
                produtoOriginal.Nome = produto.Nome;
                produtoOriginal.Preco = produto.Preco;
                produtoOriginal.Estoque = produto.Estoque;
                db.SaveChanges();
            }
        }

        public void Excluir(string id)
        {
            var produto = ObterPorId(id);
            if(produto != null)
            {
                db.Produto.Remove(produto);
                db.SaveChanges();
            }
        }

        public void Incluir(Produto produto)
        {

           
            db.Produto.Add(produto);
            db.SaveChanges();
        }

        public Produto ObterPorId(string id)
        {
            var produto = db.Produto.Where(m=>m.Id == id).FirstOrDefault();
            return produto;
        }

        public List<Produto> ObterTodos()
        {
            return db.Produto.ToList();
        }
    }
}
