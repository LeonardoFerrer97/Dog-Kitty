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
    public class ComentarioController : ControllerBase
    {
        private readonly string connection;
        private readonly ComentarioBusiness comentarioBusiness;

        public ComentarioController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            comentarioBusiness = new ComentarioBusiness(connection);
        }


        [HttpGet]
        public ActionResult<IEnumerable<ComentarioDto>> Get()
        {
            return comentarioBusiness.GetAllComentarios();
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ComentarioDto>> GetById(int id)
        {
            return comentarioBusiness.GetAllComentariosById(id);
        }

        [HttpGet("curso/{id}")]
        public ActionResult<IEnumerable<ComentarioDto>> GetByCursoId(int id)
        {
            return comentarioBusiness.GetAllComentariosByCursoId(id);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] ComentarioDto Comentario)
        {
            return comentarioBusiness.InsertComentario(Comentario);
        }

        [HttpPost("lista")]
        public ActionResult<int> Post([FromBody] List<ComentarioDto> Comentario)
        {
            return comentarioBusiness.InsertComentarios(Comentario);
        }



        [HttpPut()]
        public ActionResult<int> Put([FromBody]ComentarioDto Comentario)
        {
            return comentarioBusiness.UpdateComentario(Comentario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            comentarioBusiness.DeleteComentarioById(id);
        }

        [HttpDelete("curso/{id}")]
        public void DeleteByCursoId(int id)
        {
            comentarioBusiness.DeleteComentarioByCursoId(id);
        }


    }
}
