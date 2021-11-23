using System;
using System.Collections.Generic;

namespace Dto
{
    public class ChatDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ChatMessagesDto> Messages { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Date { get; set; }
    }
}
