using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DigiShop.Models;

namespace DigiShop.DAL
{
    public class ClienteDAL : IClienteDados
    {
        public void Alterar(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("CLIENTE_ALTERAR",
               "@Id", cliente.Id,
               "@Nome", cliente.Nome,
               "@Email", cliente.Email,
               "@Telefone", cliente.Telefone);
        }

        public void Excluir(string Id)
        {
            DbHelper.ExecuteNonQuery("CLIENTE_EXCLUIR", "@Id", Id);
        }

        public void Incluir(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("CLIENTE_INCLUIR",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Email", cliente.Email,
                "@Telefone", cliente.Telefone);
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string Id)
        {
            Cliente cliente = null;
            using(var reader=DbHelper.ExecuteReader("CLIENTE_OBTER_POR_ID", "@Id", Id))
            {
                if(reader.Read())
                {
                    cliente = ObterClienteReader(reader);
                 }
            }
            return cliente;
        }

        public List<Cliente> ObterTodos()
        {
            var lista = new List<Cliente>();
            using (var reader = DbHelper.ExecuteReader("CLIENTE_LISTAR"))
            {
                while (reader.Read())
                {
                    Cliente cliente = ObterClienteReader(reader);
                    lista.Add(cliente);

                }
            }
            return lista;
        }

        private static Cliente ObterClienteReader(SqlDataReader reader)
        {
            var cliente = new Cliente();
            cliente.Id = reader["Id"].ToString();
            cliente.Nome = reader["Nome"].ToString();
            cliente.Email = reader["email"].ToString();
            cliente.Telefone = reader["Telefone"].ToString();
            return cliente;
        }
    }
}
