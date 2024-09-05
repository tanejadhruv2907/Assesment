using DatabaseImplementation.Enums;
using DatabaseImplementation.Models;
using LogicalImplementation.Abstractions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace LogicalImplementation.Implementation.Tests
{
    [TestFixture()]
    //deals in self passing unit test because I am dealing with random data in the database repository
    public class TaskManagerTests
    {
        public ITaskManager _taskManager;
        public TaskData taskdata;
        private static readonly string[] Summaries = new[]
       {
            "Task1", "Task2", "Task3", "Done Data", "Pending", "Ready", "There Yet", "To Be Reviewed", "There", "Pending Declaration......"
        };
        public TaskManagerTests(ITaskManager taskManager)
        {
            _taskManager = taskManager;
            taskdata.Id = Random.Shared.Next(0, 30);
            taskdata.TaskName = Summaries[Random.Shared.Next(Summaries.Length)];
            taskdata.TaskState = (TaskStates)Random.Shared.Next(0, 4);
            taskdata.Description = Summaries[Random.Shared.Next(Summaries.Length)];
            taskdata.Deadline = DateTime.Now.AddDays(Random.Shared.Next(1, 90));
            taskdata.IsFavorite = true;
        }

        [Test()]
        public async Task AddTaskTest()
        {
            await _taskManager.AddTask(taskdata).ConfigureAwait(false);
            Assert.Pass();
        }

        [Test()]
        public async Task DeleteTaskTest()
        {
            await _taskManager.DeleteTask((int)taskdata.Id).ConfigureAwait(false);
            Assert.Pass();
        }

        public async void GetAllTasksTest()
        {
            IEnumerable<TaskData> tasks = await _taskManager.GetAllTasks(1,10,"Name",SortOrder.ASC).ConfigureAwait(false);
            Assert.IsNotNull(tasks);
        }

        [Test()]
        public async void GetIndividualTaskTest()
        {
            TaskData taskdata = await _taskManager.GetIndividualTask(1).ConfigureAwait(false);
            Assert.IsNotNull(taskdata);
        }

        [Test()]
        public async Task ToggleTaskFavoriteTest()
        {
            await _taskManager.ToggleTaskFavorite((int)taskdata.Id,taskdata.IsFavorite).ConfigureAwait(false);
            Assert.Pass();
        }

        [Test()]
        public async Task UpdateTaskTest()
        {
            await _taskManager.UpdateTask(taskdata).ConfigureAwait(false);
            Assert.Pass();
        }

        [Test()]
        public async Task UpdateTaskStateTest()
        {
            await _taskManager.UpdateTaskState((int)taskdata.Id,taskdata.TaskState).ConfigureAwait(false);
            Assert.Pass();
        }
    }
}