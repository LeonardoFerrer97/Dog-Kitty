using System;
using System.Collections.Generic;
using Dto;
using Entity;

namespace Business.Mappers
{
    public class AnimalMapper
    {
        private readonly FotoMapper fotoMapper = new FotoMapper();
        public AnimalDto EntityToDto(Animal animal)
        {
            return new AnimalDto()
            {
                Id = animal.Id,
                Nome = animal.Nome,
                Status = animal.Status,
                Foto = fotoMapper.ListEntityToListDto(animal.Foto),
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
                Status = animal.Status,
                Foto = fotoMapper.ListDtoToListEntity(animal.Foto),
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
