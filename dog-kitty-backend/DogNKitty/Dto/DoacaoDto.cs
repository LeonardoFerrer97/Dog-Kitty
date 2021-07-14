using System;
namespace Dto
{
    public class DoacaoDto
    {

        public int Id { get; set; }
        public string Localizacao { get; set; }
        public UsuarioDto Usuario { get; set; }
        public GatoDto Gato { get; set; }
        public CachorroDto Cachorro { get; set; }
        public FotoDto Foto { get; set; }
    }
}
