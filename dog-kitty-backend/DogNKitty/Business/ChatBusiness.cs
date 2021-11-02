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
        private readonly Repository<Chat> chatRepository;
        private readonly ChatRepository chatRepositoryCustom;

        public ChatBusiness(string connection)
        {
            chatRepository = new Repository<Chat>(connection);
            chatRepositoryCustom = new ChatRepository(connection);
        }


        public List<ChatDto> GetAllChat(string title)
        {
            IEnumerable<Chat> doacaos = chatRepositoryCustom.GetChats(title);

            List<ChatDto> avaliacoesChat = mapper.ListEntityToListDto(doacaos);
            return avaliacoesChat;
        }

        public ChatDto GetChatByDoacaoId(int CursoIdAvaliacao)
        {
            object parameters = new { CursoIdAvaliacao };
            Chat chats = chatRepository.GetData("", parameters).FirstOrDefault();
            return mapper.EntityToDto(chats);
        }
        

        public ChatDto GetFromTitle(string title)
        {
            object parameters = new { title };
            Chat chats = chatRepository.GetData("", parameters).FirstOrDefault();
            return mapper.EntityToDto(chats);
        }

        public ChatDto GetChatById(int Id)
        {
            object parameters = new { Id };
            Chat chat = chatRepository.GetData("", parameters).FirstOrDefault();

            return mapper.EntityToDto(chat);
        }

        public int UpdateChat(ChatDto Chat)
        {
            return chatRepository.InstertOrUpdate(mapper.DtoToEntity(Chat), new { DoacaoId = Chat.Id });
        }

        public void DeleteDoacaoById(int DoacaoId)
        {
            chatRepository.Remove(new { DoacaoId });
        }


        public void DeleteChatById(int Id)
        {
            chatRepository.Remove(new { Id });
        }


        public int InsertChat(List<ChatDto> Chat)
        {
            return chatRepository.Add(mapper.ListDtoToListEntity(Chat));
        }
        public int InsertChatMessage(ChatMessagesDto Message)
        {
            return 1;
        }


    }
}

