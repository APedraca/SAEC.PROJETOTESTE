using Ninject.Modules;
using Ninject.Web.Common;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.SERVICE;

namespace SAEC.PROJETOTESTE.IOC.Ninject
{
    public class ModuleService : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            Bind<ICidadeService>().To<CidadeService>().InRequestScope();
            Bind<IAlunoService>().To<AlunoService>().InRequestScope();
            Bind<IUsuarioService>().To<UsuarioService>().InRequestScope();
        }
    }
}
