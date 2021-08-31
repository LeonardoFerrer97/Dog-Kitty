using System;
namespace Entity
{
    public class Doacao
    {

        public int Id { get; set; }
        public Animal Animal { get; set; }
        public string Localizacao { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }

    }
}
