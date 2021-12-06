using System;
using System.Collections.Generic;
using Dto;
using Entity;
namespace Business.Mappers
{
    public class RacaMapper
    {
        public RacaDto EntityToDto(Raca raca)
        {
            if (raca != null)
            {
                return new RacaDto()
                {
                    Id = raca.Id,
                    Nome = raca.Nome
                };
            }return null;
        }
        public List<RacaDto> ListEntityToListDto(IEnumerable<Raca> racas)
        {
            List<RacaDto> dtos = new List<RacaDto>();
            if (racas != null)
            {
                foreach (var raca in racas)
                {
                    dtos.Add(EntityToDto(raca));

                }
            }
            return dtos;
        }

        public Raca DtoToEntity(RacaDto raca)
        {
            if (raca != null)
            {
                return new Raca()
                {
                    Id = raca.Id,
                    Nome = raca.Nome
                };
            }return null;
        }

        public List<Raca> ListDtoToListEntity(IEnumerable<RacaDto> racas)
        {
            List<Raca> dtos = new List<Raca>();

            if (racas != null)
            {
                foreach (var raca in racas)
                {
                    dtos.Add(DtoToEntity(raca));

                }
            }
            return dtos;
        }
    }
}
