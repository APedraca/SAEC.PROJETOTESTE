using System.Collections.Generic;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MVC.ViewModels
{
    public class CidadeViewModel
    {
        public ICollection<Cidade> Cidades;
        public Cidade Cidade;

        public CidadeViewModel() { }
    }
}