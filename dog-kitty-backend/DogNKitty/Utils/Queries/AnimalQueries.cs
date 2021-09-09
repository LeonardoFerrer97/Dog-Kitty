using System;
namespace Utils.Queries
{
    public class AnimalQueries
    {
        public static string GET_ANIMAL = "select  a.id,a.nome,status,peso,idade,sexo,porte,tipoanimal,f.id,imagem,f.animal_id,r.id,r.nome,r.animal_id from kittydoggy.animal a left join kittydoggy.raca r on r.animal_id = a.id left join kittydoggy.foto f on f.animal_id  = a.id ";
        public static string GET_ANIMAL_BY_ID = "select  a.id,a.nome,status,peso,idade,sexo,porte,tipoanimal,f.id,imagem,f.animal_id,r.id,r.nome,r.animal_id from kittydoggy.animal a left join kittydoggy.raca r on r.animal_id = a.id left join kittydoggy.foto f on f.animal_id  = a.id WHERE a.id = {0}";
        public static string GET_ANIMAL_BY_FILTER = "SELECT * FROM Doacao WHERE UsuarioId = @Id";
    }
}
