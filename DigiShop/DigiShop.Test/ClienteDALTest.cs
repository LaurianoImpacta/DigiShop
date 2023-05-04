using DigiShop.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DigiShop.Test
{
    [TestClass]
    public class ClienteDALTest
    {
        [TestMethod]
        public void ObterPorEmailTest() 
        {
            string email = "cristiano@gmail.com";
            var dal = new ClienteDAL();
        }
    }
}
