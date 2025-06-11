using ApiLocadora.Dtos;
using ApiLocadora.Models;
using AutoMapper;

namespace ApiLocadora.DataContexts
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<FilmeDto, Filme>()
                .ForMember(
                dest => dest.AnoLancamento, 
                opt => opt.MapFrom(
                    src => new DateOnly(src.AnoLancamento.Year, src.AnoLancamento.Month, src.AnoLancamento.Day)
                    )
                );
        }
    }
}
