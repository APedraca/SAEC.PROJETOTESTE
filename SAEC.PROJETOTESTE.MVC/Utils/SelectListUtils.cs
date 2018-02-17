using System.Collections.Generic;
using System.Web.Mvc;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MVC.Utils
{
    public static class SelectListUtils
    {
        private static SelectListItem CreateGenericItem(string value, string text, bool selected = false)
        {
            return new SelectListItem
            {
                Value = value,
                Text = text,
                Selected = selected
            };
        }

        public static SelectList CidadeSl(ICollection<Cidade> cidades)
        {
            IList<SelectListItem> cidadeSl = new List<SelectListItem>();

            foreach (var cidade in cidades)
            {
                cidadeSl.Add(CreateGenericItem(cidade.Id.ToString(), cidade.Nome));
            }

            return new SelectList(cidadeSl, "Value", "Text");
        }

        public static SelectList QuantidadeDiasSl()
        {
            IList<SelectListItem> quantidadeDiasSl = new List<SelectListItem>();

            quantidadeDiasSl.Add(CreateGenericItem("7", "7 Dias"));
            quantidadeDiasSl.Add(CreateGenericItem("10", "10 Dias"));
            quantidadeDiasSl.Add(CreateGenericItem("15", "15 Dias"));
            quantidadeDiasSl.Add(CreateGenericItem("20", "20 Dias"));
            quantidadeDiasSl.Add(CreateGenericItem("30", "30 Dias"));

            return new SelectList(quantidadeDiasSl, "Value", "Text");
        }
    }
}