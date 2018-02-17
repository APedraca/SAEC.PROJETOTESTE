using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAEC.PROJETOTESTE.MODEL.ManagementSystem
{
    public class ProjetoTesteConfiguration
    {
        /// <summary>
        /// Armazena o tempo do cookie em minutos.
        /// </summary>
        public static string CookieTimeOut
        {
            get { return ConfigurationManager.AppSettings["cookieTimeOut"]; }
        }
    }
}
