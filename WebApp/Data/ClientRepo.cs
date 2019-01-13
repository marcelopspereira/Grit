using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ClientRepo : IClientRepo
    {
        private TriumphDbContext _context = new TriumphDbContext();
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void CreateClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: (DR34). " + ex.Message);
                throw;
            }
        }

        public void UpdateClient(Client client)
        {
            try
            {
                _context.Clients.Attach(client);
                var entry = _context.Entry(client);
                entry.Property(e => e.FirstName).IsModified = true;
                entry.Property(e => e.LastName).IsModified = true;
                entry.Property(e => e.Email).IsModified = true;
                entry.Property(e => e.Phone).IsModified = true;
                entry.Property(e => e.BusinessName).IsModified = true;
                entry.Property(e => e.DisplayName).IsModified = true;
                entry.Property(e => e.EmpFullName).IsModified = true;
                entry.Property(e => e.Notes).IsModified = true;
                entry.Property(e => e.FullName).IsModified = true;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: (DR96). " + ex.Message);
                throw;
            }
        }

        public void DeleteClient(Client client)
        {
            try
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: (DR34). " + ex.Message);
                throw;
            }
        }

        public List<Client> GetClientById(int ClientID)
        {
            return _context.Clients.Include("ClientID").ToList();
        }

        public IEnumerable<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public void ValidateCli(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
