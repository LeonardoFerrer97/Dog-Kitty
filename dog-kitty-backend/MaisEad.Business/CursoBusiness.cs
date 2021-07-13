using System;
using System.Collections.Generic;
using System.Text;
using MaisEad.Dto.Dto;
using MaisEad.Entity.Entity;
using MaisEad.Repository.Repositories;
using MaisEad.Utils.Mappers;
using MaisEad.Utils.Query;

namespace MaisEad.Business
{
    public class CursoBusiness
    {
        private readonly CursoMappers mapper = new CursoMappers();
        private readonly Repository<Curso> cursoDapperRepository;
        private readonly ComentarioBusiness comentarioBusiness;
        private readonly AvaliacaoUsuarioBusiness avaliacaoUsuarioBusiness;
        private readonly FaculdadeBusiness faculdadeBusiness;
        private readonly CursoRepository cursoRepository;
        private readonly TipoCursoBusiness tipoCursoBusiness;

        public CursoBusiness(string connection)
        {
            cursoDapperRepository = new Repository<Curso>(connection);
            cursoRepository = new CursoRepository(connection);
            comentarioBusiness = new ComentarioBusiness(connection);
            avaliacaoUsuarioBusiness = new AvaliacaoUsuarioBusiness(connection);
            faculdadeBusiness = new FaculdadeBusiness(connection);
            tipoCursoBusiness = new TipoCursoBusiness(connection); 
        }


        public List<CursoDto> GetAllCursos()
        {
            IEnumerable<Curso> cursos = cursoRepository.getAllCursos();

            List<CursoDto> cursosDto = mapper.ListEntityToListDto(cursos);
            return cursosDto;
        }

        public CursoDto GetCursoById(int id)
        {
            Curso curso = cursoRepository.GetCursoById(id);

            CursoDto cursoDto = mapper.EntityToDto(curso);
            return cursoDto;
        }


        public int PostCurso(CursoDto cursoDto)
        {
            return cursoDapperRepository.Add(mapper.DtoToEntity(cursoDto));
        }

        public int UpdateCurso(CursoDto cursoDto)
        {
            return cursoDapperRepository.Update(mapper.DtoToEntity(cursoDto),new { cursoDto.Id});
        }


        public void DeleteCursoById(int Id)
        {
            comentarioBusiness.DeleteComentarioByCursoId(Id);
            avaliacaoUsuarioBusiness.DeleteAvaliacaoUsuarioByCursoId(Id);
            cursoDapperRepository.Remove(new { Id });
        }

