using Dapper;
using Entity;
using IRepository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utils.Queries;

namespace Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly IDbConnection conn;
        public string connectionString; 
        public ChatRepository(string connection, char parameterIdentified = '@')
        {

            conn = new NpgsqlConnection(connection);
            connectionString = connection;
        }
        public List<Chat> GetChats(string title)
        {
            using (conn)
            {
                var sql = ChatQueries.GET_CHATS;
                if (!string.IsNullOrWhiteSpace(title))
                {
                    sql += "WHERE title LIKE %" + title + "%";
                }
                var dictionaryChat = new Dictionary<int, Chat>();
                var result = conn.Query<Chat, Usuario, Chat>(sql, (c,u) =>
                {
                    if (!dictionaryChat.TryGetValue(c.Id, out Chat aEntry))
                    {
                        aEntry = c;
                        dictionaryChat.Add(aEntry.Id, aEntry);
                    }
                    if (u!= null)
                    {
                        aEntry.Usuario = u;
                    }
                    return aEntry;
                }, null, splitOn: "id,id,id").AsList();
                return result;
            }
        }
    }
}
