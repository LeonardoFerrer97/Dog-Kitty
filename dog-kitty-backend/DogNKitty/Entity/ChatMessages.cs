using System;
namespace Entity
{
    public class ChatMessages
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Usuario Usuario { get; set; }
    }
}
