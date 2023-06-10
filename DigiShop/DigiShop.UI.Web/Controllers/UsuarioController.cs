﻿using DigiShop.UI.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiShop.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
           



            return View();
        }

        [HttpPost]

        public ActionResult Logout(LoginViewModel login)
        {
            var usuarioStore = new UserStore<IdentityUser>();
            var usuarioGerenciador = new UserManager<IdentityUser>(usuarioStore);

            var usuario = usuarioGerenciador.Find(login.Nome, login.Senha);
            if(usuario == null)
            {
                ModelState.AddModelError("", "Usuário ou senha inválida");
            }else
            {
                var gerenciadorDeAutenticacao = HttpContext.GetOwinContext().Authentication;
                var identidade = usuarioGerenciador.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                gerenciadorDeAutenticacao.SignIn(new Microsoft.Owin.Security.AuthenticationProperties { }, identidade);
                Response.Redirect("~/");
            }

            return View(login);
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(NovoUsuarioViewModel novo)
        {
            if (string.IsNullOrEmpty(novo.Nome))
            {
                ModelState.AddModelError("", "O nome deve ser informado");
            }

            if (!string.IsNullOrEmpty(novo.Senha) && (novo.Senha != novo.ConfirmarSenha))
            {
                ModelState.AddModelError("", "A senha deve ser igual a confirmação");
            }

            if(ModelState.IsValid)
            {
                var usuarioStore = new UserStore<IdentityUser>();
                var usuarioGerenciador = new UserManager<IdentityUser>(usuarioStore);
                var usuario = new IdentityUser() { UserName = novo.Nome };

                var resultado = usuarioGerenciador.Create(usuario, novo.Senha);
                if (resultado.Succeeded) 
                {
                    var gerenciadorDeAutenticacao = HttpContext.GetOwinContext().Authentication;
                    var identidadeUsuario = usuarioGerenciador.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    gerenciadorDeAutenticacao.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { }, identidadeUsuario);
                    Response.Redirect("~/");
                }
            }

            return View(novo);
        }
    }
}