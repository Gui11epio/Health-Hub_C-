using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Health_Hub.Application.DTOs.Request;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Domain.Entities;

namespace Health_Hub.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<Usuario, UsuarioResponse>();

            CreateMap<QuestionarioRequest, Questionario>()
                .ForMember(dest => dest.DataPreenchimento, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<Questionario, QuestionarioResponse>();



        }
    }
}
