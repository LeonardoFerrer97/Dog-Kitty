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
    public class AvaliacaoUsuarioController : ControllerBase
    {
        private readonly AvaliacaoUsuarioBusiness avaliacaoUsuarioBusiness;

        private readonly string connection;

        public AvaliacaoUsuarioController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            avaliacaoUsuarioBusiness = new AvaliacaoUsuarioBusiness(connection);
        }


        [HttpGet]
        public ActionResult<IEnumerable<AvaliacaoUsuarioDto>> Get()
        {
            return avaliacaoUsuarioBusiness.GetAllAvaliacaoUsuarios();
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AvaliacaoUsuarioDto>> GetById(int id)
        {
            return avaliacaoUsuarioBusiness.GetAllAvaliacaoUsariosById(id);
        }

        [HttpGet("curso/{id}")]
        public ActionResult<AvaliacaoUsuarioDto> GetByCursoId(int id)
        {
            return avaliacaoUsuarioBusiness.GetAllAvaliacaoUsuariosByCursoId(id);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] List<AvaliacaoUsuarioDto> avaliacaoUsuarios)
        {
            return avaliacaoUsuarioBusiness.InsertAvaliacaoUsuario(avaliacaoUsuarios);
        }

        [HttpPut()]
        public ActionResult<int> Put([FromBody]AvaliacaoUsuarioDto AvaliacaoUsuario)
        {
            return avaliacaoUsuarioBusiness.UpdateAvaliacaoUsuario(AvaliacaoUsuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            avaliacaoUsuarioBusiness.DeleteAvaliacaoUsuarioById(id);
        }


        [HttpDelete("curso/{id}")]
        public void DeleteByCursoId(int id)
        {
            avaliacaoUsuarioBusiness.DeleteAvaliacaoUsuarioByCursoId(id);
        }


    }
}
