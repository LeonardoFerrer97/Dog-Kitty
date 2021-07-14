using System;
namespace Utils.Queries
{
    public class LocalAdocaoQueries
    {
        public static string GET_LOCAL_DOACAO = "SELECT * FROM Doacao";
        public static string GET_LOCAL_DOACAO_BY_ID = "SELECT * FROM Doacao WHERE DoacaoId = @id";
    }
}
