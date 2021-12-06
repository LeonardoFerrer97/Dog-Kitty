using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Query;
using IRepository;
using Utils.Enums;

namespace Business
{
    public class DoacaoBusiness
    {
        private readonly DoacaoMappers mapper = new DoacaoMappers();
        private readonly IRepository<Doacao> doacaoRepository;
        private readonly IRepository<Animal> animalCustomRepository;
        private readonly AnimalMapper animalMapper = new AnimalMapper();
        private readonly FotoMapper fotoMapper = new FotoMapper();
        private readonly IRepository<Foto> fotoRepository;
        private readonly IDoacaoRepository doacaoRepositoryCustom;
        private readonly IAnimalRepository animalRepository;

        public DoacaoBusiness(string connection, IRepository<Doacao> _doacaoRepository, IRepository<Animal> _animalCustomRepository, IRepository<Foto> _fotoRepository, IDoacaoRepository _doacaoRepositoryCustom, IAnimalRepository _animalRepository)
        {
            if (_doacaoRepository != null)
            {
                doacaoRepository = _doacaoRepository;
                animalCustomRepository = _animalCustomRepository;
                fotoRepository = _fotoRepository;
                doacaoRepositoryCustom = _doacaoRepositoryCustom;
                animalRepository = _animalRepository;
            }
            else
            {
                doacaoRepository = new Repository<Doacao>(connection);
                fotoRepository = new Repository<Foto>(connection);
                animalCustomRepository = new Repository<Animal>(connection);
                doacaoRepositoryCustom = new DoacaoRepository(connection);
                animalRepository = new AnimalRepository(connection);
            }
        }


        public List<DoacaoDto> GetAllDoacaos(StatusEnum status, string localizacao, int? raca, PorteEnum? porte, SexoEnum? sexo, AnimalEnum? animal, int? usuarioId)
        {
            IEnumerable<Doacao> doacaos = doacaoRepositoryCustom.GetDoacao(status, localizacao,raca,porte,sexo,animal,usuarioId);

            List<DoacaoDto> doacaoRetorno = mapper.ListEntityToListDto(doacaos);
            return doacaoRetorno;
        }

        public int UpdateDoacao(DoacaoDto Doacao)
        {
            if (Doacao == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            animalCustomRepository.InstertOrUpdate(animalMapper.DtoToEntity(Doacao.Animal), new { id= Doacao.Animal.Id});
            return doacaoRepository.InstertOrUpdate(mapper.DtoToEntity(Doacao), new { id = Doacao.Id });
        }


        public void DeleteDoacaoById(DoacaoDto doacao)
        {
            if (doacao == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            if (doacao.Animal.Foto != null)
            {
                foreach (var foto in doacao.Animal.Foto)
                {
                    fotoRepository.Remove(new { foto.Id });
                }
            }
            animalCustomRepository.Remove(new { doacao.Animal.Id});
            doacaoRepository.Remove(new { doacao.Id });
        }


        public int InsertDoacao(DoacaoDto Doacao)
        {
            if (Doacao == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
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
