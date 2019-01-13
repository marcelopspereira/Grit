using System;
using System.Collections.Generic;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.BusinessLogic
{
    public class ClientService : IClientService
    {
        private IClientRepo _cliRepo;
        private IValidationDictionary _validation;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ClientService(IClientRepo cliRepo, IValidationDictionary validation)
        {
            _cliRepo = cliRepo;
            _validation = validation;
        }

        public bool CreateClient(Client client)
        {
            if (!ValidateCli(client))
                return false;

            try
            {
                _cliRepo.CreateClient(client);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Service Error:  (DS48). " + ex.Message);
                throw;
            }
        }

        public bool UpdateClient(Client client)
        {
            if (!ValidateCli(client))
                return false;

            try
            {
                _cliRepo.UpdateClient(client);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Service Error:  (DS48). " + ex.Message);
                throw;
            }
        }

        public bool DeleteClient(Client client)
        {
            try
            {
                _cliRepo.DeleteClient(client);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Service Error:  (DS139). " + ex.Message);
                throw;
            }
        }

        public List<Client> GetClientById(int ClientID)
        {
            return _cliRepo.GetClientById(ClientID);
        }

        public IEnumerable<Client> GetClients()
        {
            return _cliRepo.GetClients();
        }

        public bool ValidateCli(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
