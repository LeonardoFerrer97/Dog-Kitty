using System;
using System.Collections.Generic;

namespace Entity
{
    public class Chat
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ChatMessages> Messages { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Date { get; set; }
    }
}
