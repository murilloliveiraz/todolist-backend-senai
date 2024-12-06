using todolist_backend_senai.Domain;

namespace todolist_backend_senai.DTOs.TaskDTO
{
    public class CreateTaskRequest
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Priority { get; set; }
    }
}
