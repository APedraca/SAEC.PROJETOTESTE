using System.Collections.Generic;
using System.Web.Mvc;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MVC.ViewModels
{
    public class AlunoViewModel
    {
        public Aluno Aluno;
        public ICollection<Aluno> Alunos;
        public SelectList CidadeSl;

        public AlunoViewModel()
        {

        }
    }
}