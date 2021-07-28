using System;
using System.Collections.Generic;
using Dto;
using Entity;

namespace Business.Mappers
{
    public class ChatMessagesMapper
    {
        private readonly UsuarioMapper mapper = new UsuarioMapper();
        public ChatMessagesDto EntityToDto(ChatMessages chatMessage)
        {
            return new ChatMessagesDto()
            {
                Id = chatMessage.Id,
                Usuario = mapper.EntityToDto(chatMessage.Usuario),
                Message = chatMessage.Message
            };
        }
        public List<ChatMessagesDto> ListEntityToListDto(IEnumerable<ChatMessages> chatMessages)
        {
            List<ChatMessagesDto> dtos = new List<ChatMessagesDto>();
            foreach (var chatMessage in chatMessages)
            {
                dtos.Add(EntityToDto(chatMessage));

            }
            return dtos;
        }

        public ChatMessages DtoToEntity(ChatMessagesDto chatMessage)
        {
            return new ChatMessages()
            {
                Id = chatMessage.Id,
                Usuario = mapper.DtoToEntity(chatMessage.Usuario),
                Message = chatMessage.Message
            };
        }

        public List<ChatMessages> ListDtoToListEntity(IEnumerable<ChatMessagesDto> chatMessages)
        {
            List<ChatMessages> dtos = new List<ChatMessages>();
            foreach (var chatMessage in chatMessages)
            {
                dtos.Add(DtoToEntity(chatMessage));

            }
            return dtos;
        }

    }
}
