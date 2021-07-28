using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Dto;
using Utils.Enums;

namespace DogNKitty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController
    {
        private readonly AnimalBusiness animalBusiness;

        private readonly string connection;

        public AnimalController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            animalBusiness = new AnimalBusiness(connection);
        }


        [HttpGet]
        public ActionResult<IEnumerable<AnimalDto>> Get()
        {
            return animalBusiness.GetAllAnimals();
        }


        [HttpGet("{id}")]
        public ActionResult<AnimalDto> GetById(int id)
        {
            return animalBusiness.GetAnimalById(id);
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<AnimalDto>> GetByFilter(int id,string nome,StatusEnum? status, double? Peso,int? idade, PorteEnum? porte, SexoEnum? sexo)
        {
            return animalBusiness.GetAllAnimaisByFilter(id);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] List<AnimalDto> animals)
        {
            return animalBusiness.InsertAnimal(animals);
        }

        [HttpPut()]
        public ActionResult<int> Put([FromBody] AnimalDto Animal)
        {
            return animalBusiness.UpdateAnimal(Animal);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            animalBusiness.DeleteAnimalById(id);
        }

    }
}
