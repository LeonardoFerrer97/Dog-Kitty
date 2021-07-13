using System;
namespace MaisEad.Entity.Entity
{
    public class Comentario
    {

        public int ComentarioId { get; set; }
        public string CommentTxt { get; set; }
        public int CursoId { get; set; }
        public string UserName { get; set; }
    }
}
