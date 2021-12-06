using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Queries;
using IRepository;

namespace Business
{
    public class RacaBusiness
    {
        public readonly RacaMapper mapper = new RacaMapper();
        private readonly IRepository<Raca> racaRepository;

        public RacaBusiness(string connection,IRepository<Raca> repository)
        {
            if(repository == null)
            {
                racaRepository = new Repository<Raca>(connection);
            }
            else
            {

                racaRepository = repository;
            }
        }

        public List<RacaDto> GetAllRaca()
        {
            IEnumerable<Raca> racaEntity = racaRepository.All();

            List<RacaDto> racas = mapper.ListEntityToListDto(racaEntity);
            return racas;
        }

        public int InsertRaca(RacaDto Raca)
        {

            if (Raca == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return racaRepository.Add(mapper.DtoToEntity(Raca));
        }


    }
}
