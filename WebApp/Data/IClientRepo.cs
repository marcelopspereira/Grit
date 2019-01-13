using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Data
{
    public interface IClientRepo
    {
        IEnumerable<Client> GetClients();
        List<Client> GetClientById(int ClientID);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        void ValidateCli(Client client);
    }
}
