using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utils.Queries
{
    public class ChatQueries
    {
        public static string GET_CHATS = "select c.title,c.usuario_id,c.date,u.id,u.email,u.nome,u.contato,u.endereco,u.isadmin from kittydoggy.chat c left join kittydoggy.usuario u on c.usuario_id = u.id ";

    }
}
