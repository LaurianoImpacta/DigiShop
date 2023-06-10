using System;
using System.Collections.Generic;
using System.Text;
using DigiShop.Models;
using System.Data.SqlClient;
using System.Data;

namespace DigiShop.DAL
{
    public class PedidoDAL : IPedidosDados
    {
        public void Aletrar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Pedido pedido)
        {
            var cn = new SqlConnection(DbHelper.conexao);
            var cmd1 = new SqlCommand("PEDIDO_INCLUIR");
            cmd1.Connection = cn;
            cmd1.CommandType = CommandType.StoredProcedure;

            var cmd2 = new SqlCommand("PEDIDO_ITEM_INCLUIR");
            cmd2.Connection = cn;
            cmd2.CommandType = CommandType.StoredProcedure;

            cn.Open();
            var tx = cn.BeginTransaction();

            try
            { 
            cmd1.Transaction = tx;
            cmd2.Transaction = tx;

            cmd1.Parameters.AddWithValue("@DATA", pedido.Data);
            cmd1.Parameters.AddWithValue("@CLIENTE_ID", pedido.Cliente.Id);
            cmd1.Parameters.AddWithValue("@FORMA_PAGAMENTO_ID", pedido.FormaPagamento);

            pedido.Id = Convert.ToInt32(cmd1.ExecuteScalar());

            int ordem = 1;
            cmd2.Parameters.AddWithValue("@PEDIDO_ID", pedido.Id);
            cmd2.Parameters.AddWithValue("@ORDEM", 0);
            cmd2.Parameters.AddWithValue("@QUANTIDADE", 0);
            cmd2.Parameters.AddWithValue("@PRECO",Convert.ToDecimal(0));
            cmd2.Parameters.AddWithValue("@PRODUTO_ID", string.Empty);

            foreach (var item in pedido.Items)
            {
                cmd2.Parameters["@PRODUTO_ID"].Value = item.Produto.Id;
                cmd2.Parameters["@ORDEM"].Value = ordem;
                cmd2.Parameters["@QUANTIDADE"].Value = item.Quantidade;
                cmd2.Parameters["@PRECO"].Value = item.Preco;
                cmd2.ExecuteNonQuery();
                    ordem = ordem + 1;

            }
            tx.Commit();

            }
            catch(Exception ex)
            {
                tx.Rollback();
                throw new Exception("Erro no servidor: " + ex.Message);
            }
            finally 
            { 
                cn.Close();
            } 
        }

        public Pedido ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        private static Pedido ObterPedido(IDataReader reader)
        {
            return new Pedido()
            {
                Id = (int)reader["ID"],
                Data = (DateTime)reader["Data"],
                Cliente = ObterCliente(reader),
                FormaPagamento = (FormaPagamentoEnum)reader["FORMA_PAGAMENTO_ID"]
            };

        }

        private static Cliente ObterCliente(IDataReader reader)
        {
            return new Cliente()
            {
                Id = reader["CLIENTE_ID"].ToString(),
                Nome = reader["ClienteNome"].ToString()
            };
        }



        public List<Pedido> ObterTodos()
        {
            var lista = new List<Pedido>();
            using (var reader = DbHelper.ExecuteReader("PedidoListar"));
            
            return lista;
        }

        public void Excluir(int pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
