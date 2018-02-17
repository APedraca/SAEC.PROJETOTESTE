using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;

namespace SAEC.PROJETOTESTE.MVC.Authorizations
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        #region Atributos

        private readonly IUsuarioService _serviceUsuario;
        private Usuario _usuario;

        #endregion

        #region Construtor

        public AuthorizationAttribute()
        {
            _serviceUsuario = DependencyResolver.Current.GetService<IUsuarioService>();
        }

        #endregion

        #region Propriedades

        public Usuario UsuarioLogado
        {
            get
            {
                HttpCookie cookie = null;

                if (HttpContext.Current != null)
                    cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (cookie == null)
                    return _usuario = null;

                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                if (ticket != null && (_usuario == null || !_usuario.Id.ToString().Equals(ticket.UserData)))
                    return _usuario = _serviceUsuario.GetById(Convert.ToInt32(ticket.UserData));

                return _usuario;
            }
        }

        #endregion

        #region Metodos da Arquitetura

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            this._usuario = this.UsuarioLogado;

            //renova o cookie do browser
            if (_usuario != null && filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                AuthenticationProvider.SetarAutenticacaoUsuario(_usuario);
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Usuario/Login");
                return;
            }
        }

        #endregion
    }
}