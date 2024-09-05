using DatabaseImplementation.Abstraction;
using DatabaseImplementation.Enums;
using DatabaseImplementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplementation.Implemenmtation
{
    public class TaskRepository: ITaskRepository
    {
        //The DataBase query will go in this class but currently dealing with random data
        //so the values will be incorrect in some cases

        private static readonly string[] Summaries = new[]
        {
            "Task1", "Task2", "Task3", "Done Data", "Pending", "Ready", "There Yet", "To Be Reviewed", "There", "Pending Declaration......"
        };
        public TaskRepository() { }

        public async Task AddTask(TaskData task)
        {
            List<TaskData> tasks = new List<TaskData>();
            tasks.Add(task);
        }

        public async Task DeleteTask(int id)
        {
            List<TaskData> tasks = new List<TaskData>();
            tasks.Clear();
        }

        public async Task<IEnumerable<TaskData>> GetAllTasks(int pageNo, int pageSize, string sortBy, SortOrder sortOrder)
        {
            int start = ((pageNo-1)*pageSize)+1;
            int end = pageSize * pageNo;

            return Enumerable.Range(start, end).Select(index => new TaskData
            {
                TaskName = Summaries[Random.Shared.Next(Summaries.Length)],
                Id = index,
                TaskState = (TaskStates)Random.Shared.Next(0, 4),
                Deadline = DateTime.Now.AddDays(Random.Shared.Next(1, 90)),
                Description = Summaries[Random.Shared.Next(Summaries.Length)],
                IsFavorite = true,
            });
        }

        public async Task<TaskData> GetIndividualTask(int id)
        {
            TaskData task = new TaskData();
            task.Id = id;
            task.TaskName = Summaries[Random.Shared.Next(Summaries.Length)];
            task.TaskState = (TaskStates)Random.Shared.Next(0, 4);
            task.Description = Summaries[Random.Shared.Next(Summaries.Length)];
            task.Deadline = DateTime.Now.AddDays(Random.Shared.Next(1, 90));
            task.IsFavorite = true;
            return task;
               
        }

        public async Task ToggleTaskFavorite(int id, bool isFavorite)
        {
            TaskData task = new TaskData();
            task.IsFavorite =isFavorite;
        }

        public async Task UpdateTask(TaskData task)
        {
            TaskData updatedtask = new TaskData();
            updatedtask.Id = task.Id;
            updatedtask.TaskName = task.TaskName;
            updatedtask.TaskState = task.TaskState;
            updatedtask.Description = task.Description;
            updatedtask.Deadline = task.Deadline;
            updatedtask.IsFavorite = task.IsFavorite;
        }

        public async Task UpdateTaskState(int id, TaskStates state)
        {
            TaskData task = new TaskData();
            task.TaskState=state;
        }
    }
}
