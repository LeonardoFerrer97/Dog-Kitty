using System;
using System.Collections.Generic;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;

namespace MaisEad.Utils.Mappers
{
    public class FaculdadeMappers
    {
        public FaculdadeDto EntityToDto(Faculdade faculdade)
        {
            if (faculdade != null)
            {
                return new FaculdadeDto()
                {
                    Id = faculdade.FaculId,
                    Nome = faculdade.NomeFaculdade,
                    Endereco = faculdade.Endereco,
                    NotaMec = faculdade.NotaMecFaculdade,
                };

            }
            return null;
        }

        public List<FaculdadeDto> ListEntityToListDto(IEnumerable<Faculdade> faculdade)
        {
            List<FaculdadeDto> dtos = new List<FaculdadeDto>();
            foreach(var facul in faculdade)
            {
                dtos.Add(EntityToDto(facul));

            }
            return dtos;
        }

        public Faculdade DtoToEntity(FaculdadeDto faculdade)
        {
            return new Faculdade()
            {
                FaculId = faculdade.Id,
                NomeFaculdade = faculdade.Nome,
                Endereco = faculdade.Endereco,
                NotaMecFaculdade = faculdade.NotaMec,
            };

        }

        public List<Faculdade> ListDtoToListEntity(IEnumerable<FaculdadeDto> faculdade)
        {
            List<Faculdade> dtos = new List<Faculdade>();
            foreach (var facul in faculdade)
            {
                dtos.Add(DtoToEntity(facul));

            }
            return dtos;
        }

    }
}
