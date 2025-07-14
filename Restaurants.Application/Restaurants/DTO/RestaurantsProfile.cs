using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTO;

public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        CreateMap<CreateRestaurantDto, Restaurant>()
            .ForMember(d => d.Address, opt =>
                opt.MapFrom(src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }));

        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(r => r.City, opt => 
                opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(r => r.Street, opt => 
                opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(r => r.PostalCode, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(r => r.Dishes, opt => 
                opt.MapFrom(src => src.Dishes));
    }    
}
