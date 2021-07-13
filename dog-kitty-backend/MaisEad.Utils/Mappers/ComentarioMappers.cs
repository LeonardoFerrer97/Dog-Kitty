using System;
using System.Collections.Generic;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;

namespace MaisEad.Utils.Mappers
{
    public class ComentarioMappers
    {
        public ComentarioDto EntityToDto(Comentario comentario)
        {
            return new ComentarioDto()
            {
                Id = comentario.ComentarioId,
                CommentTxt = comentario.CommentTxt,
                CursoId = comentario.CursoId,
                UserName = comentario.UserName
            };

        }

        public List<ComentarioDto> ListEntityToListDto(IEnumerable<Comentario> comentarios)
        {
            List<ComentarioDto> dtos = new List<ComentarioDto>();
            foreach (var comentario in comentarios)
            {
                dtos.Add(EntityToDto(comentario));

            }
            return dtos;
        }

        public Comentario DtoToEntity(ComentarioDto comentario)
        {
            return new Comentario()
            {
                ComentarioId = comentario.Id,
                CommentTxt = comentario.CommentTxt,
                CursoId = comentario.CursoId,
                UserName = comentario.UserName
            };
        }

        public List<Comentario> ListDtoToListEntity(List<ComentarioDto> comentarios)
        {
            List<Comentario> dtos = new List<Comentario>();
            foreach (var comentario in comentarios)
            {
                dtos.Add(DtoToEntity(comentario));

            }
            return dtos;
        }
    }
}
