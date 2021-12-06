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
    public class DoacaoBusinessTest
    {

        private readonly Mock<IRepository<Doacao>> doacaoRepository;
        private readonly Mock<IRepository<Animal>>animalCustomRepository;
        private readonly Mock<IRepository<Foto>> fotoRepository;
        private readonly Mock<IDoacaoRepository> doacaoRepositoryCustom;
        private readonly Mock<IAnimalRepository> animalRepository;
        private readonly DoacaoBusiness doacaoBusiness;
        public DoacaoBusinessTest()
        {
            doacaoRepository = new Mock<IRepository<Doacao>>();
            animalCustomRepository = new Mock<IRepository<Animal>>();
            fotoRepository = new Mock<IRepository<Foto>>();
            doacaoRepositoryCustom = new Mock<IDoacaoRepository>();
            animalRepository = new Mock<IAnimalRepository>();
            doacaoBusiness = new DoacaoBusiness("mock", doacaoRepository.Object, animalCustomRepository.Object, fotoRepository.Object, doacaoRepositoryCustom.Object, animalRepository.Object);
        }


        [Test]
        public void GetAllDoacao()
        {
            doacaoRepositoryCustom.Setup((x) => x.GetDoacao(It.IsAny<StatusEnum>(),It.IsAny<string>(),It.IsAny<int>(),It.IsAny<PorteEnum>(),It.IsAny<SexoEnum>(),It.IsAny<AnimalEnum>(),It.IsAny<int>())).Returns(MockDoacao());
            var result = doacaoBusiness.GetAllDoacaos(StatusEnum.Doacao,"mock",0,PorteEnum.Pequeno,SexoEnum.Feminino,AnimalEnum.Gato,1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateDoacaoNull()
        {
            var ex = Assert.Throws<Exception>(() => doacaoBusiness.UpdateDoacao(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void UpdateDoacao()
        {
            doacaoRepository.Setup((x) => x.InstertOrUpdate(It.IsAny<Doacao>(), It.IsAny<object>())).Returns(1);
             animalCustomRepository.Setup((x) => x.InstertOrUpdate(It.IsAny<Animal>(), It.IsAny<object>())).Returns(1);
            var result = doacaoBusiness.UpdateDoacao(MockDoacaoDto()[0]);
            Assert.AreEqual(result, 1);
        }




        [Test]
        public void DeleteDoacaoByIdNull()
        {
            var ex = Assert.Throws<Exception>(() => doacaoBusiness.DeleteDoacaoById(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void DeleteDoacaoById()
        {
            fotoRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            animalCustomRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            doacaoRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            doacaoBusiness.DeleteDoacaoById(MockDoacaoDto()[0]);
        }

        [Test]
        public void InsertDoacaoNull()
        {
            var ex = Assert.Throws<Exception>(() => doacaoBusiness.InsertDoacao(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }
        [Test]
        public void InsertUsuario()
        {
            doacaoRepositoryCustom.Setup((x) => x.InsertDoacao(It.IsAny<Doacao>()));
            animalRepository.Setup((x) => x.InsertAnimal(It.IsAny<Animal>(),It.IsAny<int>()));
            fotoRepository.Setup((x) => x.Add(It.IsAny<Foto>())).Returns(1);
            var result = doacaoBusiness.InsertDoacao(MockDoacaoDto()[0]);
            Assert.AreEqual(result, 0);
        }

        private List<Doacao> MockDoacao()
        {
            return new List<Doacao>(){
                new Doacao()
                {
                    Id=1,
                    Animal = MockAnimal()[0]
                }
            };
        }
        private List<DoacaoDto> MockDoacaoDto()
        {
            return new List<DoacaoDto>(){
                new DoacaoDto()
                {
                    Id=1,
                    Animal = new AnimalDto(){Id=1,
                        Foto = new List<FotoDto>(){new FotoDto(){Id=1}
                        },
                        Raca= new RacaDto()
                    }
                }
            };
        }
        private List<Animal> MockAnimal()
        {
            return new List<Animal>(){
                new Animal()
                {
                    Id=1,
                }
            };
        }
    }
}
