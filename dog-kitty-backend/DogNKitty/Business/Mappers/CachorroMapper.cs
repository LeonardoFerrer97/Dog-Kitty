using System;

using System.Collections.Generic;
using Dto;
using Entity;
namespace Business.Mappers
{
    public class CachorroMapper
    {
        private readonly RacaCachorroMapper mapper = new RacaCachorroMapper();
        public CachorroDto EntityToDto(Cachorro cachorro)
        {
            return new CachorroDto()
            {
                Id = cachorro.Id,
                Raca = mapper.EntityToDto(cachorro.Raca),
                Status = cachorro.Status,
                Nome = cachorro.Nome
            };
        }
        public List<CachorroDto> ListEntityToListDto(IEnumerable<Cachorro> cachorros)
        {
            List<CachorroDto> dtos = new List<CachorroDto>();
            foreach (var cachorro in cachorros)
            {
                dtos.Add(EntityToDto(cachorro));

            }
            return dtos;
        }

        public Cachorro DtoToEntity(CachorroDto cachorro)
        {
            return new Cachorro()
            {
                Id = cachorro.Id,
                Raca = mapper.DtoToEntity(cachorro.Raca),
                Status = cachorro.Status,
                Nome = cachorro.Nome
            };
        }

        public List<Cachorro> ListDtoToListEntity(IEnumerable<CachorroDto> cachorros)
        {
            List<Cachorro> dtos = new List<Cachorro>();
            foreach (var cachorro in cachorros)
            {
                dtos.Add(DtoToEntity(cachorro));

            }
            return dtos;
        }

    }
}
