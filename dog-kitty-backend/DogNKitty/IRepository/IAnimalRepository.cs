using System;
using System.Collections.Generic;
using Entity;
using Utils.Enums;

namespace IRepository
{
    public interface IAnimalRepository
    {
        List<Animal> GetAnimal(string nome, StatusEnum? status, double? peso, int? idade, SexoEnum? sexo, PorteEnum? porte, AnimalEnum? tipoAnimal);
        Animal GetAnimalById(int id);
    }
}
