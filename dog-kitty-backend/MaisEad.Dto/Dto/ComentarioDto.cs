using System;
namespace MaisEad.Dto.Dto
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string CommentTxt { get; set; }
        public int CursoId { get; set; }
        public string UserName { get; set; }
    }
}
