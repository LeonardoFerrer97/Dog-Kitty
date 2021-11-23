using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utils.Queries
{
    public class ChatQueries
    {
        public static string GET_CHATS = "select c.id,c.title,c.usuario_id,c.date,u.id,u.email,u.nome,u.contato,u.endereco,u.isadmin,cm.id, cm.date, cm.message, cm.usuario_id, cm.chat_id,ucm.id,ucm.email,ucm.nome,ucm.contato,ucm.endereco,ucm.isadmin from kittydoggy.chat c left join kittydoggy.usuario u on c.usuario_id = u.id left join kittydoggy.chatmessages cm on cm.chat_id = c.id left join kittydoggy.usuario ucm on cm.usuario_id = ucm.id ";

    }
}
