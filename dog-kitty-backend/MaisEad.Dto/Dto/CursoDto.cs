using System;
using System.Collections.Generic;

namespace MaisEad.Dto.Dto
{
    public class CursoDto
    {
        public int Id { get; set; }
        public TipoCursoDto TipoCurso { get; set; }
        public FaculdadeDto Faculdade { get; set; }
        public List<ComentarioDto> Comentario { get; set; }
        public AvaliacaoUsuarioDto AvaliacaoUsuario { get; set; }
        public int FaculdadeId { get; set; }
        public int TipoId { get; set; }
        public int NotaMec { get; set; }
        public string Duracao { get; set; }
        public string Url { get; set; }
        public string Nome { get; set; }
        public string PontoApoio { get; set; }
        public string Mensalidade { get; set; }
    }
}
