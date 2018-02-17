using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.MVC.Authorizations;

namespace SAEC.PROJETOTESTE.MVC.Controllers
{
    [Authorization]
    public class BaseController : Controller
    {
        #region Atributos

        private readonly IUsuarioService _serviceUsuario;

        private Usuario _usuario;

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor recebendo a instancia de IUsuarioService.
        /// </summary>
        /// <param name="serviceUsuario">IUsuarioService.</param>
        public BaseController()
        {
            this._serviceUsuario = DependencyResolver.Current.GetService<IUsuarioService>();
        }

        #endregion

        #region Propriedades

        protected Usuario UsuarioLogado
        {
            get
            {
                FormsAuthenticationTicket ticket;
                HttpCookie cookie = null;

                if (ControllerContext != null)
                    cookie = ControllerContext.RequestContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (cookie != null)
                {
                    ticket = FormsAuthentication.Decrypt(cookie.Value);
                    if (_usuario == null || !_usuario.Id.ToString().Equals(ticket.UserData))
                        return _usuario = this._serviceUsuario.GetById(Convert.ToInt32(ticket.UserData));

                    return _usuario;
                }

                return _usuario = null;
            }
        }

        #endregion
    }
}