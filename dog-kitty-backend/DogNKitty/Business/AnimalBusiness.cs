using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Query;
using Utils.Queries;
using IRepository;
using Utils.Enums;

namespace Business
{
    public class AnimalBusiness
    {
        private readonly AnimalMapper mapper = new AnimalMapper();
        private readonly Repository<Animal> animalRepository;
        private readonly IAnimalRepository animalRepositoryCustom;

        public AnimalBusiness(string connection)
        {
            animalRepository = new Repository<Animal>(connection);
            animalRepositoryCustom = new AnimalRepository(connection);
        }


        public List<AnimalDto> GetAllAnimals(string nome, int? doacaoId,int? raca_id, StatusEnum? status, double? peso, int? idade, SexoEnum? sexo, PorteEnum? porte, AnimalEnum? tipoAnimal)
        {
            IEnumerable<Animal> animals = animalRepositoryCustom.GetAnimal(nome, doacaoId,raca_id,status, peso,idade, sexo,porte, tipoAnimal);

            List<AnimalDto> avaliacoesUsuario = mapper.ListEntityToListDto(animals);
            return avaliacoesUsuario;
        }

        public List<AnimalDto> GetAllAnimaisByFilter(int id)
        {
            object parameters = new { id };
            IEnumerable<Animal> doacoes = animalRepository.GetData(AnimalQueries.GET_ANIMAL_BY_ID, parameters);
            return mapper.ListEntityToListDto(doacoes.ToList());
        }

        public AnimalDto GetAnimalById(int id)
        {
            Animal animals = animalRepositoryCustom.GetAnimalById(id);

            AnimalDto animal = mapper.EntityToDto(animals);
            return animal;
        }

        public int UpdateAnimal(AnimalDto Animal)
        {
            return animalRepository.InstertOrUpdate(mapper.DtoToEntity(Animal), new { id = Animal.Id });
        }

        public void DeleteAnimalById(int id)
        {
            animalRepository.Remove(new { id });
        }


        public int InsertAnimal(List<AnimalDto> Animal)
        {
            return animalRepository.Add(mapper.ListDtoToListEntity(Animal));
        }


    }
}
