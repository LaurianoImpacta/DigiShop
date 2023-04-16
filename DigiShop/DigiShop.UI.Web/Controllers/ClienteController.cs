using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigiShop.Models;
using DigiShop.BLL;

namespace DigiShop.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBLL bll;
        public ClienteController()
        {
            bll = new ClienteBLL();
        }

        public ActionResult Excluir(string Id)
        {
           var cliente = bll.ObterPorId(Id);
            return View(cliente);
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
                var cliente = bll.ObterPorId(Id);
                return View(cliente);
            }
        }


            public ActionResult Alterar(string Id)
        {
            var cliente = bll.ObterPorId(Id);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            try
            {
                bll.Alterar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }

        public ActionResult Detalhes(string Id)
        {
            var cliente = bll.ObterPorId(Id);
            return View(cliente);   
        }

        // GET: Cliente
        public ActionResult Incluir()
        {
            var cli = new Cliente();
            return View(cli);
        }
        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
           try
            {
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            }
           catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }

       }

        public ActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}