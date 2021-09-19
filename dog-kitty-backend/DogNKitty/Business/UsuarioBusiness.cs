using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Queries;
namespace Business
{
    public class UsuarioBusiness
    {
        private readonly UsuarioMapper mapper = new UsuarioMapper();
        private readonly Repository<Usuario> usuarioRepository;

        public UsuarioBusiness(string connection)
        {
            usuarioRepository = new Repository<Usuario>(connection);
        }


        public List<UsuarioDto> GetAllUsuario()
        {
            IEnumerable<Usuario> doacaos = usuarioRepository.All();

            List<UsuarioDto> avaliacoesUsuario = mapper.ListEntityToListDto(doacaos);
            return avaliacoesUsuario;
        }

        public UsuarioDto GetUsuarioById(int Id)
        {
            object parameters = new { Id };
            Usuario usuario = usuarioRepository.GetData( parameters).FirstOrDefault();
            if (usuario == null)
            {
                return null;
            }
            return mapper.EntityToDto(usuario);
        }
        
        public UsuarioDto GetUsuarioByEmail(string Email)
        {
            object parameters = new { Email };
            Usuario usuario = usuarioRepository.GetData(parameters).FirstOrDefault();
            if(usuario == null)
            {
                return null;
            }
            return mapper.EntityToDto(usuario);
        }
        public int UpdateUsuario(UsuarioDto Usuario)
        {
            return usuarioRepository.InstertOrUpdate(mapper.DtoToEntity(Usuario), new { DoacaoId = Usuario.Id });
        }

        public void DeleteDoacaoById(int DoacaoId)
        {
            usuarioRepository.Remove(new { DoacaoId });
        }


        public void DeleteUsuarioById(int Id)
        {
            usuarioRepository.Remove(new { Id });
        }


        public int InsertUsuario(UsuarioDto Usuario)
        {
            return usuarioRepository.Add(mapper.DtoToEntity(Usuario));
        }


    }
}
