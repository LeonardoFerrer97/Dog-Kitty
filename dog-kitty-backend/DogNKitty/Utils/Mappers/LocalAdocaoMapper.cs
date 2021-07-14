using System;
using System.Collections.Generic;
using Dto;
using Entity;

namespace Utils.Mappers
{
    public class LocalAdocaoMappers
    {
        private readonly DoacaoMappers doacaoMappers = new DoacaoMappers();
        public LocalAdocaoDto EntityToDto(LocalAdocao localAdocao)
        {
            return new LocalAdocaoDto()
            {
                Id = localAdocao.Id,
                Contato = localAdocao.Contato,
                Email = localAdocao.Email,
                Endereco = localAdocao.Endereco,
                Doacoes = doacaoMappers.ListEntityToListDto(localAdocao.Doacoes)
            };
        }
        public List<LocalAdocaoDto> ListEntityToListDto(IEnumerable<LocalAdocao> localAdocaos)
        {
            List<LocalAdocaoDto> dtos = new List<LocalAdocaoDto>();
            foreach (var localAdocao in localAdocaos)
            {
                dtos.Add(EntityToDto(localAdocao));

            }
            return dtos;
        }

        public LocalAdocao DtoToEntity(LocalAdocaoDto localAdocao)
        {
            return new LocalAdocao()
            {
                Id = localAdocao.Id,
                Contato = localAdocao.Contato,
                Email = localAdocao.Email,
                Endereco = localAdocao.Endereco,
                Doacoes = doacaoMappers.ListDtoToListEntity(localAdocao.Doacoes)
            };
        }

        public List<LocalAdocao> ListDtoToListEntity(IEnumerable<LocalAdocaoDto> localAdocaos)
        {
            List<LocalAdocao> dtos = new List<LocalAdocao>();
            foreach (var localAdocao in localAdocaos)
            {
                dtos.Add(DtoToEntity(localAdocao));

            }
            return dtos;
        }

    }
}
