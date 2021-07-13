using System;
using System.Collections.Generic;
using MaisEad.Dto.Dto;
using MaisEad.Entity;
using MaisEad.Entity.Entity;

namespace MaisEad.Utils.Mappers
{
    public class TipoCursoMappers
    {
        public TipoCursoDto EntityToDto(TipoCurso TipoCurso)
        {
            if (TipoCurso != null)
            {
                return new TipoCursoDto()
                {
                    IdTipo = TipoCurso.IdTipo,
                    NomeTipo = TipoCurso.NomeTipo,
                };

            }
            return null;
        }

        public List<TipoCursoDto> ListEntityToListDto(IEnumerable<TipoCurso> TipoCurso)
        {
            List<TipoCursoDto> dtos = new List<TipoCursoDto>();
            foreach (var type in TipoCurso)
            {
                dtos.Add(EntityToDto(type));

            }
            return dtos;
        }

        public TipoCurso DtoToEntity(TipoCursoDto TipoCurso)
        {
            return new TipoCurso()
            {
                IdTipo = TipoCurso.IdTipo,
                NomeTipo = TipoCurso.NomeTipo,
            };

        }

        public List<TipoCurso> ListDtoToListEntity(IEnumerable<TipoCursoDto> TipoCurso)
        {
            List<TipoCurso> dtos = new List<TipoCurso>();
            foreach (var type in TipoCurso)
            {
                dtos.Add(DtoToEntity(type));

            }
            return dtos;
        }

    }
}
