using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IClientData
    {
        Task<int> DeleteProjectRecord(int clientId);
        Task<List<ClientModel>> GetClients();
        Task<List<ClientModel>> GetContractorProjects(int contractorID);
        Task<ClientModel> GetProjectByHouse(string house, string street);
        Task<ClientModel> GetProjectById(int id);
        Task<int> NewClient(ClientModel client);
        public Task<int> UpdateProject(ClientModel c);
        Task<int> UpdateProjectStatus(int clientId, string status, int eta, SqlDateTime startTime, SqlDateTime completeTime);
    }
}