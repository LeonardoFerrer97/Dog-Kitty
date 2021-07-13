using System;
using System.Collections.Generic;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;

namespace MaisEad.Utils.Mappers
{
    public class AvaliacaoUsuarioMappers
    {
        public AvaliacaoUsuarioDto EntityToDto(AvaliacaoUsuario avaliacao)
        {
            return new AvaliacaoUsuarioDto()
            {
                Id = avaliacao.AvaliacaoUsuarioId,
                CursoId = avaliacao.CursoIdAvaliacao,
                Nota = avaliacao.Nota,
                InfraestruturaPoloApoio = avaliacao.InfraestruturaPoloApoio,
                OrganizacaoVirtual = avaliacao.OrganizacaoVirtual,
                QualidadeMaterial = avaliacao.QualidadeMaterial,
            };

        }

        public List<AvaliacaoUsuarioDto> ListEntityToListDto(IEnumerable<AvaliacaoUsuario> avaliacoes)
        {
            List<AvaliacaoUsuarioDto> dtos = new List<AvaliacaoUsuarioDto>();
            foreach (var avaliacaoUsuario in avaliacoes)
            {
                dtos.Add(EntityToDto(avaliacaoUsuario));

            }
            return dtos;
        }

        public AvaliacaoUsuario DtoToEntity(AvaliacaoUsuarioDto avaliacao)
        {
            return new AvaliacaoUsuario()
            {

                Nota = avaliacao.Nota,
                AvaliacaoUsuarioId = avaliacao.Id,
                CursoIdAvaliacao = avaliacao.CursoId,
                InfraestruturaPoloApoio = avaliacao.InfraestruturaPoloApoio,
                OrganizacaoVirtual = avaliacao.OrganizacaoVirtual,
                QualidadeMaterial = avaliacao.QualidadeMaterial,
            };
        }

        public List<AvaliacaoUsuario> ListDtoToListEntity(IEnumerable<AvaliacaoUsuarioDto> avaliacoes)
        {
            List<AvaliacaoUsuario> dtos = new List<AvaliacaoUsuario>();
            foreach (var avaliacaoUsuario in avaliacoes)
            {
                dtos.Add(DtoToEntity(avaliacaoUsuario));

            }
            return dtos;
        }

    }
}
