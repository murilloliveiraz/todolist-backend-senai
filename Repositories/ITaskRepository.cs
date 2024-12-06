using System.Threading.Tasks;
using todolist_backend_senai.DTOs.TaskDTO;

namespace todolist_backend_senai.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<CreateTaskResponse?>> Get();
        Task<CreateTaskResponse?> GetById(int id);
        Task<CreateTaskResponse> Create(CreateTaskRequest model);
        Task<CreateTaskResponse> Update(CreateTaskResponse model);
        Task Delete(CreateTaskRequest model);
    }
}
