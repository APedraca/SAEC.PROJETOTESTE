using System;
using System.Web;
using System.Web.Security;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.ManagementSystem;

namespace SAEC.PROJETOTESTE.MVC.Authorizations
{
    public static class AuthenticationProvider
    {
        /// <summary>
        /// Método responsável por setar a autenticação do usuário.
        /// </summary>
        /// <param name="usuario">Usuario a ser autenticado.</param>
        public static void SetarAutenticacaoUsuario(Usuario usuario)
        {
            double cookieTimeout;
            double.TryParse(ProjetoTesteConfiguration.CookieTimeOut, out cookieTimeout);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                usuario.Email,
                DateTime.Now,
                DateTime.Now.AddMinutes(cookieTimeout),
                true,
                usuario.Id.ToString());

            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(usuario.Email, true);
            authCookie.Expires = authTicket.Expiration;
            authCookie.Value = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }
    }
}