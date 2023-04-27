using AutoMapper;
using DotNet001Shared.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace DotNet001API.Handlers
{

    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<DotNet001API.Models.Product, DotNet001Shared.Models.Product>()
                .ForMember(dest => dest.Id, dest => dest.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, dest => dest.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, dest => dest.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, dest => dest.MapFrom(src => src.Category))
                .ForMember(dest => dest.Price, dest => dest.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsDeleted, dest => dest.MapFrom(src => src.IsDeleted));


            CreateMap<DotNet001API.Models.Product, DotNet001Shared.Models.Product>()
                .ForMember(dest => dest.Id, dest => dest.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, dest => dest.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, dest => dest.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, dest => dest.MapFrom(src => src.Category))
                .ForMember(dest => dest.Price, dest => dest.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsDeleted, dest => dest.MapFrom(src => src.IsDeleted)).ReverseMap();

        }
    }
}
