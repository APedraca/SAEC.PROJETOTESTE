using Ninject.Modules;
using Ninject.Web.Common;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.REPOSITORY;

namespace SAEC.PROJETOTESTE.IOC.Ninject
{
    public class ModuleRepository : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            Bind<ICidadeRepository>().To<CidadeRepository>().InRequestScope();
            Bind<IAlunoRepository>().To<AlunoRepository>().InRequestScope();
            Bind<IUsuarioRepository>().To<UsuarioRepository>().InRequestScope();
        }
    }
}
