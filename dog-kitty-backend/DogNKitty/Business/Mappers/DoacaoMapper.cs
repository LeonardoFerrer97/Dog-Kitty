using System;
using System.Collections.Generic;
using Dto;
using Entity;

namespace Business.Mappers
{
    public class DoacaoMappers
    {
        private readonly UsuarioMapper usuarioMapper = new UsuarioMapper();
        private readonly AnimalMapper animalMappper = new AnimalMapper();
        public DoacaoDto EntityToDto(Doacao doacao)
        {
            return new DoacaoDto()
            {
                Id = doacao.Id,
                Localizacao = doacao.Localizacao,
                Usuario = usuarioMapper.EntityToDto(doacao.Usuario),
                Descricao = doacao.Descricao,
                Animal = animalMappper.EntityToDto(doacao.Animal)
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
                Localizacao = doacao.Localizacao,
                Descricao = doacao.Descricao,
                Usuario = usuarioMapper.DtoToEntity(doacao.Usuario),
                Animal = animalMappper.DtoToEntity(doacao.Animal)
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
