using System;
namespace Dto
{
    public class ChatMessagesDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public UsuarioDto Usuario { get; set; }
        public DateTime Date { get; set; }
    }
}
