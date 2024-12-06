using Microsoft.AspNetCore.Mvc;
using todolist_backend_senai.DTOs.TaskDTO;
using todolist_backend_senai.Repositories;

namespace todolist_backend_senai.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskRequest model)
        {
            var task = await _taskRepository.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CreateTaskResponse model)
        {
            await _taskRepository.Delete(model);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _taskRepository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _taskRepository.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateTaskResponse model)
        {
            await _taskRepository.Update(model);
            return Ok();
        }
    }
}
