using AutoMapper;
using ElectronicVinylCollection.Entities;
using ElectronicVinylCollection.Models;

namespace ElectronicVinylCollection
{
    public class VinylMappingProfile : Profile
    {
        public VinylMappingProfile() 
        {
            CreateMap<User, UserDto>();
                
            CreateMap<Media, MediaDto>();

            CreateMap<CreateUserDto, User>();
        }
    }
}
