namespace todolist_backend_senai.Domain
{
    public class User
    {
        public int Id{ get; set; }
        public string Nome{ get; set; }
        public string Email{ get; set; }
        public ICollection<TodoTask> Tasks{ get; set; }
    }
}
