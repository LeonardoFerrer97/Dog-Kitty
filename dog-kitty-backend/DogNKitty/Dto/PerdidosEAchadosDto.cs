using System;
namespace Dto
{
    public class PerdidosEAchadosDto
    {
        public int Id { get; set; }
        public AnimalDto Animal { get; set; }
        public string Localizacao { get; set; }
        public UsuarioDto Usuario { get; set; }
        public FotoDto Foto { get; set; }
        public int Status { get; set; }
        public bool Perdido { get; set; }
    }
}
