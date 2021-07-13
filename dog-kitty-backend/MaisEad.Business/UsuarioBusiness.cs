using System;
using System.Collections.Generic;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;
using MaisEad.Repository.Repositories;
using MaisEad.Utils.Mappers;
using MaisEad.Utils.Query;

namespace MaisEad.Business
{
    public class UsuarioBusiness
    {
        private readonly UsuarioMappers mapper = new UsuarioMappers();
        private readonly Repository<Usuario> UsuarioRepository;

        public UsuarioBusiness(string connection)
        {
            UsuarioRepository = new Repository<Usuario>(connection);
        }
        public List<UsuarioDto> GetAllUsuario()
        {
            IEnumerable<Usuario> Usuario = UsuarioRepository.All();
            return mapper.ListEntityToListDto(Usuario);
        }

        public UsuarioDto GetUsuarioById(int Id)
        {
            return mapper.EntityToDto(UsuarioRepository.Find(new { Id }));
        }

        public UsuarioDto GetUsuarioByEmail (string Email)
        {
            return mapper.EntityToDto(UsuarioRepository.Find(new { Email }));
        }

        public int UpdateUsuarioById(UsuarioDto Usuario)
        {
            return UsuarioRepository.InstertOrUpdate(mapper.DtoToEntity(Usuario), new { Usuario.Id });
        }

        public void DeleteUsuarioById(int FaculId)
        {
            UsuarioRepository.Remove(new { FaculId });
        }

        public int InsertUsuario(UsuarioDto Usuario)
        {
            if (GetUsuarioByEmail(Usuario.Email) == null)
                return UsuarioRepository.Add(mapper.DtoToEntity(Usuario));
            else return 0;
        }
    }
}
