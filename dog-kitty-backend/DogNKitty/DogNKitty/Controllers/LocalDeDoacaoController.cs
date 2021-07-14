using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Dto;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalDoacaoController : ControllerBase
    {
        private readonly LocalDoacaoBusiness localDeDoacaoBusiness;

        private readonly string connection;

        public LocalDoacaoController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            localDeDoacaoBusiness = new LocalDoacaoBusiness(connection);
        }


        [HttpGet]
        public ActionResult<IEnumerable<LocalAdocaoDto>> Get()
        {
            return localDeDoacaoBusiness.GetAllLocalAdocao();
        }


        [HttpGet("{id}")]
        public ActionResult<LocalAdocaoDto> GetById(int id)
        {
            return localDeDoacaoBusiness.GetLocalAdocaoById(id);
        }

        [HttpGet("usuario/{id}")]
        public ActionResult<LocalAdocaoDto> GetByDoacaoId(int id)
        {
            return localDeDoacaoBusiness.GetLocalAdocaoByDoacaoId(id);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] List<LocalAdocaoDto> doacaos)
        {
            return localDeDoacaoBusiness.InsertLocalAdocao(doacaos);
        }

        [HttpPut()]
        public ActionResult<int> Put([FromBody] LocalAdocaoDto LocalDeDoacao)
        {
            return localDeDoacaoBusiness.UpdateLocalAdocao(LocalDeDoacao);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            localDeDoacaoBusiness.DeleteLocalAdocaoById(id);
        }
    }
}
