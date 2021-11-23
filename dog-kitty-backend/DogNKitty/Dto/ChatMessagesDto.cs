using System;
namespace Dto
{
    public class ChatMessagesDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int Usuario_id { get; set; }
        public ChatDto Chat { get; set; }
        public int Chat_id { get; set; }
        public DateTime Date { get; set; }
    }
}