        public List<CursoDto> GetCursoFiltered(CursoDto curso = null, string nomeFaculdade = null)
        {
            int faculdadeId = 0;
            if(nomeFaculdade != null)
            {
                var faculdade = faculdadeBusiness.GetFaculdadeByNome(nomeFaculdade);
                faculdadeId = faculdade == null ? faculdadeId : faculdade.Id;
            }
            object parameters = BuildParameters(curso);
            if (faculdadeId != 0)
            {
                curso.FaculdadeId = faculdadeId;
            }
            string query = BuildQuery(curso);

            if (parameters != null)
            {
                List<CursoDto> listaCursos = mapper.ListEntityToListDto(cursoDapperRepository.GetData(query, parameters));
                if (faculdadeId != 0)
                {
                    listaCursos = listaCursos.FindAll(x => x.FaculdadeId == faculdadeId);
                }
                foreach (var curs in listaCursos)
                {
                    curs.Faculdade = faculdadeBusiness.GetFaculdadeById(curs.FaculdadeId);
                    curs.TipoCurso = tipoCursoBusiness.GetTipoCursoById(curs.TipoId);
                    curs.AvaliacaoUsuario = avaliacaoUsuarioBusiness.GetAllAvaliacaoUsuariosByCursoId(curs.Id);
                }
                if(curso.TipoId != 0)
                {
                    return listaCursos.FindAll(x => x.TipoId == curso.TipoId);
                }
                return listaCursos ;
            }
            else
            {
                if(faculdadeId != 0)
                {
                    var cursoFinal = mapper.ListEntityToListDto(cursoDapperRepository.GetData(query,null)).FindAll(x => x.FaculdadeId == faculdadeId);
                    foreach(var cursoIndividual in cursoFinal)
                    {
                        cursoIndividual.Faculdade = faculdadeBusiness.GetFaculdadeByNome(nomeFaculdade);

                        cursoIndividual.AvaliacaoUsuario = avaliacaoUsuarioBusiness.GetAllAvaliacaoUsuariosByCursoId(cursoIndividual.Id);
                        cursoIndividual.TipoCurso = tipoCursoBusiness.GetTipoCursoById(cursoIndividual.TipoId);

                    }

                    if (curso.TipoId != 0)
                    {
                        return cursoFinal.FindAll(x => x.TipoId == curso.TipoId);
                    }
                    return cursoFinal;
                }
                else
                {
                    var cursos = mapper.ListEntityToListDto(cursoDapperRepository.GetData(query,null));
                    foreach(var curs in cursos) {
                        curs.Faculdade = faculdadeBusiness.GetFaculdadeById(curs.FaculdadeId);
                        curs.TipoCurso = tipoCursoBusiness.GetTipoCursoById(curs.TipoId);
                        curs.AvaliacaoUsuario = avaliacaoUsuarioBusiness.GetAllAvaliacaoUsuariosByCursoId(curs.Id);
                    }

                    if (curso.TipoId != 0)
                    {
                        return cursos.FindAll(x => x.TipoId == curso.TipoId);
                    }
                    return cursos;
                }
            }

            
        }
        private object BuildParameters(CursoDto curso = null)
        {
            if(curso.Nome != null)
            {
                if (curso.Duracao != null)
                {
                    if (curso.Mensalidade != null)
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, curso.NotaMec, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, curso.NotaMec, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, curso.NotaMec, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, curso.NotaMec };
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, };
                                }
                            }
                        }

                    }
                    else
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Duracao,curso.NotaMec, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Duracao,curso.NotaMec, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Duracao, curso.NotaMec, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Mensalidade, curso.NotaMec };
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Duracao, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Duracao, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Duracao, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Duracao };
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (curso.Mensalidade != null)
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome,curso.Mensalidade, curso.NotaMec, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Mensalidade, curso.NotaMec, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Mensalidade, curso.NotaMec, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome,  curso.Mensalidade, curso.NotaMec };
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome,  curso.Mensalidade, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Mensalidade, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome,curso.Mensalidade, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.Mensalidade, };
                                }
                            }
                        }

                    }
                    else
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome,curso.NotaMec, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.NotaMec, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome,  curso.NotaMec, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.NotaMec };
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Nome, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Nome };
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                if (curso.Duracao != null)
                {
                    if (curso.Mensalidade != null)
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Duracao, curso.Mensalidade, curso.NotaMec, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new {curso.Duracao, curso.Mensalidade, curso.NotaMec, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Duracao, curso.Mensalidade, curso.NotaMec, curso.Url };
                                }
                                else
                                {
                                    return new {  curso.Duracao, curso.Mensalidade, curso.NotaMec };
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Duracao, curso.Mensalidade, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new {curso.Duracao, curso.Mensalidade, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new {curso.Duracao, curso.Mensalidade, curso.Url };
                                }
                                else
                                {
                                    return new {curso.Duracao, curso.Mensalidade, };
                                }
                            }
                        }

                    }
                    else
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new {curso.Duracao, curso.NotaMec, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Duracao, curso.NotaMec, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new {  curso.Duracao, curso.NotaMec, curso.Url };
                                }
                                else
                                {
                                    return new {  curso.Duracao, curso.Mensalidade, curso.NotaMec };
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Duracao, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Duracao, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Duracao, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Duracao };
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (curso.Mensalidade != null)
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new {  curso.Mensalidade, curso.NotaMec, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new {  curso.Mensalidade, curso.NotaMec, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new {curso.Mensalidade, curso.NotaMec, curso.Url };
                                }
                                else
                                {
                                    return new {  curso.Mensalidade, curso.NotaMec };
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.Mensalidade, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new {  curso.Mensalidade, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new {curso.Mensalidade, curso.Url };
                                }
                                else
                                {
                                    return new { curso.Mensalidade, };
                                }
                            }
                        }

                    }
                    else
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new {curso.NotaMec, curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.NotaMec, curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new {curso.NotaMec, curso.Url };
                                }
                                else
                                {
                                    return new {  curso.NotaMec };
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    return new { curso.PontoApoio, curso.Url };
                                }
                                else
                                {
                                    return new { curso.PontoApoio };
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    return new {  curso.Url };
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }
            }
        }

        private string BuildQuery(CursoDto curso = null)
        {
            if(curso == null)
            {
                return CursoQueries.GET_ALL_CURSO_ONLY_CURSO;
            }
            StringBuilder query = new StringBuilder(CursoQueries.GET_ALL_CURSO_ONLY_CURSO);
            query.Append(" WHERE Id != 0");
            if(curso.FaculdadeId!= 0)
            {
                query = new StringBuilder(String.Format(CursoQueries.GET_ALL_CURSO_ONLY_CURSO_AND_FACULDADE, curso.FaculdadeId));
            }
            
            if (curso.Nome != null)
            {
                if (curso.Duracao != null)
                {
                    if (curso.Mensalidade != null)
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao LIKE @Duracao AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Nome LIKE @Nome AND Duracao LIKE @Duracao AND Mensalidade < @Mensalidade AND NotaMec LIKE @NotaMec");
                                    return query.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND Mensalidade < @Mensalidade Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND Mensalidade < @Mensalidade");
                                    return query.ToString();
                                }
                            }
                        }

                    }
                    else
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND NotaMec = @NotaMec AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND NotaMec = @NotaMec ");
                                    return query.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND PontoApoio LIKE @PontoApoio ");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Nome LIKE @Nome AND Duracao = @Duracao");
                                    return query.ToString();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (curso.Mensalidade != null)
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Nome LIKE @Nome AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio ");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec");
                                    return query.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Mensalidade < @Mensalidade AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Mensalidade < @Mensalidade AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Mensalidade < @Mensalidade AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Mensalidade < @Mensalidade ");
                                    return query.ToString();
                                }
                            }
                        }

                    }
                    else
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Nome LIKE @Nome AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND NotaMec = @NotaMec Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Nome LIKE @Nome AND NotaMec = @NotaMec");
                                    return query.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Nome LIKE @Nome AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Nome LIKE @Nome");
                                    return query.ToString();
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                if (curso.Duracao != null)
                {
                    if (curso.Mensalidade != null)
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec");
                                    return query.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Duracao = @Duracao AND Mensalidade < @Mensalidade AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Duracao = @Duracao AND Mensalidade < @Mensalidade");
                                    return query.ToString();
                                }
                            }
                        }

                    }
                    else
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Duracao = @Duracao  AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Duracao = @Duracao AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Duracao = @Duracao AND NotaMec = @NotaMec AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Duracao = @Duracao AND NotaMec = @NotaMec ");
                                    return query.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Duracao = @Duracao AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Duracao = @Duracao AND PontoApoio LIKE @PontoApoio ");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Duracao = @Duracao AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Duracao = @Duracao");
                                    return query.ToString();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (curso.Mensalidade != null)
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Mensalidade < @Mensalidade AND NotaMec < @NotaMec AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Mensalidade < @Mensalidade AND NotaMec < @NotaMec AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    query.Append(" AND Mensalidade < @Mensalidade AND NotaMec = @NotaMec");
                                    return query.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND Mensalidade < @Mensalidade AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Mensalidade < @Mensalidade AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Mensalidade < @Mensalidade AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND Mensalidade < @Mensalidade ");
                                    return query.ToString();
                                }
                            }
                        }

                    }
                    else
                    {
                        if (curso.NotaMec != 0)
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {
                                    query.Append(" AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND NotaMec = @NotaMec AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND NotaMec = @NotaMec AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND NotaMec = @NotaMec");
                                    return query.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (curso.PontoApoio != null)
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND PontoApoio LIKE @PontoApoio AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {

                                    query.Append(" AND PontoApoio LIKE @PontoApoio");
                                    return query.ToString();
                                }
                            }
                            else
                            {
                                if (curso.Url != null)
                                {

                                    query.Append(" AND Url LIKE @Url");
                                    return query.ToString();
                                }
                                else
                                {
                                    return query.ToString();
                                }
                            }
                        }
                    }

                }
            }

        }

    }


}
