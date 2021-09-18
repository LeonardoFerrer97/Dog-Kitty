using System;
namespace Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public bool IsAdmin { get; set; }
    }
}
