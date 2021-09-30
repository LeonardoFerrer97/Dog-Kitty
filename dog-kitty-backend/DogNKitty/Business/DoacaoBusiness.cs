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
        private readonly Repository<Doacao> doacaoRepository;
        private readonly AnimalMapper animalMapper = new AnimalMapper();
        private readonly FotoMapper fotoMapper = new FotoMapper();
        private readonly Repository<Foto> fotoRepository;
        private readonly IDoacaoRepository doacaoRepositoryCustom;
        private readonly IAnimalRepository animalRepository;

        public DoacaoBusiness(string connection)
        {
            doacaoRepository = new Repository<Doacao>(connection);
            fotoRepository = new Repository<Foto>(connection);
            doacaoRepositoryCustom = new DoacaoRepository(connection);
            animalRepository = new AnimalRepository(connection); 
        }


        public List<DoacaoDto> GetAllDoacaos(StatusEnum status, string localizacao, string raca, PorteEnum? porte, SexoEnum? sexo, AnimalEnum? animal, int? usuarioId)
        {
            IEnumerable<Doacao> doacaos = doacaoRepositoryCustom.GetDoacao(status, localizacao,raca,porte,sexo,animal,usuarioId);

            List<DoacaoDto> avaliacoesUsuario = mapper.ListEntityToListDto(doacaos);
            return avaliacoesUsuario;
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
