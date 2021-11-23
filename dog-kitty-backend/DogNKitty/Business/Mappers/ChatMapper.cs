using System;
using System.Collections.Generic;
using Dto;
using Entity;
namespace Business.Mappers
{
    public class ChatMapper
    {
        private readonly ChatMessagesMapper mapper = new ChatMessagesMapper();
        private readonly UsuarioMapper usuarioMapper = new UsuarioMapper();
        public ChatDto EntityToDto(Chat chat)
        {
            return new ChatDto()
            {
                Id = chat.Id,
                Messages = mapper.ListEntityToListDto(chat.Messages),
                Date = chat.Date,
                Usuario = usuarioMapper.EntityToDto(chat.Usuario),
                Title = chat.Title,
                UsuarioId = chat.Usuario_Id
            };
        }
        public List<ChatDto> ListEntityToListDto(IEnumerable<Chat> chats)
        {
            List<ChatDto> dtos = new List<ChatDto>();
            foreach (var chat in chats)
            {
                dtos.Add(EntityToDto(chat));

            }
            return dtos;
        }

        public Chat DtoToEntity(ChatDto chat)
        {
            return new Chat()
            {
                Id = chat.Id,
                Messages = mapper.ListDtoToListEntity(chat.Messages),
                Usuario = usuarioMapper.DtoToEntity(chat.Usuario),
                Date = chat.Date,
                Title = chat.Title,
                Usuario_Id = chat.UsuarioId
            };
        }
        public List<Chat> ListDtoToListEntity(IEnumerable<ChatDto> chats)
        {
            List<Chat> dtos = new List<Chat>();
            foreach (var chat in chats)
            {
                dtos.Add(DtoToEntity(chat));

            }
            return dtos;
        }
    }
}
