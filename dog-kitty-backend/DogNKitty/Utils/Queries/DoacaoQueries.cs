using System;
namespace Utils.Query
{
    public class DoacaoQueries
    {

        public static string GET_DOACAO = "select  d.id,d.localizacao,d.descricao,d.usuario_id,u.id,u.email,u.nome,u.contato,u.endereco,u.isadmin from kittydoggy.doacao d left join kittydoggy.usuario u on d.usuario_id = u.id WHERE 1=1";
        public static string GET_DOACAO_BY_ID = "select  d.id,d.localizacao,d.descricao,d.usuario_id,u.id,u.email,u.nome,u.contato,u.endereco,u.isadmin from kittydoggy.doacao d left join kittydoggy.usuario u on d.usuario_id = u.id WHERE d.id = {0}";
        public static string GET_DOACAO_BY_USUARIO_ID = "SELECT * FROM Doacao WHERE UsuarioId = @Id";
        public static string INSERT_DOACAO = "INSERT INTO kittydoggy.doacao (localizacao, descricao, usuario_id) VALUES({0}, {1}, {2}) RETURNING id;";
    }
}
