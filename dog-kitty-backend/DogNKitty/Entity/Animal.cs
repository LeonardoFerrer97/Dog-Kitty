using System;
using System.Collections.Generic;
using Utils.Enums;

namespace Entity
{
    public class Animal
    { 
        public int Id { get; set; }
        public int Nome { get; set; }
        public StatusEnum Status { get; set; }
        public List<Foto> Foto { get; set; }
        public double Peso { get; set; }
        public int Idade { get; set; }
        public SexoEnum Sexo { get; set; }
        public PorteEnum Porte { get; set; }
    }
}
