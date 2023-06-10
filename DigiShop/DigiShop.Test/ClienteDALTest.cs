using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DigiShop.DAL;
using DigiShop.Models;

namespace DigiShop.Test
{
    [TestClass]
    public class ClienteDALTest
    {
        [TestMethod]
        public void ObterPorEmailNullTest()
        {
            string email = null;
            var dal = new ClienteDAL();
            bool ok = false;
            try
            {
                var cliente = dal.ObterPorEmail(email);

            }
            catch (ApplicationException ex) 
            {
                if(ex.Message == "O email deve ser informado")
                {
                    ok = true;
                }
            
            }catch (Exception ex) 
            {
                Console.WriteLine("Erro no Servvidor: Parâmetro não informado" + ex.Message);
            }

            Assert.IsTrue(ok, "Deveria ter disparado um applicationException com a mensagem: Email dave ser informado");  
        }


        [TestMethod]
        public void ObterPorEmailTest()
        {
            string email = "felipe@gmail.com";
            var dal = new ClienteDAL();
            var cliente = dal.ObterPorEmail(email);

            if(cliente != null) 
            {
                Console.WriteLine("Cliente encontrado");
                Console.WriteLine(cliente.Id);
                Console.WriteLine(cliente.Nome);
                Console.WriteLine(cliente.Email);
                Console.WriteLine(cliente.Telefone);
            }


            Assert.IsNotNull(cliente != null, "Deveria ter retornado uma instacia do cliente!");
        }
        
    }
}
