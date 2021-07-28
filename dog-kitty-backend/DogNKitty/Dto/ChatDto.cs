using System;
using System.Collections.Generic;

namespace Dto
{
    public class ChatDto
    {
        public int Id { get; set; }
        public List<ChatMessagesDto> Messages { get; set; }
    }
}
