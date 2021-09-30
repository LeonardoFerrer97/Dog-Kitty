using System;
using System.Collections.Generic;
using Entity;
using Utils.Enums;

namespace IRepository
{
    public interface IDoacaoRepository
    {
        List<Doacao> GetDoacao(StatusEnum status, string localizacao, int? raca, PorteEnum? porte, SexoEnum? sexo,AnimalEnum? animal, int? usuarioId);
        Doacao GetDoacaoById(int id);
        int InsertDoacao(Doacao doacao);
    }
}
