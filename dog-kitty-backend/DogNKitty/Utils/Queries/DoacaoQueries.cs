using System;
namespace Utils.Query
{
    public class DoacaoQueries
    {

        public static string GET_DOACAO = "select  d.id,d.localizacao,d.descricao,d.usuario_id,u.id,u.email,u.nome,u.contato,u.endereco,u.isadmin, a.id,a.doacao_id,a.raca_id,a.nome,status,peso,idade,sexo,porte,tipoanimal,f.id,imagem,f.animal_id,r.id,r.nome from kittydoggy.doacao d inner join kittydoggy.usuario u on d.usuario_id = u.id inner join kittydoggy.animal a on a.doacao_id = d.id inner join kittydoggy.raca r on r.id = a.raca_id left join kittydoggy.foto f on f.animal_id  = a.id WHERE 1=1";
        public static string GET_DOACAO_BY_ID = "select  d.id,d.localizacao,d.descricao,d.usuario_id,u.id,u.email,u.nome,u.contato,u.endereco,u.isadmin from kittydoggy.doacao d left join kittydoggy.usuario u on d.usuario_id = u.id WHERE d.id = {0}";
        public static string GET_DOACAO_BY_USUARIO_ID = "SELECT * FROM Doacao WHERE UsuarioId = @Id";
        public static string INSERT_DOACAO = "INSERT INTO kittydoggy.doacao (localizacao, descricao, usuario_id) VALUES({0}, {1}, {2}) RETURNING id;";
    }
}
