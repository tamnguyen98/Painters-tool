using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    class TaskData
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
    }
}
