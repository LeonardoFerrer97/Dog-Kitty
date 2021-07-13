using System;
using System.Collections.Generic;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;

namespace MaisEad.Utils.Mappers
{
    public class UsuarioMappers
    {
        public UsuarioDto EntityToDto(Usuario Usuario)
        {
            if (Usuario != null)
            {
                return new UsuarioDto()
                {
                    Id = Usuario.Id,
                    Email = Usuario.Email,
                };

            }
            return null;
        }

        public List<UsuarioDto> ListEntityToListDto(IEnumerable<Usuario> Usuario)
        {
            List<UsuarioDto> dtos = new List<UsuarioDto>();
            foreach (var facul in Usuario)
            {
                dtos.Add(EntityToDto(facul));

            }
            return dtos;
        }

        public Usuario DtoToEntity(UsuarioDto Usuario)
        {
            return new Usuario()
            {
                Id = Usuario.Id,    
                Email = Usuario.Email,
            };

        }

        public List<Usuario> ListDtoToListEntity(IEnumerable<UsuarioDto> Usuario)
        {
            List<Usuario> dtos = new List<Usuario>();
            foreach (var facul in Usuario)
            {
                dtos.Add(DtoToEntity(facul));

            }
            return dtos;
        }

    }
}
