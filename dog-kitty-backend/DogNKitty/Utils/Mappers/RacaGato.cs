using System;
using System.Collections.Generic;
using Dto;
using Entity;
namespace Utils.Mappers
{
    public class RacaGatoMapper
    {
        public RacaGatoDto EntityToDto(RacaGato racaGato)
        {
            return new RacaGatoDto()
            {
                Id = racaGato.Id,
                Nome = racaGato.Nome
            };
        }
        public List<RacaGatoDto> ListEntityToListDto(IEnumerable<RacaGato> racaGatos)
        {
            List<RacaGatoDto> dtos = new List<RacaGatoDto>();
            foreach (var racaGato in racaGatos)
            {
                dtos.Add(EntityToDto(racaGato));

            }
            return dtos;
        }

        public RacaGato DtoToEntity(RacaGatoDto racaGato)
        {
            return new RacaGato()
            {
                Id = racaGato.Id,
                Nome = racaGato.Nome
            };
        }

        public List<RacaGato> ListDtoToListEntity(IEnumerable<RacaGatoDto> racaGatos)
        {
            List<RacaGato> dtos = new List<RacaGato>();
            foreach (var racaGato in racaGatos)
            {
                dtos.Add(DtoToEntity(racaGato));

            }
            return dtos;
        }
    }
}
