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
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBusiness usuarioBusiness;

        private readonly string connection;

        public UsuarioController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            usuarioBusiness = new UsuarioBusiness(connection);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDto>> Get()
        {
            return usuarioBusiness.GetAllUsuario();
        }


        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> Get(int id)
        {
            return usuarioBusiness.GetUsuarioById(id);
        }



        [HttpGet("email/{email}")]
        public ActionResult<UsuarioDto> GetByEmail(string email)
        {
            return usuarioBusiness.GetUsuarioByEmail(email);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] UsuarioDto usuario)
        {
            return usuarioBusiness.InsertUsuario(usuario);
        }

        [HttpPut()]
        public ActionResult<int> Put([FromBody]UsuarioDto usuario)
        {
            return usuarioBusiness.UpdateUsuarioById(usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usuarioBusiness.DeleteUsuarioById(id);
        }
    }
}
