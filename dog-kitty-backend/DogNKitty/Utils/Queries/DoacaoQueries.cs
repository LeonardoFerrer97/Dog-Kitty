using System;
namespace Utils.Query
{
    public class DoacaoQueries
    {
        public static string GET_DOACAO = "SELECT * FROM Doacao";
        public static string GET_DOACAO_BY_ID = "SELECT * FROM Doacao WHERE DoacaoId = @id";
        public static string GET_DOACAO_BY_USUARIO_ID = "SELECT * FROM Doacao WHERE UsuarioId = @Id";
    }
}
