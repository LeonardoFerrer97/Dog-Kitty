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
    public class CursoController : ControllerBase
    {
        private readonly CursoBusiness cursoBusiness;

        private readonly string connection;

        public CursoController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            cursoBusiness = new CursoBusiness(connection);
        }


        [HttpGet]
        public ActionResult<IEnumerable<CursoDto>> Get()
        {
            return cursoBusiness.GetAllCursos();
        }

        [HttpGet("{id}")]
        public ActionResult<CursoDto> GetById(int id)
        {
            return cursoBusiness.GetCursoById(id);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody]CursoDto curso)
        {
            return cursoBusiness.PostCurso(curso);
        }

        [HttpPut]
        public ActionResult<int> Put([FromBody]CursoDto curso)
        {
            return cursoBusiness.UpdateCurso(curso);
        }


        [HttpDelete]
        public void Delete(int id)
        {
            cursoBusiness.DeleteCursoById(id);
        }

        [HttpGet("Filter")]
        public ActionResult<List<CursoDto>> GetCursoFiltered([FromQuery]CursoDto curso = null, string nomeFaculdade = null)
        {
            return cursoBusiness.GetCursoFiltered(curso, nomeFaculdade);
        }
    }
}
