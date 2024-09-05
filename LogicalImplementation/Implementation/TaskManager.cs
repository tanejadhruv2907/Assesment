using DatabaseImplementation.Abstraction;
using DatabaseImplementation.Enums;
using DatabaseImplementation.Models;
using LogicalImplementation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalImplementation.Implementation
{
    public class TaskManager :ITaskManager
    {
        public ITaskRepository _taskRepository;
        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task AddTask(TaskData task)
        {
            await _taskRepository.AddTask(task).ConfigureAwait(false);
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TaskData>> GetAllTasks(int pageNo, int pageSize, string sortBy, SortOrder sortOrder)
        {
           return await _taskRepository.GetAllTasks(pageNo,pageSize,sortBy,sortOrder).ConfigureAwait(false);
        }

        public async Task<TaskData> GetIndividualTask(int id)
        {
            return await _taskRepository.GetIndividualTask(id).ConfigureAwait(false);
        }

        public async Task ToggleTaskFavorite(int id, bool isFavorite)
        {
            TaskData data = await _taskRepository.GetIndividualTask(id).ConfigureAwait(false);

            if (data != null)
            {
                await _taskRepository.ToggleTaskFavorite(id, isFavorite).ConfigureAwait(false);
            }
            else
            {
                throw new InvalidOperationException("Invalid Id");
            }
        }

        public async Task UpdateTask(TaskData task)
        {
            if (task.Id != null)
            {
                TaskData data = await _taskRepository.GetIndividualTask((int)task.Id).ConfigureAwait(false);

                if (data != null)
                {
                    await _taskRepository.UpdateTask(task).ConfigureAwait(false);
                }
                else
                {
                    throw new InvalidOperationException("Invalid Id");
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid Id");
            }
        }

        public async Task UpdateTaskState(int id, TaskStates state)
        {

            TaskData data = await _taskRepository.GetIndividualTask(id).ConfigureAwait(false);

            if (data != null)
            {
                await _taskRepository.UpdateTaskState(id,state).ConfigureAwait(false);
            }
            else
            {
                throw new InvalidOperationException("Invalid Id");
            }
        }
    }
}
