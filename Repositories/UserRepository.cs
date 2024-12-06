using AutoMapper;
using Microsoft.EntityFrameworkCore;
using todolist_backend_senai.Contexts;
using todolist_backend_senai.Domain;
using todolist_backend_senai.DTOs.UserDTOS;

namespace todolist_backend_senai.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserResponse> Create(UserRequest model)
        {
            var user = _mapper.Map<User>(model);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserResponse>(user);
        }
    }
}
