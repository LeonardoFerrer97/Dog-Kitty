using System;
namespace Entity
{
    public class Doacao
    {

        public int Id { get; set; }
        public Gato Gato { get; set; }
        public Cachorro Cachorro { get; set; }
        public string Localizacao { get; set; }
        public Usuario Usuario { get; set; }
        public Foto Foto { get; set; }
        public int QualidadeMaterial { get; set; }

    }
}
