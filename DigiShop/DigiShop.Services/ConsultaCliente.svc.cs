using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DigiShop;


namespace DigiShop.Services
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "ConsultaCliente" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione ConsultaCliente.svc ou ConsultaCliente.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class ConsultaCliente : IConsultaCliente
    {
        public ClienteInfo ConsultarPoremail(string chave, string email)
        {
            if(chave != "1234567890@!")
            {
                return null;
            }

            ClienteInfo = clienteInfo = null;

            var bll = new ClienteBLL();
            var cliente = bll.ObterPorEmail();
            if (cliente == null ) 
            {
                return null;
            }
            else
            {
                var clienteInfo = new ClienteInfo()
                {
                    Nome = cliente.Nome,
                    email = cliente.Email,
                    Telefone = cliente.Telefone,
                };
            }
            return clienteInfo;
        }

        ClienteInfo IConsultaCliente.ConsultarPorEmail(string chave, string email)
        {
            throw new NotImplementedException();
        }
    }

    internal class ClienteInfo
    {
        public ClienteInfo()
        {
        }

        public object Nome { get; set; }
        public object email { get; set; }
        public object Telefone { get; set; }
    }
}
