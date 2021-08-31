using System;
namespace Dto
{
    public class DoacaoDto
    {

        public int Id { get; set; }
        public string Localizacao { get; set; }
        public UsuarioDto Usuario { get; set; }
        public AnimalDto Animal { get; set; }
        public string Descricao { get; set; }
    }
}
