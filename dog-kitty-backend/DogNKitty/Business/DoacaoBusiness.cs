using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Business.Mappers;
using Utils.Query;

namespace Business
{
    public class DoacaoBusiness
    {
        private readonly DoacaoMappers mapper = new DoacaoMappers();
        private readonly Repository<Doacao> doacaoRepository;

        public DoacaoBusiness(string connection)
        {
            doacaoRepository = new Repository<Doacao>(connection);
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

        public void DeleteDoacaoById(int DoacaoId)
        {
            doacaoRepository.Remove(new { DoacaoId });
        }


        public void DeleteDoacaoByUsuario(int Id)
        {
            doacaoRepository.Remove(new { Id });
        }


        public int InsertDoacao(List<DoacaoDto> Doacao)
        {
            return doacaoRepository.Add(mapper.ListDtoToListEntity(Doacao));
        }


    }
}
