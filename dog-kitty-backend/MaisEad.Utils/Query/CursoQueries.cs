using System;
namespace MaisEad.Utils.Query
{
    public class CursoQueries
    {
        public static string GET_ALL_CURSOS = "SELECT " +
            "Id," +
            "NotaMec," +
            "Nome," +
            "Duracao," +
            "FaculdadeId," +
            "Mensalidade," +
            "Url," +
            "PontoApoio," +
            "FaculId," +
            "NotaMecFaculdade," +
            "Endereco," +
            "NomeFaculdade," +
            "ComentarioId," +
            "CursoId," +
            "CommentTxt," +
            "UserName," +
            "AvaliacaoUsuarioId" +
            ",CursoIdAvaliacao " +
            ",Nota" +
            ", IdTipo " +
            ", NomeTipo "+
            "FROM Curso inner join Faculdade " +
            "on Faculdade.FaculId = Curso.FaculdadeId " +
            "inner join TipoCurso on Curso.TipoId = TipoCurso.IdTipo " +
            "left join Comentario on Curso.Id = comentario.CursoId " +
            "left join AvaliacaoUsuario on Curso.Id = AvaliacaoUsuario.CursoIdAvaliacao";

        public static string GET_ALL_CURSOS_BY_ID = "SELECT " +
        "Id," +
        "NotaMec," +
        "Nome," +
        "Duracao," +
        "FaculdadeId," +
        "Mensalidade," +
        "Url," +
        "PontoApoio," +
        "FaculId," +
        "NotaMecFaculdade," +
        "Endereco," +
        "NomeFaculdade," +
        "ComentarioId," +
        "CursoId," +
        "CommentTxt," +
        "UserName," +
        "AvaliacaoUsuarioId" +
        ",CursoIdAvaliacao" +
        ",Nota " +
        ",IdTipo " +
        ",NomeTipo "+
        "FROM Curso inner join Faculdade " +
        "on Faculdade.FaculId = Curso.FaculdadeId " +
        "inner join TipoCurso on TipoCurso.IdTipo = Curso.TipoId " +
        "left join Comentario on Curso.Id = comentario.CursoId " +
        "left join AvaliacaoUsuario on Curso.Id = AvaliacaoUsuario.CursoIdAvaliacao " +
        "WHERE Curso.Id = {0}";


        public static string GET_ALL_CURSO_ONLY_CURSO_AND_FACULDADE = "SELECT * FROM Curso INNER JOIN Faculdade ON FaculdadeId = FaculId WHERE FaculdadeId = {0}";

        public static string GET_ALL_CURSO_ONLY_CURSO = "SELECT * FROM Curso";
    }
}
