namespace todolist_backend_senai.Domain
{
    public class TodoTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Priority { get; set; }
        public DateTime Registrationdate { get; set; }
        public string Status { get; set; }
    }
}
