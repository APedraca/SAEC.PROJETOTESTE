using System;
using System.Linq;
using SAEC.PROJETOTESTE.MODEL.Cryptography;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.MODEL.ManagementSystem;

namespace SAEC.PROJETOTESTE.SERVICE
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            :base (usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Save(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioNomeEmpty);
            if (string.IsNullOrWhiteSpace(usuario.Cpf))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioCpfEmpty);
            if (string.IsNullOrWhiteSpace(usuario.Sexo))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioSexoEmpty);
            if (string.IsNullOrWhiteSpace(usuario.Telefone))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioTelefoneEmpty);
            if (usuario.CidadeId == 0)
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioCidadeEmpty);
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioEmailEmpty);
            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioSenhaEmpty);

            Usuario usuarioDb = _usuarioRepository.GetBy(u => u.Email.Equals(usuario.Email)).FirstOrDefault();
            if (usuarioDb != null && usuarioDb.Id > 0)
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioEmailExist);

            if (usuario.Id == 0)
            {
                usuario.Senha = MD5Cryptography.Get(usuario.Senha);
                Add(usuario);
            }
            else
                Update(usuario);
        }

        public Usuario Login(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioEmailEmpty);
            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioSenhaEmpty);

            usuario.Senha = MD5Cryptography.Get(usuario.Senha);
            Usuario usuarioDb = _usuarioRepository
                .GetBy(u => u.Email.Equals(usuario.Email) && 
                            u.Senha.Equals(usuario.Senha)).FirstOrDefault();

            if (usuarioDb == null || usuarioDb.Id == 0)
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.UsuarioInvalid);

            return usuarioDb;
        }
    }
}
