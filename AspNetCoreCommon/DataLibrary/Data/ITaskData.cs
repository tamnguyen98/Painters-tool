using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    interface ITaskData
    {
        Task<int> DeleteTask(int id);
        Task<int> EditTask(int id, string task, string description);
        Task<List<TaskModel>> GetProjectTasks(int clientID);
        Task<List<TaskModel>> GetProjectUnfishedTasks(int clientID);
        Task<int> NewTask(TaskModel t);
        Task<int> UpdateTask(int id, bool isComplete);
    }
}