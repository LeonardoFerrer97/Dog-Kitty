using System;
using System.Collections.Generic;

namespace Dto
{
    public class LocalAdocaoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public List<DoacaoDto> Doacoes { get; set; }
    }
}
