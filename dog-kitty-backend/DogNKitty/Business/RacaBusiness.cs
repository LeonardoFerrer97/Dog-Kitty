using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Queries;
namespace Business
{
    public class RacaBusiness
    {
        private readonly RacaMapper mapper = new RacaMapper();
        private readonly Repository<Raca> racaRepository;

        public RacaBusiness(string connection)
        {
            racaRepository = new Repository<Raca>(connection);
        }


        public List<RacaDto> GetAllRaca()
        {
            IEnumerable<Raca> doacaos = racaRepository.All();

            List<RacaDto> avaliacoesRaca = mapper.ListEntityToListDto(doacaos);
            return avaliacoesRaca;
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
