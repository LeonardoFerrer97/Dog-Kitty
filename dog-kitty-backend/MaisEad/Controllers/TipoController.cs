using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEad.Business;
using MaisEad.Dto.Dto;
using MaisEad.Utils.ConnectionStrings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MaisEad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCursoController : ControllerBase
    {
        private readonly TipoCursoBusiness TipoCursoBusiness;

        private readonly string connection;

        public TipoCursoController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            TipoCursoBusiness = new TipoCursoBusiness(connection);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoCursoDto>> Get()
        {
            return TipoCursoBusiness.GetAllTipoCurso();
        }


        [HttpGet("{id}")]
        public ActionResult<TipoCursoDto> Get(int id)
        {
            return TipoCursoBusiness.GetTipoCursoById(id);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] TipoCursoDto TipoCurso)
        {
            return TipoCursoBusiness.InsertTipoCurso(TipoCurso);
        }

        [HttpPut()]
        public ActionResult<int> Put([FromBody]TipoCursoDto TipoCurso)
        {
            return TipoCursoBusiness.UpdateTipoCursoById(TipoCurso);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TipoCursoBusiness.DeleteTipoCursoById(id);
        }
    }
}
