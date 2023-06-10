using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiShop.BLL;
using DigiShop.DAL;
using DigiShop.Models;

namespace DigiShop.UI.Web
{
    public static class AppContainer
    {
        public static IClienteDados ObterClienteBLL()
        {
            var dal = new ClienteDAL();
            var bll = new ClienteBLL();

            return bll;
        }

        public static IProdutosDados ObterProdutoBLL()
        {
            var dal = new ProdutoDAL();
            var bll = new ProdutoBLL(dal);
            return bll;

        }


    }
}