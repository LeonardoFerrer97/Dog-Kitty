using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Dto;

namespace DogNKitty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController
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
        public ActionResult<UsuarioDto> GetById(int id)
        {
            return usuarioBusiness.GetUsuarioById(id);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody]UsuarioDto usuario)
        {
            return usuarioBusiness.InsertUsuario(usuario);
        }

        [HttpPut()]
        public ActionResult<int> Put([FromBody] UsuarioDto Usuario)
        {
            return usuarioBusiness.UpdateUsuario(Usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usuarioBusiness.DeleteUsuarioById(id);
        }
    }
}

