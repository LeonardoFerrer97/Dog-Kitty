using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Queries;
namespace Business
{
    public class UsuarioBusiness
    {
        private readonly UsuarioMapper mapper = new UsuarioMapper();
        private readonly Repository<Usuario> usuarioRepository;
        private readonly Repository<Chat> chatRepository;
        private readonly Repository<ChatMessages> chatMessagesRepository;
        private readonly Repository<Doacao> doacaoRepository;
        private readonly Repository<Animal> animalRepository;

        public UsuarioBusiness(string connection)
        {
            usuarioRepository = new Repository<Usuario>(connection);
            chatRepository = new Repository<Chat>(connection);
            chatMessagesRepository = new Repository<ChatMessages>(connection);
            doacaoRepository = new Repository<Doacao>(connection);
            animalRepository = new Repository<Animal>(connection);
        }


        public List<UsuarioDto> GetAllUsuario()
        {
            IEnumerable<Usuario> doacaos = usuarioRepository.All();

            List<UsuarioDto> avaliacoesUsuario = mapper.ListEntityToListDto(doacaos);
            return avaliacoesUsuario;
        }

        public UsuarioDto GetUsuarioById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            object parameters = new { Id };
            Usuario usuario = usuarioRepository.GetData( parameters).FirstOrDefault();
            if (usuario == null)
            {
                return null;
            }
            return mapper.EntityToDto(usuario);
        }
        
        public UsuarioDto GetUsuarioByEmail(string Email)
        {
            if (Email == "")
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            object parameters = new { Email };
            Usuario usuario = usuarioRepository.GetData(parameters).FirstOrDefault();
            if(usuario == null)
            {
                return null;
            }
            return mapper.EntityToDto(usuario);
        }
        public int UpdateUsuario(UsuarioDto Usuario)
        {
            if (Usuario == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return usuarioRepository.InstertOrUpdate(mapper.DtoToEntity(Usuario), new { email = Usuario.Email });
        }

        public void DeleteUsuarioById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            chatMessagesRepository.Remove(new { usuario_id = Id });
            chatRepository.Remove(new { usuario_id = Id });
            var doacoes = doacaoRepository.GetData(new { usuario_id = Id });
            if (doacoes != null)
            {
                foreach(var doacao in doacoes)
                {
                    animalRepository.Remove(new { doacao_id = doacao.Id });
                }
            }
            doacaoRepository.Remove(new { usuario_id = Id });
            usuarioRepository.Remove(new { Id });
        }


        public int InsertUsuario(UsuarioDto Usuario)
        {
            if (Usuario == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return usuarioRepository.Add(mapper.DtoToEntity(Usuario));
        }


    }
}
