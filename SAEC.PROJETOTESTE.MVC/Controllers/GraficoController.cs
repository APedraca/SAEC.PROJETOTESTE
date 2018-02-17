using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.MVC.Utils;
using SAEC.PROJETOTESTE.MVC.ViewModels;

namespace SAEC.PROJETOTESTE.MVC.Controllers
{
    public class GraficoController : BaseController
    {
        private readonly IAlunoService _alunoService;

        public GraficoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        public ActionResult AlunoHorario()
        {
            return View();
        }

        public JsonResult AlunoHorarioData()
        {
            ICollection<Aluno> alunos = _alunoService.GetAll();

            var horaQuantidae = from a in alunos
                group a by a.Cadastro.Hour
                into b
                select new {Hora = b.Key, Quantidade = b.Count()};

            return Json(horaQuantidae.OrderBy(h => h.Hora), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AlunoDias()
        {
            GraficoViewModel graficoViewModel = new GraficoViewModel();
            graficoViewModel.QuantidadeDiasSl = SelectListUtils.QuantidadeDiasSl();

            return View(graficoViewModel);
        }

        public JsonResult AlunoDiasData(int quantidadeDias)
        {
            ICollection<Aluno> alunos = _alunoService.GetAll();
            DateTime dataAtual = DateTime.Now;

            var diaQuantiade = from a in alunos
                where dataAtual.Subtract(a.Cadastro).Days <= quantidadeDias
                group a by a.Cadastro.Date
                into b
                select new {Dia = b.Key, Quantidade = b.Count()};
                    

            return Json(diaQuantiade.OrderBy(d => d.Dia), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AlunoCidade()
        {
            return View();
        }

        public JsonResult AlunoCidadeData()
        {
            ICollection<Aluno> alunos = _alunoService.GetAll();

            var cidadeQuantidade = from a in alunos
                group a by a.Cidade.Nome
                into b
                select new {Cidade = b.Key, Quantidade = b.Count()};

            return Json(cidadeQuantidade.OrderBy(c => c.Cidade), JsonRequestBehavior.AllowGet);
        }
    }
}