using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Entity;
using IRepository;
using Npgsql;
using Utils.Enums;
using Utils.Queries;

namespace Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IDbConnection conn;
        public string connectionString;
        public AnimalRepository(string connection, char parameterIdentified = '@')
        {

            conn = new NpgsqlConnection(connection);
            connectionString = connection;
        }

        public Animal GetAnimalById(int id)
        {
            using (conn)
            {
                var dictionaryAnimal = new Dictionary<int, Animal>();
                var teste = string.Format(AnimalQueries.GET_ANIMAL_BY_ID, id);
                var result = conn.Query<Animal, Foto, Raca, Animal>(String.Format(AnimalQueries.GET_ANIMAL_BY_ID, id), (a, f, r) =>
                {
                    if (!dictionaryAnimal.TryGetValue(a.Id, out Animal aEntry))
                    {
                        aEntry = a;
                        aEntry.Foto = new List<Foto>();
                        dictionaryAnimal.Add(aEntry.Id, aEntry);
                    }
                    if (f != null)
                    {
                        if (aEntry.Foto.Find(x => x.Id == f.Id) == null)
                            aEntry.Foto.Add(f);
                    }
                    if (r != null)
                    {
                            aEntry.Raca = r;
                    }
                    return aEntry;
                }, null, splitOn: "id,id,id").AsList()[0];
                return result;
            }
        }
        public List<Animal> GetAnimal(string nome,StatusEnum? status, double? peso,int? idade,SexoEnum? sexo, PorteEnum? porte, AnimalEnum? tipoAnimal)
        {
            using (conn)
            {
                string query = AnimalQueries.GET_ANIMAL;
                if (nome != null && nome.Length > 0)
                {
                    query += " AND a.nome = '" + nome +"'";
                }
                if (status.HasValue)
                {
                    query += " AND a.status = '" + (int)status.Value + "'";
                }
                if (peso.HasValue)
                {
                    query += " AND a.peso = '" + peso.Value + "'";
                }
                if (idade.HasValue)
                {
                    query += " AND a.idade = '" + idade.Value + "'";
                }
                if (sexo.HasValue)
                {
                    query += " AND a.sexo = '" + (int)sexo.Value + "'";
                }
                if (porte.HasValue)
                {
                    query += " AND a.porte = '" + (int)porte.Value + "'";
                }
                if (tipoAnimal.HasValue)
                {
                    query += " AND tipoanimal = '" + (int)tipoAnimal.Value;
                }
                var dictionaryAnimal = new Dictionary<int, Animal>();
                var result = conn.Query<Animal, Foto, Raca, Animal>(query, (a, f, r) =>
                {
                    if (!dictionaryAnimal.TryGetValue(a.Id, out Animal aEntry))
                    {
                        aEntry = a;
                        aEntry.Foto = new List<Foto>();
                        dictionaryAnimal.Add(aEntry.Id, aEntry);
                    }
                    if (f != null)
                    {
                        if (aEntry.Foto.Find(x => x.Id == f.Id) != null)
                            aEntry.Foto.Add(f);
                    }
                    if (r != null)
                    {
                            aEntry.Raca = r;
                    }
                    return aEntry;
                }, null, splitOn: "id,id,id").AsList();
                return result;
            }
        }
    }
}
