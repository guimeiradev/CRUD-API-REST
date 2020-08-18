using ApiEstudo.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiEstudo.Controllers
{
    public class ProdutoController : ApiController
    {
        static readonly IprodutoRepositorio repositorio = new ProdutoRepositorio();
        private object response;

        public IEnumerable <Produto> GetAllProdutos() {
            return repositorio.GetAll();
        }
        public Produto GetProduto(int id) {
            Produto item = repositorio.Get(id);
            if(item == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public HttpResponseMessage PostProduto(Produto item) {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Produto>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.ProdutoId });

            response.Headers.Location = new Uri(uri);

            return response;
            
        }
        public void PutProduto(int id, Produto produto) {
            produto.ProdutoId = id;
            if (!repositorio.Update(produto)) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteProduto(int id) {
            Produto item = repositorio.Get(id);

            if(item == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
