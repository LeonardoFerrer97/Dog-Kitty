using System;
using System.Collections.Generic;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;
using MaisEad.Repository.Repositories;
using MaisEad.Utils.Mappers;
using MaisEad.Utils.Query;

namespace MaisEad.Business
{
    public class TipoCursoBusiness
    {
        private readonly TipoCursoMappers mapper = new TipoCursoMappers();
        private readonly Repository<TipoCurso> TipoCursoRepository;

        public TipoCursoBusiness(string connection)
        {
            TipoCursoRepository = new Repository<TipoCurso>(connection);
        }
        public List<TipoCursoDto> GetAllTipoCurso()
        {
            IEnumerable<TipoCurso> TipoCurso = TipoCursoRepository.All();
            return mapper.ListEntityToListDto(TipoCurso);
        }

        public TipoCursoDto GetTipoCursoById(int IdTipo)
        {
            return mapper.EntityToDto(TipoCursoRepository.Find(new { IdTipo }));
        }

        public int UpdateTipoCursoById(TipoCursoDto TipoCurso)
        {
            return TipoCursoRepository.InstertOrUpdate(mapper.DtoToEntity(TipoCurso), new {TipoCurso.IdTipo });
        }

        public void DeleteTipoCursoById(int FaculId)
        {
            TipoCursoRepository.Remove(new { FaculId });
        }

        public int InsertTipoCurso(TipoCursoDto TipoCurso)
        {
            return TipoCursoRepository.Add(mapper.DtoToEntity(TipoCurso));
        }
    }
}
