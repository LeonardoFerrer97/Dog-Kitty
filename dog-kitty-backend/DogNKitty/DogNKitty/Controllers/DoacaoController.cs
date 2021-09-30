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

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoacaoController : ControllerBase
    {
        private readonly DoacaoBusiness doacaoBusiness;

        private readonly string connection;

        public DoacaoController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            doacaoBusiness = new DoacaoBusiness(connection);
        }


        [HttpGet("{status}")]
        public ActionResult<IEnumerable<DoacaoDto>> Get(StatusEnum status,int? usuarioId, string raca, PorteEnum? porte, SexoEnum? sexo, AnimalEnum? animal, string localizacao)
        {
            return doacaoBusiness.GetAllDoacaos(status,localizacao,raca,porte,sexo,animal ,usuarioId);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] DoacaoDto doacaos)
        {
            return doacaoBusiness.InsertDoacao(doacaos);
        }

        [HttpPut()]
        public ActionResult<int> Put([FromBody] DoacaoDto Doacao)
        {
            return doacaoBusiness.UpdateDoacao(Doacao);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            doacaoBusiness.DeleteDoacaoById(id);
        }

    }
}
