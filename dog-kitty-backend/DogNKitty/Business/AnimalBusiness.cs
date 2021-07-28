using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Query;
using Utils.Queries;

namespace Business
{
    public class AnimalBusiness
    {
        private readonly AnimalMapper mapper = new AnimalMapper();
        private readonly Repository<Animal> animalRepository;

        public AnimalBusiness(string connection)
        {
            animalRepository = new Repository<Animal>(connection);
        }


        public List<AnimalDto> GetAllAnimals()
        {
            IEnumerable<Animal> animals = animalRepository.All();

            List<AnimalDto> avaliacoesUsuario = mapper.ListEntityToListDto(animals);
            return avaliacoesUsuario;
        }

        public List<AnimalDto> GetAllAnimaisByFilter(int id)
        {
            object parameters = new { id };
            IEnumerable<Animal> doacoes = animalRepository.GetData(AnimalQueries.GET_ANIMAL_BY_ID, parameters);
            return mapper.ListEntityToListDto(doacoes.ToList());
        }

        public AnimalDto GetAnimalById(int Id)
        {
            object parameters = new { Id };
            Animal animals = animalRepository.GetData(AnimalQueries.GET_ANIMAL_BY_FILTER, parameters).FirstOrDefault();

            AnimalDto animal = mapper.EntityToDto(animals);
            return animal;
        }

        public int UpdateAnimal(AnimalDto Animal)
        {
            return animalRepository.InstertOrUpdate(mapper.DtoToEntity(Animal), new { AnimalId = Animal.Id });
        }

        public void DeleteAnimalById(int AnimalId)
        {
            animalRepository.Remove(new { AnimalId });
        }


        public int InsertAnimal(List<AnimalDto> Animal)
        {
            return animalRepository.Add(mapper.ListDtoToListEntity(Animal));
        }


    }
}
