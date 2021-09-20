using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Query;
using IRepository;

namespace Business
{
    public class DoacaoBusiness
    {
        private readonly DoacaoMappers mapper = new DoacaoMappers();
        private readonly Repository<Doacao> doacaoRepository;
        private readonly AnimalMapper animalMapper = new AnimalMapper();
        private readonly FotoMapper fotoMapper = new FotoMapper();
        private readonly Repository<Foto> fotoRepository;
        private readonly Repository<Raca> racaRepository;
        private readonly IDoacaoRepository doacaoRepositoryCustom;
        private readonly IAnimalRepository animalRepository;

        public DoacaoBusiness(string connection)
        {
            doacaoRepository = new Repository<Doacao>(connection);
            fotoRepository = new Repository<Foto>(connection);
            racaRepository = new Repository<Raca>(connection);
            doacaoRepositoryCustom = new DoacaoRepository(connection);
            animalRepository = new AnimalRepository(connection); 
        }


        public List<DoacaoDto> GetAllDoacaos()
        {
            IEnumerable<Doacao> doacaos = doacaoRepository.All();

            List<DoacaoDto> avaliacoesUsuario = mapper.ListEntityToListDto(doacaos);
            return avaliacoesUsuario;
        }

        public List<DoacaoDto> GetAllDoacoesByUsuarioId(int id)
        {
            object parameters = new { id };
            IEnumerable<Doacao> doacoes = doacaoRepository.GetData(DoacaoQueries.GET_DOACAO_BY_USUARIO_ID, parameters);
            return mapper.ListEntityToListDto(doacoes.ToList());
        }

        public DoacaoDto GetDoacaoById(int Id)
        {
            object parameters = new { Id };
            Doacao doacaos = doacaoRepository.GetData(DoacaoQueries.GET_DOACAO_BY_ID, parameters).FirstOrDefault();

            DoacaoDto doacao = mapper.EntityToDto(doacaos);
            return doacao;
        }

        public int UpdateDoacao(DoacaoDto Doacao)
        {
            return doacaoRepository.InstertOrUpdate(mapper.DtoToEntity(Doacao), new { DoacaoId = Doacao.Id });
        }


        public void DeleteDoacaoById(int Id)
        {
            doacaoRepository.Remove(new { Id });
        }


        public int InsertDoacao(DoacaoDto Doacao)
        {
            var doacaoId = doacaoRepositoryCustom.InsertDoacao(mapper.DtoToEntity(Doacao));
            var animalId = animalRepository.InsertAnimal(animalMapper.DtoToEntity(Doacao.Animal),doacaoId);
            List<Foto> fotos = fotoMapper.ListDtoToListEntity(Doacao.Animal.Foto);
            foreach(var foto in fotos)
            {
                foto.Animal_Id = animalId;
                fotoRepository.Add(foto);
            }
            return 0;
        }


    }
}
