using System;
using System.Collections.Generic;
using Entity;
using Utils.Enums;

namespace IRepository
{
    public interface IDoacaoRepository
    {
        List<Doacao> GetDoacao(string localizacao, int? usuarioId);
        Doacao GetDoacaoById(int id);
        int InsertDoacao(Doacao doacao);
    }
}
