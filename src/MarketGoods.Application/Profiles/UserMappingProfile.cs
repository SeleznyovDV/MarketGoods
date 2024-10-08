﻿namespace MarketGoods.Application.Profiles
{
    using AutoMapper;
    using MarketGoods.Application.Users.Commons;
    using MarketGoods.Domain.Users;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>()
                .ConstructUsing(x => new UserResponse(x.Id.Value, x.FirstName, x.LastName, x.PhoneNumber.Value, x.Email, x.Role.ToString()));
        }
    }
}
