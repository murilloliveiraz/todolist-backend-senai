using System.Threading.Tasks;
using todolist_backend_senai.DTOs.UserDTOS;

namespace todolist_backend_senai.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponse> Create(UserRequest model);
    }
}
