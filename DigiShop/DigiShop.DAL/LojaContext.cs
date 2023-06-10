using DigiShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Text;

namespace DigiShop.DAL
{
    public class LojaContext:DbContext

    {
        internal object Produtos;

        public LojaContext():base(DbHelper.conexao)
        {

        }

        public DbSet<Produto> Produto { get; set; }




    }
}
