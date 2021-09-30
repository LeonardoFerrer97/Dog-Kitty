using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Entity;
using IRepository;
using Npgsql;
using Utils.Enums;
using Utils.Query;

namespace Repository
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly IDbConnection conn;
        public string connectionString;
        public DoacaoRepository(string connection, char parameterIdentified = '@')
        {

            conn = new NpgsqlConnection(connection);
            connectionString = connection;
        }

        public Doacao GetDoacaoById(int id)
        {
            using (conn)
            {
                var dictionaryDoacao = new Dictionary<int, Doacao>();
                var result = conn.Query<Doacao, Usuario, Doacao>(String.Format(DoacaoQueries.GET_DOACAO_BY_ID, id), (a, u) =>
                {
                    if (!dictionaryDoacao.TryGetValue(a.Id, out Doacao aEntry))
                    {
                        aEntry = a;
                        dictionaryDoacao.Add(aEntry.Id, aEntry);
                    }
                    if (u != null)
                    {
                        aEntry.Usuario = u;
                    }
                    return aEntry;
                }, null, splitOn: "id,id").AsList()[0];
                return result;
            }
        }
        public List<Doacao> GetDoacao(StatusEnum status, string localizacao, string raca, PorteEnum? porte, SexoEnum? sexo, AnimalEnum? animal, int? usuarioId)
        {
            using (conn)
            {
                string query = DoacaoQueries.GET_DOACAO;
                query += " AND a.status = '" + (int)status + "'";
                if (localizacao != null && localizacao.Length > 0)
                {
                    query += " AND d.localizacao = '" + localizacao + "'";
                }
                if (usuarioId.HasValue)
                {
                    query += " AND d.usuario_id = '" + (int)usuarioId.Value + "'";
                }
                if (porte.HasValue)
                {
                    query += " AND a.porte = '" + (int)porte.Value + "'";
                }
                if (sexo.HasValue)
                {
                    query += " AND a.sexo = '" + (int)sexo.Value + "'";
                }
                if (animal.HasValue)
                {
                    query += " AND a.tipoanimal = '" + (int)animal.Value + "'";
                }
                if (raca != null && raca.Length > 0)
                {
                    query += " AND r.nome = '" + raca + "'";
                }
                var dictionaryDoacao = new Dictionary<int, Doacao>();
                var result = conn.Query < Doacao, Usuario, Animal, Foto, Raca, Doacao>(query, (d, u,a,f,r) =>
                {
                    if (!dictionaryDoacao.TryGetValue(d.Id, out Doacao aEntry))
                    {
                        aEntry = d;
                        dictionaryDoacao.Add(aEntry.Id, aEntry);
                    }
                    if (u != null)
                    {
                        aEntry.Usuario = u;
                    }
                if (a != null)
                {
                        if (aEntry.Animal == null) {
                            aEntry.Animal = a;
                            aEntry.Animal.Foto = new List<Foto>();
                        }
                    }

                    if (r != null)
                    {
                        aEntry.Animal.Raca = r;

                    }
                    if (f != null)
                    {
                        aEntry.Animal.Foto.Add( f);

                    }
                    return aEntry;
                }, null, splitOn: "id,id,id,id,id").AsList();
                return result;
            }
        }
        public int InsertDoacao(Doacao doacao)
        {
            using (conn)
            {
                var result = conn.Query<int>(String.Format(DoacaoQueries.INSERT_DOACAO, "'" + doacao.Descricao+"'" , "'" + doacao.Localizacao+"'" , "'" + doacao.Usuario.Id+ "'" )).AsList()[0];
                return result;
            }
        }
    }
}

