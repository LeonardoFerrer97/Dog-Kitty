using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Queries;
namespace Business
{
    public class ChatBusiness
    {
        private readonly ChatMapper mapper = new ChatMapper();
        private readonly ChatMessagesMapper chatMessagemapper = new ChatMessagesMapper();
        private readonly Repository<Chat> chatRepository;
        private readonly Repository<ChatMessages> chatMessageRepository;
        private readonly ChatRepository chatRepositoryCustom;

        public ChatBusiness(string connection)
        {
            chatRepository = new Repository<Chat>(connection);
            chatRepositoryCustom = new ChatRepository(connection);
            chatMessageRepository = new Repository<ChatMessages>(connection);
        }


        public List<ChatDto> GetAllChat(string title)
        {
            IEnumerable<Chat> doacaos = chatRepositoryCustom.GetChats(title);

            List<ChatDto> avaliacoesChat = mapper.ListEntityToListDto(doacaos);
            return avaliacoesChat;
        }

        public ChatDto GetChatById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            object parameters = new { Id };
            Chat chat = chatRepository.GetData("", parameters).FirstOrDefault();

            return mapper.EntityToDto(chat);
        }

        public int UpdateChat(ChatDto Chat)
        {
            if (Chat == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return chatRepository.InstertOrUpdate(mapper.DtoToEntity(Chat), new { DoacaoId = Chat.Id });
        }


        public void DeleteChatById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            chatMessageRepository.Remove(new { Chat_id = Id });
            chatRepository.Remove(new { Id });
        }


        public int InsertChat(List<ChatDto> Chat)
        {
            if (Chat == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return chatRepository.Add(mapper.ListDtoToListEntity(Chat));
        }
        public int InsertChatMessage(ChatMessagesDto Message)
        {
            if (Message == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return chatMessageRepository.Add(chatMessagemapper.DtoToEntity(Message));
        }
        public void DeleteChatMessage(int id)
        {
            if (id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            chatMessageRepository.Remove(new { id });
        }


    }
}

