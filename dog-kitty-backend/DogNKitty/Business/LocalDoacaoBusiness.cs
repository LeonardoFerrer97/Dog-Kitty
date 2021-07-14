
using System.Collections.Generic;
using System.Linq;
using Dto;
using Entity;
using Repository;
using Utils.Mappers;
using Utils.Queries;
using Utils.Query;
namespace Business
{
    public class LocalDoacaoBusiness
    {
        private readonly LocalAdocaoMappers mapper = new LocalAdocaoMappers();
        private readonly Repository<LocalAdocao> localAdocaoRepository;

        public LocalDoacaoBusiness(string connection)
        {
            localAdocaoRepository = new Repository<LocalAdocao>(connection);
        }


        public List<LocalAdocaoDto> GetAllLocalAdocao()
        {
            IEnumerable<LocalAdocao> doacaos = localAdocaoRepository.All();

            List<LocalAdocaoDto> avaliacoesUsuario = mapper.ListEntityToListDto(doacaos);
            return avaliacoesUsuario;
        }

        public LocalAdocaoDto GetLocalAdocaoByDoacaoId(int CursoIdAvaliacao)
        {
            object parameters = new { CursoIdAvaliacao };
            LocalAdocao localAdocaos = localAdocaoRepository.GetData(LocalAdocaoQueries.GET_LOCAL_DOACAO, parameters).FirstOrDefault();
            return mapper.EntityToDto(localAdocaos);
        }

        public LocalAdocaoDto GetLocalAdocaoById(int Id)
        {
            object parameters = new { Id };
            LocalAdocao localAdocao = localAdocaoRepository.GetData(LocalAdocaoQueries.GET_LOCAL_DOACAO_BY_ID, parameters).FirstOrDefault();

            return mapper.EntityToDto(localAdocao);
        }

        public int UpdateLocalAdocao(LocalAdocaoDto LocalAdocao)
        {
            return localAdocaoRepository.InstertOrUpdate(mapper.DtoToEntity(LocalAdocao), new { DoacaoId = LocalAdocao.Id });
        }

        public void DeleteDoacaoById(int DoacaoId)
        {
            localAdocaoRepository.Remove(new { DoacaoId });
        }


        public void DeleteLocalAdocaoById(int Id)
        {
            localAdocaoRepository.Remove(new { Id });
        }


        public int InsertLocalAdocao(List<LocalAdocaoDto> LocalAdocao)
        {
            return localAdocaoRepository.Add(mapper.ListDtoToListEntity(LocalAdocao));
        }


    }
}

