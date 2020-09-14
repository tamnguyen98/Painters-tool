using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class ClientData : IClientData
    {
        private IDataAccess _dataAccess;
        private ConnectionStringData _connectionString;

        public ClientData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }


        // Query all the clients using the storeprocedure
        public Task<List<ClientModel>> GetClients()
        {
            return _dataAccess.LoadData<ClientModel, dynamic>("dbo.spClient_All",
                                                       new { },
                                                       _connectionString.SqlConnectionName);
        }

        private ClientModel TrimStringValues(ClientModel c)
        {
            // Remove trailing (and leading) spaces from the element
            c.FirstName = c.FirstName.Trim();
            c.LastName = c.LastName.Trim();
            c.PhoneNumber = c.PhoneNumber.Trim();
            c.HouseNum = c.HouseNum.Trim();
            c.Street = c.Street.Trim();
            c.Status = c.Status.Trim();

            // Nullable string values
            if (c.Email != null)
                c.Email = c.Email.Trim();
            if (c.State != null)
                c.State = c.State.Trim();
            if (c.City != null)
                c.City = c.City.Trim();
            return c;
        }

        private string TrimStringValue(string s)
        {
            if (s == null)
                return s;
            return s.Trim();
        }

        public async Task<int> NewClient(ClientModel client)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("@Id", DbType.Int32, direction: System.Data.ParameterDirection.Output);
            p.Add("@FirstName", client.FirstName);
            p.Add("@LastName", client.LastName);
            p.Add("@Email", client.Email);
            p.Add("@PhoneNumber", client.PhoneNumber);
            p.Add("@HouseNum", client.HouseNum);
            p.Add("@Street", client.Street);
            p.Add("@State", client.State);
            p.Add("@City", client.City);
            p.Add("@Cost", client.Cost);
            p.Add("@Status", client.Status);
            p.Add("@ETA", client.ETA);
            p.Add("@StartDate", client.StartDate);
            p.Add("@CompleteDate", client.CompleteDate);
            p.Add("@ContractorID", client.ContractorID);

            await _dataAccess.SaveData("dbo.spClient_New", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateProjectStatus(ProjectStatusModel data)
        {
            // Only Status and ID can not be null
            return _dataAccess.SaveData("dbo.spClient_UpdateStatus", data, _connectionString.SqlConnectionName);
        }

        public Task<int> UpdateProject(ClientModel c)
        {
            return _dataAccess.SaveData("spClient_UpdateProject",
                                        c,
                                        _connectionString.SqlConnectionName);
        }

        public async Task<ClientModel> GetProjectById(int id)
        {
            var p = new { Id = id };
            var records = await _dataAccess.LoadData<ClientModel, dynamic>("dbo.spClient_GetById",
                                                                            p,
                                                                            _connectionString.SqlConnectionName);
            return TrimStringValues(records.FirstOrDefault());
        }

        public async Task<ClientModel> GetProjectByHouse(string house, string street)
        {
            var p = new { HouseNum = house, Street = street };
            var records = await _dataAccess.LoadData<ClientModel, dynamic>("dbo.spClient_GetByHouse",
                                                                            p,
                                                                            _connectionString.SqlConnectionName);
            return TrimStringValues(records.FirstOrDefault());
            //return records.FirstOrDefault();
        }

        public async Task<ProjectStatusModel> GetProjectStatus(int id)
        {
            var records = await _dataAccess.LoadData<ProjectStatusModel, dynamic>("dbo.spClient_GetProjectStatus",
                                                                                  new { Id = id },
                                                                                  _connectionString.SqlConnectionName);
            var hit = records.FirstOrDefault();
            hit.Status = TrimStringValue(hit.Status);
            return hit;
        }

        public async Task<List<ClientModel>> GetContractorProjects(int contractorID)
        {
            return await _dataAccess.LoadData<ClientModel, dynamic>("dbo.spClient_ClientByContractor",
                                                       new { ContractorID = contractorID },
                                                       _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteProjectRecord(int clientId)
        {
            return _dataAccess.SaveData("dbo.spClient_Delete",
                                        new { Id = clientId },
                                        _connectionString.SqlConnectionName);
        }
    }
}
