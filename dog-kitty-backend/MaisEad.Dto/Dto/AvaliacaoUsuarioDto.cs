using System;
namespace MaisEad.Dto.Dto
{
    public class AvaliacaoUsuarioDto
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int Nota { get; set; }
        public int OrganizacaoVirtual { get; set; }
        public int InfraestruturaPoloApoio { get; set; }
        public int QualidadeMaterial { get; set; }
    }
}
