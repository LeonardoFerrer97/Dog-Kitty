using System;
using System.Collections.Generic;

namespace Entity
{
    public class Chat
    {
        public int Id { get; set; }
        public List<ChatMessages> Messages { get; set; }
    }
}
