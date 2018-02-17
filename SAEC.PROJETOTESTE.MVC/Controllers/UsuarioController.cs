using System;
using System.Web.Mvc;
using System.Web.Security;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.MVC.Authorizations;
using SAEC.PROJETOTESTE.MVC.Utils;
using SAEC.PROJETOTESTE.MVC.ViewModels;

namespace SAEC.PROJETOTESTE.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ICidadeService _cidadeService;

        public UsuarioController(IUsuarioService usuarioService, ICidadeService cidadeService)
        {
            _usuarioService = usuarioService;
            _cidadeService = cidadeService;
        }

        #region Metodos de Autenticacao

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                FormsAuthentication.SignOut();

            ModelState.Clear();

            UsuarioViewModel vm = new UsuarioViewModel
            {
                Usuario = new Usuario()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                usuario = _usuarioService.Login(usuario);

                AuthenticationProvider.SetarAutenticacaoUsuario(usuario);

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch (Exception se)
            {
                UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
                usuarioViewModel.Usuario = usuario;
                return View(usuarioViewModel);
            }
        }

        public ActionResult LogOff()
        {
            Session.RemoveAll();
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        #endregion

        public ActionResult Create()
        {
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Usuario = new Usuario();
            usuarioViewModel.CidadeSl = SelectListUtils.CidadeSl(_cidadeService.GetAll());

            return View(usuarioViewModel);
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                _usuarioService.Save(usuario);

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
                usuarioViewModel.Usuario = new Usuario();
                usuarioViewModel.CidadeSl = SelectListUtils.CidadeSl(_cidadeService.GetAll());

                return View(usuarioViewModel);
            }
        }
    }
}