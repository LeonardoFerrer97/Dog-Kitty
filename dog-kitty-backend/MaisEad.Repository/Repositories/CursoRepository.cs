using System;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using MaisEad.Entity.Entity;
using System.Collections.Generic;
using MaisEad.Utils.Query;
using System.Linq;
using MaisEad.Entity;

namespace MaisEad.Repository.Repositories
{
    public class CursoRepository
    {
        private readonly IDbConnection conn;
        public CursoRepository(string connection)
        {
            conn = new MySqlConnection(connection);
        }

        public List<Curso> getAllCursos()
        {
            using (conn)
            {
                var dictionaryCurso = new Dictionary<int, Curso>();
                var result = conn.Query<Curso, Faculdade, Comentario,AvaliacaoUsuario,TipoCurso,Curso>(CursoQueries.GET_ALL_CURSOS, (cu,fa,co,avu,ti) =>
                {
                    if (!dictionaryCurso.TryGetValue(cu.Id, out Curso cuEntry))
                    {
                        cuEntry = cu;
                        cuEntry.Comentarios = new List<Comentario>();
                        dictionaryCurso.Add(cuEntry.Id, cuEntry);
                    }
                    if (fa != null)
                    {
                        cuEntry.Faculdade = fa;
                    }
                    if(ti!=null)
                    {
                        cuEntry.TipoCurso = ti;
                    }
                    if(co != null)
                    {
                        if(!cuEntry.Comentarios.Any(x => x.ComentarioId == co.ComentarioId))
                            cuEntry.Comentarios.Add(co);
                    }
                    if(avu != null)
                    {
                        cuEntry.AvaliacaoUsuarios = avu;
                    }
                    return cuEntry;
                }, null, splitOn: "FaculId,ComentarioId,AvaliacaoUsuarioId,IdTipo")
                .Distinct()
                .ToList();
                return result;
            }
        }
        public Curso GetCursoById(int id)
        {
            using (conn)
            {
                var dictionaryCurso = new Dictionary<int, Curso>();
                var result = conn.Query<Curso, Faculdade, Comentario, AvaliacaoUsuario,TipoCurso, Curso>(String.Format(CursoQueries.GET_ALL_CURSOS_BY_ID,id), (cu, fa, co, avu,ti) =>
                {
                    if (!dictionaryCurso.TryGetValue(cu.Id, out Curso cuEntry))
                    {
                        cuEntry = cu;
                        cuEntry.Comentarios = new List<Comentario>();
                        dictionaryCurso.Add(cuEntry.Id, cuEntry);
                    }
                    if (fa != null)
                    {
                        cuEntry.Faculdade = fa;
                    }
                    if(ti!=null)
                    {
                        cuEntry.TipoCurso = ti;
                    }
                    if (co != null)
                    {
                        if (!cuEntry.Comentarios.Any(x => x.ComentarioId == co.ComentarioId))
                            cuEntry.Comentarios.Add(co);
                    }
                    if (avu != null)
                    {
                        cuEntry.AvaliacaoUsuarios = avu;
                    }
                    return cuEntry;
                }, null, splitOn: "FaculId,ComentarioId,AvaliacaoUsuarioId,IdTipo")
                .Distinct()
                .FirstOrDefault();
                return result;
            }
        }
    }
}
