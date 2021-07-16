using System;
using System.Collections.Generic;
using Dto;
using Entity;
namespace Business.Mappers
{
    public class RacaCachorroMapper
    {
        public RacaCachorroDto EntityToDto(RacaCachorro racaCachorro)
        {
            return new RacaCachorroDto()
            {
                Id = racaCachorro.Id,
                Nome = racaCachorro.Nome
            };
        }
        public List<RacaCachorroDto> ListEntityToListDto(IEnumerable<RacaCachorro> racaCachorros)
        {
            List<RacaCachorroDto> dtos = new List<RacaCachorroDto>();
            foreach (var racaCachorro in racaCachorros)
            {
                dtos.Add(EntityToDto(racaCachorro));

            }
            return dtos;
        }

        public RacaCachorro DtoToEntity(RacaCachorroDto racaCachorro)
        {
            return new RacaCachorro()
            {
                Id = racaCachorro.Id,
                Nome = racaCachorro.Nome
            };
        }

        public List<RacaCachorro> ListDtoToListEntity(IEnumerable<RacaCachorroDto> racaCachorros)
        {
            List<RacaCachorro> dtos = new List<RacaCachorro>();
            foreach (var racaCachorro in racaCachorros)
            {
                dtos.Add(DtoToEntity(racaCachorro));

            }
            return dtos;
        }
    }
}
