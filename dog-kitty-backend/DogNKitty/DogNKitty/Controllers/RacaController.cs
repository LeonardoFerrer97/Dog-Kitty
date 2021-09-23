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
    public class RacaController
    {
        private readonly RacaBusiness racaBusiness;

        private readonly string connection;

        public RacaController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            racaBusiness = new RacaBusiness(connection);
        }


        [HttpGet]
        public ActionResult<List<RacaDto>> Get()
        {
            return racaBusiness.GetAllRaca();
        }


        [HttpPost]
        public ActionResult<int> Post([FromBody]RacaDto raca)
        {
            return racaBusiness.InsertRaca(raca);
        }
    }
}
