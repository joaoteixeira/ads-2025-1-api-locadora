using ApiLocadora.Dtos;
using ApiLocadora.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiLocadora.DataContexts
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<FilmeDto, Filme>()
                .ForMember(
                dest => dest.AnoLancamento,
                opt => opt.MapFrom(src => new DateOnly(src.AnoLancamento.Year, src.AnoLancamento.Month, src.AnoLancamento.Day)));
        }
    }
}
