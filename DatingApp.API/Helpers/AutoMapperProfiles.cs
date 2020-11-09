using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(destinationMember => destinationMember.PhotoUrl, opt => 
              opt.MapFrom(sourceMember => sourceMember.Photos.FirstOrDefault(p => p.IsMain).Url))
              .ForMember(destinationMember => destinationMember.Age, opt => 
              opt.MapFrom(sourceMember => sourceMember.DateOfbirth.CalculateAge()));
            CreateMap<User, UserForDetailedDto>()
            .ForMember(destinationMember => destinationMember.PhotoUrl, opt => 
              opt.MapFrom(sourceMember => sourceMember.Photos.FirstOrDefault(p => p.IsMain).Url))
              .ForMember(destinationMember => destinationMember.Age, opt => 
              opt.MapFrom(sourceMember => sourceMember.DateOfbirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailedDto>();
             CreateMap<UserForUpdateDto, User>();
        }
    }
}