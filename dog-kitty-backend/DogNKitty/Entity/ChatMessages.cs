using System;
namespace Entity
{
    public class ChatMessages
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public Usuario Usuario { get; set; }
        public int Usuario_id { get; set; }
        public Chat Chat { get; set; }
        public int Chat_id { get; set; }
    }
}
