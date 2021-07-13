using System;
namespace MaisEad.Utils.Query
{
    public class AvaliacaoUsuarioQueries
    {
        public static string GET_AVALIACAOUSUARIO = "SELECT * FROM AvaliacaoUsuario";
        public static string GET_AVALIACAOUSUARIO_BY_ID = "SELECT * FROM AvaliacaoUsuario WHERE AvaliacaoUsuarioId = @id";
        public static string GET_AVALIACAOUSUARIO_BY_CURSO_ID = "SELECT * FROM AvaliacaoUsuario WHERE CursoIdAvaliacao = @CursoIdAvaliacao";
    }
}
