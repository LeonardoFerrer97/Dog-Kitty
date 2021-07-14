using System;
namespace Entity
{
    public class PerdidosEAchados
    {
        public int Id { get; set; }
        public Animal Animal { get; set; }
        public string Localizacao { get; set; }
        public Usuario Usuario { get; set; }
        public Foto Foto { get; set; }
        public int Status { get; set; }
        public bool Perdido { get; set; }
    }
}
