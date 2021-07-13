using System;
using System.Collections.Generic;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;

namespace MaisEad.Utils.Mappers
{
    public class CursoMappers
    {
        private static ComentarioMappers comentarioMappers = new ComentarioMappers();
        private static FaculdadeMappers faculdadeMappers = new FaculdadeMappers();
        private static AvaliacaoUsuarioMappers avaliacaoUsuarioMappers = new AvaliacaoUsuarioMappers();
        private static TipoCursoMappers TipoCursoMappers = new TipoCursoMappers();
        public CursoDto EntityToDto(Curso curso)
        {
            return new CursoDto()
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Faculdade = curso.Faculdade != null ? faculdadeMappers.EntityToDto(curso.Faculdade) : null,
                Comentario = curso.Comentarios != null ? comentarioMappers.ListEntityToListDto(curso.Comentarios) : null,
                AvaliacaoUsuario = curso.AvaliacaoUsuarios != null ? avaliacaoUsuarioMappers.EntityToDto(curso.AvaliacaoUsuarios) : null,
                Duracao = curso.Duracao,
                FaculdadeId = curso.FaculdadeId,
                Mensalidade = curso.Mensalidade,
                NotaMec = curso.NotaMec,
                PontoApoio = curso.PontoApoio,
                Url = curso.Url,
                TipoId = curso.TipoId,
                TipoCurso = curso.TipoCurso != null ? TipoCursoMappers.EntityToDto(curso.TipoCurso) : null,
            };

        }

        public List<CursoDto> ListEntityToListDto(IEnumerable<Curso> cursos)
        {
            List<CursoDto> dtos = new List<CursoDto>();
            foreach (var curso in cursos)
            {
                dtos.Add(EntityToDto(curso));

            }
            return dtos;
        }

        public Curso DtoToEntity(CursoDto curso)
        {
            return new Curso()
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Duracao = curso.Duracao,
                FaculdadeId = curso.FaculdadeId,
                Mensalidade = curso.Mensalidade,
                NotaMec = curso.NotaMec,
                PontoApoio = curso.PontoApoio,
                Url = curso.Url,
                TipoId = curso.TipoId,
            };
        }

        public List<Curso> ListDtoToListEntity(IEnumerable<CursoDto> cursos)
        {
            List<Curso> dtos = new List<Curso>();
            foreach (var curso in cursos)
            {
                dtos.Add(DtoToEntity(curso));

            }
            return dtos;
        }

    }
}
