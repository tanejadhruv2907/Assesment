using DatabaseImplementation.Enums;
using DatabaseImplementation.Models;
using LogicalImplementation.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace RamsoftAssesment.Controllers
{
    [ApiController]
    [Route("task-management")]
    public class TaskManagementController : ControllerBase
    {
        private readonly ILogger<TaskManagementController> _logger;
        private ITaskManager _taskManager;

        public TaskManagementController(ILogger<TaskManagementController> logger,
            ITaskManager taskManager) {

            _logger = logger;
            _taskManager = taskManager;
        }
        [HttpGet]
        public async Task<IEnumerable<TaskData>> GetTasksData(int PageNo,int PageSize,string SortBy, SortOrder SortOrder)
        {
            return await _taskManager.GetAllTasks(PageNo,PageSize,SortBy,SortOrder).ConfigureAwait(false);
        }
        [HttpGet("get-individual-details")]
        public async Task<TaskData> GetIndividualTaskDetails(int Id)
        {
            return await _taskManager.GetIndividualTask(Id).ConfigureAwait(false);
        }
        [HttpPost]
        public async Task<bool> AddTaskDetails([FromBody] TaskData taskData)
        {
            try
            {
                await _taskManager.AddTask(taskData).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("TaskManagementController.AddTaskDetails Failed", ex);
                return false;
            }
        }
        [HttpPut]
        public async Task<bool> UpdateTaskDetails([FromBody] TaskData taskData) 
        {
            try
            {
                await _taskManager.UpdateTask(taskData).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("TaskManagementController.UpdateTaskDetails Failed", ex);
                return false;
            }
        }
        [HttpPatch("update-state")]
        public async Task<bool> UpdateTaskState(int Id, TaskStates State)
        {
            try
            {
                await _taskManager.UpdateTaskState(Id, State).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("TaskManagementController.UpdateTaskState Failed", ex);
                return false;
            }
        }
        [HttpPatch("toggle-favorite")]
        public async Task<bool> ToggleTaskFavorite(int Id, bool IsFavorite)
        {
            try
            {
                await _taskManager.ToggleTaskFavorite(Id, IsFavorite).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("TaskManagementController.UpdateTaskState Failed", ex);
                return false;
            }
        }
        [HttpDelete]
        public async Task<bool> DeleteTask(int Id)
        {
            try
            {
                await _taskManager.DeleteTask(Id).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("TaskManagementController.UpdateTaskState Failed", ex);
                return false;
            }
        }

    }
}
