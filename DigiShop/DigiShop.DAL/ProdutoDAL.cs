using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DigiShop.Models;

namespace DigiShop.DAL
{
    public class ProdutoDAL : IProdutoDados
    {
        public void Alterar(Produto produto)
        {
            DbHelper.ExecuteNonQuery("PRODUTO_ALTERAR",
              "@Id", produto.Id,
              "@Nome", produto.Nome,
              "@Preco", produto.Preco,
              "@Estoque", produto.Estoque);
        }

        public void Excluir(string Id)
        {
            DbHelper.ExecuteNonQuery("PRODUTO_EXCLUIR", "@Id", Id);
        }

        public void Incluir(Produto produto)
        {
            DbHelper.ExecuteNonQuery("PRODUTO_INCLUIR",
              "@Id", produto.Id,
              "@Nome", produto.Nome,
              "@Preco", produto.Preco,
              "@Estoque", produto.Estoque);
        }

        public Produto ObterPorId(string Id)
        {
            Produto produto = null;
            using (var reader = DbHelper.ExecuteReader("PRODUTO_OBTER_POR_ID", "@Id", Id))
            {
                if (reader.Read())
                {
                    produto = ObterProdutoReader(reader);
                }
            }
            return produto;
        }

        public List<Produto> ObterTodos()
        {
            var lista = new List<Produto>();
            using (var reader = DbHelper.ExecuteReader("PRODUTO_LISTAR"))
            {
                while (reader.Read())
                {
                    Produto produto = ObterProdutoReader(reader);
                    lista.Add(produto);

                }
            }
            return lista;
        }

        private static Produto ObterProdutoReader(SqlDataReader reader)
        {
            var produto = new Produto();
            produto.Id = reader["Id"].ToString();
            produto.Nome = reader["Nome"].ToString();
            produto.Preco = reader["Preco"].ToString();
            produto.Estoque = reader["Estoque"].ToString();
            return produto;
        }

    }

}
