using System;
using System.Collections.Generic;
using Dto;
using Entity;
namespace Business.Mappers
{
    public class FotoMapper
    {
        public FotoDto EntityToDto(Foto foto)
        {
            if (foto != null)
            {
                return new FotoDto()
                {
                    Id = foto.Id,
                    Imagem = foto.Imagem
                };
            }return null;
        }
        public List<FotoDto> ListEntityToListDto(IEnumerable<Foto> fotos)
        {
            List<FotoDto> dtos = new List<FotoDto>();
            if (fotos != null)
            {
                foreach (var foto in fotos)
                {
                    dtos.Add(EntityToDto(foto));

                }
            }
            return dtos;
        }

        public Foto DtoToEntity(FotoDto foto)
    {
        if (foto != null)
        {
            return new Foto()
            {
                Id = foto.Id,
                Imagem = foto.Imagem
            };
        }return null;
        }

        public List<Foto> ListDtoToListEntity(IEnumerable<FotoDto> fotos)
        {
            List<Foto> dtos = new List<Foto>(); 
            if (fotos != null)
            {
                foreach (var Foto in fotos)
                {
                    dtos.Add(DtoToEntity(Foto));

                }
            }
            return dtos;
        }

    }
}
