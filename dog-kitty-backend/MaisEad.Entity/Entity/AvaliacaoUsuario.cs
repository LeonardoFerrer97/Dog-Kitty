using System;
namespace MaisEad.Entity.Entity
{
    public class AvaliacaoUsuario
    {

        public int AvaliacaoUsuarioId { get; set; }
        public int CursoIdAvaliacao { get; set; }
        public int Nota { get; set; }
        public int OrganizacaoVirtual { get;set;}
        public int InfraestruturaPoloApoio { get;set;}
        public int QualidadeMaterial { get;set;}

    }
}
