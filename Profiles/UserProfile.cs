using AutoMapper;
using todolist_backend_senai.Domain;
using todolist_backend_senai.DTOs.UserDTOS;

namespace todolist_backend_senai.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
        }
    }
}
