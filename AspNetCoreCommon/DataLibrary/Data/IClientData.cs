using DataLibrary.Models;
using System;
using System.Collections.Generic;
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
        Task<int> UpdateProject(int clientId, decimal cost, string fName, string lName, string email, string phone, string houseNum, string street, string city, string state);
        Task<int> UpdateProjectStatus(int clientId, string status, int eta, DateTime startTime, DateTime completeTime);
    }
}