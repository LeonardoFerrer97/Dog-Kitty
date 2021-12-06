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
    public class ChatBusinessTest
    {

        private readonly Mock<IRepository<Chat>> chatRepository;
        private readonly Mock<IRepository<ChatMessages>> chatMessageRepository;
        private readonly Mock<IChatRepository> chatRepositoryCustom;
        private readonly ChatBusiness chatBusiness;
        public ChatBusinessTest()
        {
            chatRepository = new Mock<IRepository<Chat>>();
            chatMessageRepository = new Mock<IRepository<ChatMessages>>();
            chatRepositoryCustom = new Mock<IChatRepository>();
            chatBusiness = new ChatBusiness("mock", chatRepository.Object, chatMessageRepository.Object, chatRepositoryCustom.Object);
        }

        public void GetAllChats()
        {
            chatRepositoryCustom.Setup((x) => x.GetChats(It.IsAny<string>())).Returns(MockChat());
            var result = chatBusiness.GetAllChat("mock");
            Assert.IsNotNull(result);
        }

        public void GetChatByIdNull()
        {
            var ex = Assert.Throws<Exception>(() => chatBusiness.GetChatById(0));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao foi achado"));
        }

        [Test]
        public void GetChatById()
        {
            chatRepository.Setup((x) => x.GetData(It.IsAny<string>(),It.IsAny<object>())).Returns(MockChat());
            var result = chatBusiness.GetChatById(932);
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateChatNull()
        {
            var ex = Assert.Throws<Exception>(() => chatBusiness.UpdateChat(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void UpdateChat()
        {
            chatRepository.Setup((x) => x.InstertOrUpdate(It.IsAny<Chat>(), It.IsAny<object>())).Returns(1);
            var result = chatBusiness.UpdateChat(MockChatDto()[0]);
            Assert.AreEqual(result, 1);
        }


        [Test]
        public void DeleteChatNull()
        {
            var ex = Assert.Throws<Exception>(() => chatBusiness.DeleteChatById(0));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void DeleteChat()
        {
            chatRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            chatMessageRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            chatBusiness.DeleteChatById(932);
        }



        [Test]
        public void InsertChatNull()
        {
            var ex = Assert.Throws<Exception>(() => chatBusiness.InsertChat(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void InsertChat()
        {
            chatRepository.Setup((x) => x.Add(It.IsAny<Chat>())).Returns(1);
            var result = chatBusiness.InsertChat(MockChatDto());
            Assert.IsNotNull(result);
        }
        

        [Test]
        public void InsertChatMessageNull()
        {
            var ex = Assert.Throws<Exception>(() => chatBusiness.InsertChatMessage(null));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao pode ser nulo"));
        }

        [Test]
        public void InsertChatMessage()
        {
            chatMessageRepository.Setup((x) => x.Add(It.IsAny<ChatMessages>())).Returns(1);
            var result = chatBusiness.InsertChatMessage(MockChatMessagesDto()[0]);
            Assert.IsNotNull(result);
        }


        [Test]
        public void DeleteChatMessageNull()
        {
            var ex = Assert.Throws<Exception>(() => chatBusiness.DeleteChatMessage(0));
            Assert.That(ex.Message, Is.EqualTo("Parametro nao foi achado"));
        }

        [Test]
        public void DeleteChatMessage()
        {
            chatMessageRepository.Setup((x) => x.Remove(It.IsAny<int>()));
            chatBusiness.DeleteChatById(932);
        }
        private List<Chat> MockChat()
        {
            return new List<Chat>(){
                new Chat()
                {
                    Id=1,
                    Messages = MockChatMessages()
                }
            };
        }
        private List<ChatDto> MockChatDto()
        {
            return new List<ChatDto>(){
                new ChatDto()
                {
                    Id=1,
                    Messages = MockChatMessagesDto()
                }
            };
        }
        private List<ChatMessages> MockChatMessages()
        {
            return new List<ChatMessages>(){
                new ChatMessages()
                {
                    Id=1,
                }
            };
        }


        private List<ChatMessagesDto> MockChatMessagesDto()
        {
            return new List<ChatMessagesDto>(){
                new ChatMessagesDto()
                {
                    Id=1,
                }
            };
        }
    }
}


