using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    class TaskData : ITaskData
    {
        private IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TaskData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<TaskModel>> GetProjectTasks(int clientID)
        {
            return _dataAccess.LoadData<TaskModel, dynamic>("dbo.All",
                                                              new { Id = clientID },
                                                              _connectionString.SqlConnectionName);
        }

        public Task<List<TaskModel>> GetProjectUnfishedTasks(int clientID)
        {
            return _dataAccess.LoadData<TaskModel, dynamic>("dbo.GetUnfished",
                                                              new { Id = clientID },
                                                              _connectionString.SqlConnectionName);
        }

        public async Task<int> NewTask(TaskModel t)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id", DbType.Int32, direction: System.Data.ParameterDirection.Output);
            p.Add("@ClientID", t.ClientID);
            p.Add("@Task", t.Task);
            p.Add("@Description", t.Description);
            p.Add("@Complete", t.Complete);
            p.Add("@ETA", t.ETA);

            await _dataAccess.SaveData("dbo.spTask_AddTask", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public async Task<int> DeleteTask(int id)
        {
            return await _dataAccess.SaveData("spTask_Delete",
                                               new { Id = id },
                                               _connectionString.SqlConnectionName);
        }

        public Task<int> UpdateTask(int id, bool isComplete)
        {
            return _dataAccess.SaveData("spTask_UpdateTaskStatus",
                                        new { Id = id, Complete = isComplete },
                                        _connectionString.SqlConnectionName);
        }

        public async Task<int> EditTask(int id, string task, string description)
        {
            return await _dataAccess.SaveData("spTask_EditTask",
                                              new { Id = id, Task = task, Description = description },
                                              _connectionString.SqlConnectionName);
        }
    }
}
