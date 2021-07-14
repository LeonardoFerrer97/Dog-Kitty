using System;
using System.Collections.Generic;
using Dto;
using Entity;
namespace Utils.Mappers
{
    public class FotoMapper
    {
        public FotoDto EntityToDto(Foto foto)
        {
            return new FotoDto()
            {
                Id = foto.Id,
                Imagem = foto.Imagem
            };
        }
        public List<FotoDto> ListEntityToListDto(IEnumerable<Foto> fotos)
        {
            List<FotoDto> dtos = new List<FotoDto>();
            foreach (var foto in fotos)
            {
                dtos.Add(EntityToDto(foto));

            }
            return dtos;
        }

        public Foto DtoToEntity(FotoDto foto)
        {
            return new Foto()
            {
                Id = foto.Id,
                Imagem = foto.Imagem
            };
        }

        public List<Foto> ListDtoToListEntity(IEnumerable<FotoDto> fotos)
        {
            List<Foto> dtos = new List<Foto>();
            foreach (var Foto in fotos)
            {
                dtos.Add(DtoToEntity(Foto));

            }
            return dtos;
        }

    }
}
