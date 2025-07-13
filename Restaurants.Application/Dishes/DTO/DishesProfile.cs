using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.DTO;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>();
    }
}
