using System;
namespace Utils.Queries
{
    public class AnimalQueries
    {
        public static string GET_ANIMAL = "SELECT * FROM Doacao";
        public static string GET_ANIMAL_BY_ID = "SELECT * FROM Doacao WHERE DoacaoId = @id";
        public static string GET_ANIMAL_BY_FILTER = "SELECT * FROM Doacao WHERE UsuarioId = @Id";
    }
}
