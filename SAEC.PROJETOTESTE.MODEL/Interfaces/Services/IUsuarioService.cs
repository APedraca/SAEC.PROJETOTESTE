using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MODEL.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        void Save(Usuario usuario);
        Usuario Login(Usuario usuario);
    }
}
