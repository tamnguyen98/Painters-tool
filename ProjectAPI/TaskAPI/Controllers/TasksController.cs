using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Controllers;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommonCoreAPI.Controllers;
using CommonCoreAPI.Models;
using TaskAPI.Models;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskData _taskData;

        public TasksController(ITaskData taskData)
        {
            _taskData = taskData;
        }
        // For test, delete at final
        [HttpGet("every")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<TaskModel>> Get()
        {
            return await _taskData.GetEveryTask();
        }

        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<TaskModel>> Get(int project)
        {
            return await _taskData.GetProjectTasks(project);
        }

        [HttpPost("New")]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(TaskModel task)
        {
            int id = await _taskData.NewTask(task);
            return Ok(id);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int task)
        {
            await _taskData.DeleteTask(task);
            return Ok();
        }

        [HttpPut("Edit")]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit(TaskEditModel task)
        {
            int result = await _taskData.EditTask(task.ID, task.Task, task.Description);
            if (result < 0)
                return BadRequest(); // to test without
            return Ok();
        }

        [HttpGet("Todo")]
        public async Task<List<TaskModel>> TodoTasks(int projectId)
        {
            return await _taskData.GetProjectUnfishedTasks(projectId);
        }

        [HttpPatch("SetStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CompleteTask([FromBody] TaskStatusModel t)
        {
            int result = await _taskData.UpdateTask(t.id, t.isComplete);
            if (result < 0)
                return BadRequest(); // To Test without
            return Ok(1);
        }
    }
}
