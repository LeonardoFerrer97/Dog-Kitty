using System;
using System.Collections.Generic;
using Dto;
using Entity;

namespace Utils.Mappers
{
    public class AnimalMapper
    {
        public AnimalDto EntityToDto(Animal doacao)
        {
            return new AnimalDto()
            {
                Id = doacao.Id,
                Nome = doacao.Nome,
                Status = doacao.Status
            };
        }
        public List<AnimalDto> ListEntityToListDto(IEnumerable<Animal> animais)
        {
            List<AnimalDto> dtos = new List<AnimalDto>();
            foreach (var aniaml in animais)
            {
                dtos.Add(EntityToDto(aniaml));

            }
            return dtos;
        }

        public Animal DtoToEntity(AnimalDto animal)
        {
            return new Animal()
            {
                Id = animal.Id,
                Nome = animal.Nome,
                Status = animal.Status
            };
        }

        public List<Animal> ListDtoToListEntity(IEnumerable<AnimalDto> animais)
        {
            List<Animal> dtos = new List<Animal>();
            foreach (var animal in animais)
            {
                dtos.Add(DtoToEntity(animal));

            }
            return dtos;
        }

    }
}
