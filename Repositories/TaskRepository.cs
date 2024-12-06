using AutoMapper;
using Microsoft.EntityFrameworkCore;
using todolist_backend_senai.Contexts;
using todolist_backend_senai.Domain;
using todolist_backend_senai.DTOs.TaskDTO;

namespace todolist_backend_senai.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public TaskRepository(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreateTaskResponse> Create(CreateTaskRequest model)
        {
            var task = _mapper.Map<TodoTask>(model);
            task.Status = "A fazer";
            task.Registrationdate = DateTime.Now;
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<CreateTaskResponse>(task);
        }

        public async Task Delete(CreateTaskRequest model)
        {
            var task = _mapper.Map<TodoTask>(model);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CreateTaskResponse?>> Get()
        {
            var tasks = await _context.Tasks.AsNoTracking().OrderBy(a => a.Id)
          .ToListAsync();
            return tasks.Select(ad => _mapper.Map<CreateTaskResponse>(ad));
        }

        public async Task<CreateTaskResponse?> GetById(int id)
        {
            var task = await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<CreateTaskResponse>(task);

        }

        public async Task<CreateTaskResponse> Update(CreateTaskResponse model)
        {
            TodoTask task = await _context.Tasks.FirstOrDefaultAsync(p => p.Id == model.Id);

            _context.Entry(task).CurrentValues.SetValues(model);

            await _context.SaveChangesAsync();
            return _mapper.Map<CreateTaskResponse>(task);
        }
    }
}
