using System;

using System.Collections.Generic;
using Dto;
using Entity;

namespace Business.Mappers
{
    public class GatoMapper
    {
        private readonly RacaGatoMapper mapper = new RacaGatoMapper();
        public GatoDto EntityToDto(Gato gato)
        {
            return new GatoDto()
            {
                Id = gato.Id,
                RacaGato = mapper.EntityToDto(gato.RacaGato),
                Status = gato.Status,
                Nome = gato.Nome
            };
        }
        public List<GatoDto> ListEntityToListDto(IEnumerable<Gato> gatos)
        {
            List<GatoDto> dtos = new List<GatoDto>();
            foreach (var gato in gatos)
            {
                dtos.Add(EntityToDto(gato));

            }
            return dtos;
        }

        public Gato DtoToEntity(GatoDto gato)
        {
            return new Gato()
            {
                Id = gato.Id,
                RacaGato = mapper.DtoToEntity(gato.RacaGato),
                Status = gato.Status,
                Nome = gato.Nome
            };
        }

        public List<Gato> ListDtoToListEntity(IEnumerable<GatoDto> gatos)
        {
            List<Gato> dtos = new List<Gato>();
            foreach (var gato in gatos)
            {
                dtos.Add(DtoToEntity(gato));

            }
            return dtos;
        }

    }
}
