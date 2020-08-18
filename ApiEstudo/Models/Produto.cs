using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiEstudo.Models {
    public class Produto {
        public int ProdutoId {get; set;}
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

                                            
    }
}