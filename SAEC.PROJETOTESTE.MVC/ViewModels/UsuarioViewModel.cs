using System.Web.Mvc;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        public Usuario Usuario;
        public SelectList CidadeSl;
    }
}