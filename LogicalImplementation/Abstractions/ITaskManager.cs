using DatabaseImplementation.Enums;
using DatabaseImplementation.Models;

namespace LogicalImplementation.Abstractions
{
    public interface ITaskManager
    {
        Task<IEnumerable<TaskData>> GetAllTasks(int pageNo, int pageSize, string sortBy, SortOrder sortOrder);
        Task<TaskData> GetIndividualTask(int id);
        Task AddTask(TaskData task);
        Task DeleteTask(int id);
        Task UpdateTask(TaskData task);
        Task UpdateTaskState(int id,TaskStates state);
        Task ToggleTaskFavorite(int id, bool isFavorite);


    }
}
