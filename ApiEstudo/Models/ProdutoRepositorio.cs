using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;

namespace ApiEstudo.Models {
    public class ProdutoRepositorio : IprodutoRepositorio {
        private List<Produto> produtos = new List<Produto>();
        private int _nextId = 1;

        public ProdutoRepositorio() {

            Add(new Produto { ProdutoNome = "Heineken", Quantidade = 100, Preco = 12.99 });
            Add(new Produto { ProdutoNome = "Skoll", Quantidade = 500, Preco = 5.99 });
            Add(new Produto { ProdutoNome = "Budweiser", Quantidade = 100, Preco = 10.99 });
            Add(new Produto { ProdutoNome = "Stella Artois", Quantidade = 150, Preco = 11.99 });
        }

        public Produto Add(Produto item) {
            if (item == null) {
                throw new ArgumentNullException("item");

            }
            item.ProdutoId = _nextId++;
            produtos.Add(item);
            return item;

        }

        public Produto Get(int id) {
            return produtos.Find(p => p.ProdutoId == id);
        }

       

        public IEnumerable<Produto> GetAll() {
            return produtos;
        }

        public void Remove(int id) {
            produtos.RemoveAll(p => p.ProdutoId == id);
        }

        public bool Update(Produto item) {
            if (item == null) {
                throw new ArgumentException("item");
            }
            int index = produtos.FindIndex(p => p.ProdutoId == item.ProdutoId);
            if (index == -1) {
                return false;
            }
            produtos.RemoveAt(index);
            produtos.Add(item);
            return true;
        }
    }
}




































        