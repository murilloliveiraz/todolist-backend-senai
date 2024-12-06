using todolist_backend_senai.Domain;

namespace todolist_backend_senai.DTOs.TaskDTO
{
    public class CreateTaskResponse : CreateTaskRequest
    {
        public int Id { get; set; }
        public DateTime Registrationdate { get; set; }
        public string Status { get; set; }
    }
}
