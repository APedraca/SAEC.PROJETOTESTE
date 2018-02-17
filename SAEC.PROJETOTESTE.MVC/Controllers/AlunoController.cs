using System;
using System.Web.Mvc;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.MVC.Authorizations;
using SAEC.PROJETOTESTE.MVC.Utils;
using SAEC.PROJETOTESTE.MVC.ViewModels;

namespace SAEC.PROJETOTESTE.MVC.Controllers
{
    public class AlunoController : BaseController
    {
        private readonly IAlunoService _alunoService;
        private readonly ICidadeService _cidadeService;

        public AlunoController(IAlunoService alunoService, ICidadeService cidadeService)
        {
            _alunoService = alunoService;
            _cidadeService = cidadeService;
        }

        public ActionResult Index()
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel();
            alunoViewModel.Alunos = _alunoService.GetAll();

            return View(alunoViewModel);
        }

        public ActionResult Create()
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel();
            alunoViewModel.Aluno = new Aluno();
            alunoViewModel.CidadeSl = SelectListUtils.CidadeSl(_cidadeService.GetAll());

            return View(alunoViewModel);
        }

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            try
            {
                aluno.UsuarioId = UsuarioLogado.Id;
                _alunoService.Save(aluno);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                AlunoViewModel alunoViewModel = new AlunoViewModel();
                alunoViewModel.Aluno = aluno;
                alunoViewModel.CidadeSl = SelectListUtils.CidadeSl(_cidadeService.GetAll());

                return View(alunoViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel();
            alunoViewModel.Aluno = _alunoService.GetById(id);
            alunoViewModel.CidadeSl = SelectListUtils.CidadeSl(_cidadeService.GetAll());

            return View(alunoViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Aluno aluno)
        {
            try
            {
                aluno.UsuarioId = UsuarioLogado.Id;
                _alunoService.Save(aluno);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                AlunoViewModel alunoViewModel = new AlunoViewModel();
                alunoViewModel.Aluno = aluno;
                alunoViewModel.CidadeSl = SelectListUtils.CidadeSl(_cidadeService.GetAll());

                return View(alunoViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            Aluno aluno = _alunoService.GetById(id);
            _alunoService.Remove(aluno);

            return RedirectToAction("Index");
        }

        public ActionResult Alunos(int id)
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel();
            alunoViewModel.Alunos = _alunoService.GetBy(a => a.CidadeId.Equals(id));

            return View(alunoViewModel);
        }
    }
}