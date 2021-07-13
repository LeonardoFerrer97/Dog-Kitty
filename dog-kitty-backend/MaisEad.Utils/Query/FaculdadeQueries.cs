using System;
namespace MaisEad.Utils.Query
{
    public class FaculdadeQueries
    {
        public static string GET_ALL_FACULDADE = "SELECT * FROM Faculdade";
        public static string GET_FACULDADE_BY_ID = "SELECT * FROM Faculdade WHERE Id = @Id";

        public static string GET_FACULDADE_BY_NOME = "SELECT * FROM Faculdade WHERE NomeFaculdade LIKE '%%{0}%%'";
        public static string UPDATE_FACULDADE_BY_ID = "UPDATE Faculdade SET NomeFaculdade = '@Nome' , Endereco = '@Endereco',NotaMec = @NotaMec WHERE id = @Id";
        public static string DELETE_FACULDADE_BY_ID = "DELETE FROM Faculdade WHERE Id = @Id";
        public static string INSERT_FACULDADE = "INSERT INTO Faculdade (Nome,Endereco,NotaMec) VALUES ('@Nome','@Endereco',@NotaMec)";
    }
}
