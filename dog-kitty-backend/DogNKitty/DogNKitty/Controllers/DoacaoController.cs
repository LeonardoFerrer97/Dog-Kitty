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
    public class DoacaoController : ControllerBase
    {
        private readonly DoacaoBusiness doacaoBusiness;

        private readonly string connection;

        public DoacaoController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            doacaoBusiness = new DoacaoBusiness(connection);
        }


        [HttpGet]
        public ActionResult<IEnumerable<DoacaoDto>> Get()
        {
            return doacaoBusiness.GetAllDoacaos();
        }


        [HttpGet("{id}")]
        public ActionResult<DoacaoDto> GetById(int id)
        {
            return doacaoBusiness.GetDoacaoById(id);
        }

        [HttpGet("usuario/{id}")]
        public ActionResult<IEnumerable<DoacaoDto>> GetByUsuarioId(int id)
        {
            return doacaoBusiness.GetAllDoacoesByUsuarioId(id);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] List<DoacaoDto> doacaos)
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
        [HttpDelete("usuario/{id}")]
        public void DeleteDoacaoByUsuario(int id)
        {
            doacaoBusiness.DeleteDoacaoByUsuario(id);
        }

    }
}
