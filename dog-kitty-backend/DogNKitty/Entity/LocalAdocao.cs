using System;
using System.Collections.Generic;

namespace Entity
{
    public class LocalAdocao
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public Usuario Usuario { get; set; }
        public List<Doacao> Doacoes { get; set; }
    }
}
