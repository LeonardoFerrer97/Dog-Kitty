using Business;
using Dto;
using Entity;
using IRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class UsuarioBusinessTest
    {
        private readonly Mock<IRepository<Usuario>> mockUsuarioRepository;
        private readonly Mock<IRepository<Chat>> mockChatRepository;
        private readonly Mock<IRepository<ChatMessages>> mockChatMessagesRepository;
        private readonly Mock<IRepository<Doacao>> mockDoacaoRepository;
        private readonly Mock<IRepository<Animal>> mockAnimalRepository;
        private readonly UsuarioBusiness usuarioBusiness;
        public UsuarioBusinessTest()
        {
            mockUsuarioRepository = new Mock<IRepository<Usuario>>();
            mockChatRepository = new Mock<IRepository<Chat>>();
            mockDoacaoRepository = new Mock<IRepository<Doacao>>();
            mockChatMessagesRepository = new Mock<IRepository<ChatMessages>>();
            mockAnimalRepository = new Mock<IRepository<Animal>>();
            usuarioBusiness = new UsuarioBusiness("mock", mockUsuarioRepository.Object, mockChatRepository.Object, mockChatMessagesRepository.Object,mockDoacaoRepository.Object,mockAnimalRepository.Object);
        }

        [Test]
        public void GetUsuario()
        {
            mockUsuarioRepository.Setup((x) => x.All()).Returns(MockUsuario());
            var result = usuarioBusiness.GetAllUsuario();
            Assert.IsNotNull(result);
        }


        [Test]
        public void GetUsuarioIdNull()
        {
            var ex = Assert.Throws<Exception>(() => usuarioBusiness.GetUsuarioById(0));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao foi achado"));
        }


        [Test]
        public void GetUsuarioNull()
        {
            mockUsuarioRepository.Setup((x) => x.GetData(It.IsAny<object>())).Returns(MockUsuarioVazio());
            var result = usuarioBusiness.GetUsuarioById(932);
            Assert.IsNull(result);
        }

        [Test]
        public void GetUsuarioById()
        {
            mockUsuarioRepository.Setup((x) => x.GetData(It.IsAny<object>())).Returns(MockUsuario()); 
            var result = usuarioBusiness.GetUsuarioById(932);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUsuarioEmailNull()
        {
            var ex = Assert.Throws<Exception>(() => usuarioBusiness.GetUsuarioByEmail(""));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao foi achado"));
        }


        [Test]
        public void GetUsuarioByEmailNull()
        {
            mockUsuarioRepository.Setup((x) => x.GetData(It.IsAny<object>())).Returns(MockUsuarioVazio());
            var result = usuarioBusiness.GetUsuarioByEmail("testeemail");
            Assert.IsNull(result);
        }

        [Test]
        public void GetUsuarioByEmail()
        {
            mockUsuarioRepository.Setup((x) => x.GetData(It.IsAny<object>())).Returns(MockUsuario());
            var result = usuarioBusiness.GetUsuarioByEmail("mockemail");
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateUsuarioNull()
        {
            var ex = Assert.Throws<Exception>(() => usuarioBusiness.UpdateUsuario(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void UpdateUsuario()
        {
            mockUsuarioRepository.Setup((x) => x.InstertOrUpdate(It.IsAny<Usuario>(),It.IsAny<object>())).Returns(1);
            var result = usuarioBusiness.UpdateUsuario(MockUsuarioDto()[0]);
            Assert.AreEqual(result,1);
        }


        [Test]
        public void DeleteUsuarioByIdNull()
        {
            var ex = Assert.Throws<Exception>(() => usuarioBusiness.DeleteUsuarioById(0));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao foi achado"));
        }

        [Test]
        public void DeleteUsuarioById()
        {
            mockUsuarioRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            mockAnimalRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            mockChatMessagesRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            mockChatRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            mockDoacaoRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            mockDoacaoRepository.Setup((x) => x.GetData(It.IsAny<object>())).Returns(MockDoacao());
            usuarioBusiness.DeleteUsuarioById(1);
        }
        [Test]
        public void InsertUsuarioNull()
        {
            var ex = Assert.Throws<Exception>(() => usuarioBusiness.InsertUsuario(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }
        [Test]
        public void InsertUsuario()
        {
            mockUsuarioRepository.Setup((x) => x.Add(It.IsAny<Usuario>())).Returns(1);
            var result = usuarioBusiness.InsertUsuario(MockUsuarioDto()[0]);
            Assert.AreEqual(result,1);
        }

        private List<Usuario> MockUsuario()
        {
            return new List<Usuario>(){
                new Usuario()
                {
                    Id=1,
                    Nome = "Mock Nome"
                }
            };
        }
        private List<Usuario> MockUsuarioVazio()
        {
            return new List<Usuario>();
        }
        private List<UsuarioDto> MockUsuarioDto()
        {
            return new List<UsuarioDto>(){
                new UsuarioDto()
                {
                    Id=1,
                    Nome = "Mock Nome"
                }
            };
        }
        private List<Doacao> MockDoacao()
        {
            return new List<Doacao>(){
                new Doacao()
                {
                    Id=1,
                    Animal = new Animal(){Id=1}
                }
            };
        }
    }
}
