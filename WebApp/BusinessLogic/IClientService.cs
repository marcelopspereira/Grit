using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.BusinessLogic
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        List<Client> GetClientById(int ClientID);
        bool CreateClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(Client client);
        bool ValidateCli(Client client);
    }
}
