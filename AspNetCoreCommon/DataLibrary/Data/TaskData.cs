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
    public class TaskData : ITaskData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TaskData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<TaskModel>> GetEveryTask()
        {
            return _dataAccess.LoadData<TaskModel, dynamic>("dbo.spTask_EveryTask",
                                                              null,
                                                              _connectionString.SqlConnectionName);
        }

        public Task<List<TaskModel>> GetProjectTasks(int clientID)
        {
            return _dataAccess.LoadData<TaskModel, dynamic>("dbo.spTask_All",
                                                              new { ProjectID = clientID },
                                                              _connectionString.SqlConnectionName);
        }

        public Task<List<TaskModel>> GetProjectUnfishedTasks(int clientID)
        {
            return _dataAccess.LoadData<TaskModel, dynamic>("dbo.spTask_GetUnfinished",
                                                              new { ProjectID = clientID },
                                                              _connectionString.SqlConnectionName);
        }

        public async Task<int> NewTask(TaskModel t)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id", DbType.Int32, direction: System.Data.ParameterDirection.Output);
            p.Add("@ClientID", t.ClientID);
            p.Add("@Task", t.Task);
            //if (t.Description != null)
                p.Add("@Description", t.Description);
            //if (t.Complete != null)
                p.Add("@Complete", t.Complete);
            //if (t.ETA != null)
                p.Add("@ETA", t.ETA);

            await _dataAccess.SaveData("dbo.spTask_AddTask", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public async Task<int> DeleteTask(int id)
        {
            return await _dataAccess.SaveData("dbo.spTask_Delete",
                                               new { Id = id },
                                               _connectionString.SqlConnectionName);
        }

        public Task<int> UpdateTask(int id, bool isComplete)
        {
            return _dataAccess.SaveData("dbo.spTask_UpdateTaskStatus",
                                        new { Id = id, Complete = Convert.ToInt16(isComplete) },
                                        _connectionString.SqlConnectionName);
        }

        public async Task<int> EditTask(int id, string task, string description)
        {
            return await _dataAccess.SaveData("dbo.spTask_EditTask",
                                              new { Id = id, Task = task, Description = description },
                                              _connectionString.SqlConnectionName);
        }
    }
}
