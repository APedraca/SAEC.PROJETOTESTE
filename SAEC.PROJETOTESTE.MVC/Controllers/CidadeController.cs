using System;
using System.Web.Mvc;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.MVC.ViewModels;

namespace SAEC.PROJETOTESTE.MVC.Controllers
{
    public class CidadeController : BaseController
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        public ActionResult Index()
        {
            CidadeViewModel cidadeViewModel = new CidadeViewModel();
            cidadeViewModel.Cidades = _cidadeService.GetAll();

            return View(cidadeViewModel);
        }

        public ActionResult Create()
        {
            CidadeViewModel cidadeViewModel = new CidadeViewModel();
            cidadeViewModel.Cidade = new Cidade();

            return View(cidadeViewModel);
        }

        [HttpPost]
        public ActionResult Create(Cidade cidade)
        {
            try
            {
                _cidadeService.Save(cidade);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                CidadeViewModel cidadeViewModel = new CidadeViewModel();
                cidadeViewModel.Cidade = cidade;

                return View(cidadeViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            CidadeViewModel cidadeViewModel = new CidadeViewModel();
            cidadeViewModel.Cidade = _cidadeService.GetById(id);

            return View(cidadeViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Cidade cidade)
        {
            try
            {
                _cidadeService.Save(cidade);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                CidadeViewModel cidadeViewModel = new CidadeViewModel();
                cidadeViewModel.Cidade = cidade;

                return View(cidadeViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            Cidade cidade = _cidadeService.GetById(id);
            _cidadeService.Remove(cidade);

            return RedirectToAction("Index");
        }

        public ActionResult Cidades()
        {
            CidadeViewModel cidadeViewModel = new CidadeViewModel();
            cidadeViewModel.Cidades = _cidadeService.GetAll();

            return View(cidadeViewModel);
        }
    }
}