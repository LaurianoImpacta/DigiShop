using System;
using System.Collections.Generic;
using System.Text;

namespace DigiShop.Models
{
    public class Produto
    {
        public string Id {get; set;}
        public string Nome { get; set;}
        public decimal Preco { get; set;}
        public int Estoque { get; set;}  
    }
}
