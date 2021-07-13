using System;
using System.Collections.Generic;
using System.Linq;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;
using MaisEad.Repository.Repositories;
using MaisEad.Utils.Mappers;
using MaisEad.Utils.Query;

namespace MaisEad.Business
{
    public class AvaliacaoUsuarioBusiness
    {
        private readonly AvaliacaoUsuarioMappers mapper = new AvaliacaoUsuarioMappers();
        private readonly Repository<AvaliacaoUsuario> avaliacaoUsuarioRepository;

        public AvaliacaoUsuarioBusiness(string connection)
        {
            avaliacaoUsuarioRepository = new Repository<AvaliacaoUsuario>(connection);
        }


        public List<AvaliacaoUsuarioDto> GetAllAvaliacaoUsuarios()
        {
            IEnumerable<AvaliacaoUsuario> avaliacaoUsuarios= avaliacaoUsuarioRepository.All();

            List<AvaliacaoUsuarioDto> avaliacoesUsuario = mapper.ListEntityToListDto(avaliacaoUsuarios);
            return avaliacoesUsuario;
        }

        public AvaliacaoUsuarioDto GetAllAvaliacaoUsuariosByCursoId(int CursoIdAvaliacao)

        {
            object parameters = new { CursoIdAvaliacao };
            IEnumerable<AvaliacaoUsuario> avaliacaoUsuarios = avaliacaoUsuarioRepository.GetData(AvaliacaoUsuarioQueries.GET_AVALIACAOUSUARIO_BY_CURSO_ID,parameters);

            if (avaliacaoUsuarios.Count() == 0)
                return null;
            int soma = 0;
            int somaQualidade = 0;
            int somaInfra = 0;
            int somaOrg = 0;
            int count = 0;
            AvaliacaoUsuarioDto avaliacoesUsuario = new AvaliacaoUsuarioDto();
            foreach (var avaliacao in avaliacaoUsuarios)
            {
                if(count == 0)
                {
                    avaliacoesUsuario.CursoId = avaliacao.CursoIdAvaliacao;
                    avaliacoesUsuario.Id = avaliacao.AvaliacaoUsuarioId;
                }
                soma += avaliacao.Nota;
                somaQualidade += avaliacao.QualidadeMaterial;
                somaInfra += avaliacao.InfraestruturaPoloApoio;
                somaOrg += avaliacao.OrganizacaoVirtual;
                count++;
            }
            soma /= count;
            somaQualidade /= count;
            somaInfra /= count;
            somaOrg /= count;
            avaliacoesUsuario.Nota = soma;
            avaliacoesUsuario.OrganizacaoVirtual = somaOrg;
            avaliacoesUsuario.QualidadeMaterial = somaQualidade;
            avaliacoesUsuario.InfraestruturaPoloApoio = somaInfra;
            return avaliacoesUsuario;
        }

        public List<AvaliacaoUsuarioDto> GetAllAvaliacaoUsariosById(int Id)
        {
            object parameters = new { Id };
            IEnumerable<AvaliacaoUsuario> avaliacaoUsuarios = avaliacaoUsuarioRepository.GetData(AvaliacaoUsuarioQueries.GET_AVALIACAOUSUARIO_BY_ID,parameters);

            List<AvaliacaoUsuarioDto> avaliacoesUsuario = mapper.ListEntityToListDto(avaliacaoUsuarios);
            return avaliacoesUsuario;
        }
        
        public int UpdateAvaliacaoUsuario(AvaliacaoUsuarioDto AvaliacaoUsuario)
        {
            return avaliacaoUsuarioRepository.InstertOrUpdate(mapper.DtoToEntity(AvaliacaoUsuario), new { AvaliacaoUsuarioId = AvaliacaoUsuario.Id });
        }

        public void DeleteAvaliacaoUsuarioById(int AvaliacaoUsuarioId)
        {
            avaliacaoUsuarioRepository.Remove(new { AvaliacaoUsuarioId });
        }


        public void DeleteAvaliacaoUsuarioByCursoId(int CursoIdAvaliacao)
        {
            avaliacaoUsuarioRepository.Remove(new { CursoIdAvaliacao });
        }


        public int InsertAvaliacaoUsuario(List<AvaliacaoUsuarioDto> AvaliacaoUsuario)
        {
            return avaliacaoUsuarioRepository.Add(mapper.ListDtoToListEntity(AvaliacaoUsuario));
        }


    }
}
