using System;
using System.Collections.Generic;
using Dto;
using Entity;

namespace Business.Mappers
{
    public class DoacaoMappers
    {
        private readonly GatoMapper gatoMapper = new GatoMapper();
        private readonly CachorroMapper cachorroMapper = new CachorroMapper();
        private readonly UsuarioMapper usuarioMapper = new UsuarioMapper();
        public DoacaoDto EntityToDto(Doacao doacao)
        {
            return new DoacaoDto()
            {
                Id = doacao.Id,
                Cachorro = cachorroMapper.EntityToDto(doacao.Cachorro),
                Gato = gatoMapper.EntityToDto(doacao.Gato),
                Localizacao = doacao.Localizacao,
                Usuario = usuarioMapper.EntityToDto(doacao.Usuario),
                Descricao = doacao.Descricao
            };
        }
        public List<DoacaoDto> ListEntityToListDto(IEnumerable<Doacao> doacoes)
        {
            List<DoacaoDto> dtos = new List<DoacaoDto>();
            foreach (var doacao in doacoes)
            {
                dtos.Add(EntityToDto(doacao));

            }
            return dtos;
        }

        public Doacao DtoToEntity(DoacaoDto doacao)
        {
            return new Doacao()
            {
                Id = doacao.Id,
                Cachorro = cachorroMapper.DtoToEntity(doacao.Cachorro),
                Gato = gatoMapper.DtoToEntity(doacao.Gato),
                Localizacao = doacao.Localizacao,
                Descricao = doacao.Descricao,
                Usuario = usuarioMapper.DtoToEntity(doacao.Usuario),
            };
        }

        public List<Doacao> ListDtoToListEntity(IEnumerable<DoacaoDto> doacoes)
        {
            List<Doacao> dtos = new List<Doacao>();
            foreach (var doacao in doacoes)
            {
                dtos.Add(DtoToEntity(doacao));

            }
            return dtos;
        }

    }
}
