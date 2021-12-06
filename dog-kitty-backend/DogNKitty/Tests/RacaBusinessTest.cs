using Entity;
using Business;
using IRepository;
using Moq;
using Repository;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using Dto;

namespace Tests
{
    public class RacaBusinessTest
    {
        private readonly Mock<IRepository<Raca>> mockRepository;
        private readonly RacaBusiness racaBusiness;
        public RacaBusinessTest()
        {
            mockRepository = new Mock<IRepository<Raca>>();
            racaBusiness = new RacaBusiness("mock", mockRepository.Object);
        }
        [Test]
        public void InsertRacaNull()
        {
            var ex = Assert.Throws<Exception>(() => racaBusiness.InsertRaca(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }
        [Test]
        public void InsertRaca()
        {
            mockRepository.Setup((x) => x.Add(It.IsAny<Raca>())).Returns(1);
            var result = racaBusiness.InsertRaca(MockRacaDto()[0]);
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void GetRaca()
        {
            mockRepository.Setup((x) => x.All()).Returns(MockRaca());
            var result = racaBusiness.GetAllRaca();
            Assert.IsNotNull(result);
        }

        private List<Raca> MockRaca()
        {
            return new List<Raca>(){
                new Raca()
                {
                    Id=1,
                    Nome = "Mock Nome"
                }
            };
        }
        private List<RacaDto> MockRacaDto()
        {
            return new List<RacaDto>(){
                new RacaDto()
                {
                    Id=1,
                    Nome = "Mock Nome"
                }
            };
        }
    }
}
