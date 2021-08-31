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
            return new RacaDto()
            {
                Id = raca.Id,
                Nome = raca.Nome
            };
        }
        public List<RacaDto> ListEntityToListDto(IEnumerable<Raca> racas)
        {
            List<RacaDto> dtos = new List<RacaDto>();
            foreach (var raca in racas)
            {
                dtos.Add(EntityToDto(raca));

            }
            return dtos;
        }

        public Raca DtoToEntity(RacaDto raca)
        {
            return new Raca()
            {
                Id = raca.Id,
                Nome = raca.Nome
            };
        }

        public List<Raca> ListDtoToListEntity(IEnumerable<RacaDto> racas)
        {
            List<Raca> dtos = new List<Raca>();
            foreach (var raca in racas)
            {
                dtos.Add(DtoToEntity(raca));

            }
            return dtos;
        }
    }
}
