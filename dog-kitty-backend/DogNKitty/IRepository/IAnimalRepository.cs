using System;
using System.Collections.Generic;
using Entity;

namespace IRepository
{
    public interface IAnimalRepository
    {
        List<Animal> GetAnimal();
        Animal GetAnimalById(int id);
    }
}
