using AutoMapper;
using todolist_backend_senai.Domain;
using todolist_backend_senai.DTOs.TaskDTO;

namespace todolist_backend_senai.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TodoTask, CreateTaskRequest>().ReverseMap();
            CreateMap<TodoTask, CreateTaskResponse>().ReverseMap();
        }
    }
}
