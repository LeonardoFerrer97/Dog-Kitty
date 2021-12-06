
using Business;
using Dto;
using Entity;
using IRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;
namespace Tests
{
    public class AnimalBusinessTest
    {
        private readonly Mock<IRepository<Animal>> animalRepository;
        private readonly Mock<IAnimalRepository> animalRepositoryCustom;
        private readonly AnimalBusiness animalBusiness;
        public AnimalBusinessTest()
        {
            animalRepository = new Mock<IRepository<Animal>>();
            animalRepositoryCustom = new Mock<IAnimalRepository>();
            animalBusiness = new AnimalBusiness("mock", animalRepository.Object, animalRepositoryCustom.Object);

        }

        [Test]
        public void GetAllAnimals()
        {
            animalRepositoryCustom.Setup((x) => x.GetAnimal(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(),It.IsAny<StatusEnum>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<SexoEnum>(), It.IsAny<PorteEnum>(), It.IsAny<AnimalEnum>())).Returns(MockAnimal());
            var result = animalBusiness.GetAllAnimals("mock",2,2,StatusEnum.Perdido,2,2,SexoEnum.Feminino,PorteEnum.Pequeno,AnimalEnum.Cachorro);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAnimalByFilterNull()
        {
            var ex = Assert.Throws<Exception>(() => animalBusiness.GetAllAnimaisByFilter(0));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao foi achado"));
        }

        [Test]
        public void GetAnimalByFilter()
        {
            animalRepository.Setup((x) => x.GetData(It.IsAny<string>(), It.IsAny<object>())).Returns(MockAnimal());
            var result = animalBusiness.GetAllAnimaisByFilter(932);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAnimalByIdNull()
        {
            var ex = Assert.Throws<Exception>(() => animalBusiness.GetAnimalById(0));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao foi achado"));
        }

        [Test]
        public void GetAnimalById()
        {
            animalRepositoryCustom.Setup((x) => x.GetAnimalById(It.IsAny<int>())).Returns(MockAnimal()[0]);
            var result = animalBusiness.GetAllAnimaisByFilter(932);
            Assert.IsNotNull(result);
        }
        [Test]
        public void UpdateAnimalNull()
        {
            var ex = Assert.Throws<Exception>(() => animalBusiness.UpdateAnimal(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void UpdateAnimal()
        {
            animalRepository.Setup((x) => x.InstertOrUpdate(It.IsAny<Animal>(), It.IsAny<object>())).Returns(0);
            var result = animalBusiness.UpdateAnimal(MockAnimalDto()[0]);
            Assert.IsNotNull(result);
        }
        [Test]
        public void DeleteAnimalNull()
        {
            var ex = Assert.Throws<Exception>(() => animalBusiness.DeleteAnimalById(0));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao foi achado"));
        }

        [Test]
        public void DeleteAnimal()
        {
            animalRepository.Setup((x) => x.Remove(It.IsAny<int>()));
             animalBusiness.DeleteAnimalById(932);
        }
        [Test]
        public void InsertAnimalNull()
        {
            var ex = Assert.Throws<Exception>(() => animalBusiness.InsertAnimal(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void InsertAniaml()
        {
            animalRepository.Setup((x) => x.Add(It.IsAny<Animal>())).Returns(0);
            var result = animalBusiness.UpdateAnimal(MockAnimalDto()[0]);
            Assert.IsNotNull(result);
        }

        private List<Animal> MockAnimal()
        {
            return new List<Animal>(){
                new Animal()
                {
                    Id=1
                }
            };
        }
        private List<AnimalDto> MockAnimalDto()
        {
            return new List<AnimalDto>(){
                new AnimalDto()
                {
                    Id=1
                }
            };
        }
    }
}
