using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;
using MaisEad.Interface.Repository.IRepository;
using MaisEad.Repository.Repositories;
using MaisEad.Utils.Mappers;
using MaisEad.Utils.Query;

namespace MaisEad.Business
{
    public class ComentarioBusiness
    {

        private readonly ComentarioMappers mapper = new ComentarioMappers();
        private readonly Repository<Comentario> comentarioRepository;
        
        public ComentarioBusiness(string connection)
        {
            comentarioRepository = new Repository<Comentario>(connection);
        }
        public List<ComentarioDto> GetAllComentarios()
        {
            IEnumerable<Comentario> comentarios = comentarioRepository.All();

            List<ComentarioDto> comentariosDto = mapper.ListEntityToListDto(comentarios);
            return comentariosDto;
        }

        public List<ComentarioDto> GetAllComentariosById(int Id)
        {
            object parameters = new { Id };
            IEnumerable<Comentario> comentarios = comentarioRepository.GetData(ComentarioQueries.GET_COMENTARIOS_BY_ID,parameters);

            List<ComentarioDto> comentariosDto = mapper.ListEntityToListDto(comentarios);
            return comentariosDto;
        }

        public List<ComentarioDto> GetAllComentariosByCursoId(int CursoId)
        {
            object parameters = new { CursoId };
            IEnumerable<Comentario> comentarios = comentarioRepository.GetData(ComentarioQueries.GET_COMENTARIOS_BY_CURSO_ID,parameters);

            List<ComentarioDto> comentariosDto = mapper.ListEntityToListDto(comentarios);
            return comentariosDto;
        }

        public int UpdateComentario(ComentarioDto comentario)
        {
            return comentarioRepository.InstertOrUpdate(mapper.DtoToEntity(comentario), new { ComentarioId = comentario.Id });
        }

        public void DeleteComentarioById(int ComentarioId)
        {
            comentarioRepository.Remove(new { ComentarioId });
        }

        public void DeleteComentarioByCursoId(int CursoId)
        {
            comentarioRepository.Remove(new { CursoId });
        }

        public int InsertComentario(ComentarioDto comentario)
        {
            return comentarioRepository.Add(mapper.DtoToEntity(comentario));
        }


        public int InsertComentarios(List<ComentarioDto> comentarios)
        {
            return comentarioRepository.Add(mapper.ListDtoToListEntity(comentarios));
        }

    }

}
