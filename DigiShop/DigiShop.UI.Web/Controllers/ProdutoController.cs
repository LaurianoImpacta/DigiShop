using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigiShop.Models;
using DigiShop.BLL;


namespace DigiShop.UI.Web.Controllers
{
    public class ProdutoController : Controller

    {
        private ProdutoBLL bll;
        public ProdutoController()
        {
            bll = new ProdutoBLL();

        }

        public ActionResult Excluir(string Id)
        {
            var produto = bll.ObterPorId(Id);
            return View(produto);
        }
        [HttpPost]
        public ActionResult Excluir(string Id, FormCollection form)
        {
            try
            {
                bll.Excluir(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var produto = bll.ObterPorId(Id);
                return View(produto);
            }
        }

        public ActionResult Alterar(string Id)
        {
            var produto = bll.ObterPorId(Id);
            return View(produto);
        }
        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            try
            {
                bll.Alterar(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }

        public ActionResult Detalhes(string Id)
        {
            var produto = bll.ObterPorId(Id);
            return View(produto);
        }
        //GET: Produto

        public ActionResult Incluir()
        {
            var pro = new Produto();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Incluir(Produto produto)
        {
            try
            {
                bll.Incluir(produto);
                return RedirectToAction("Index");
             }
            catch(Exception ex) 
            {
              ModelState.AddModelError (string.Empty, ex.Message);
                return View(produto);
            }
        }

        public ActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}