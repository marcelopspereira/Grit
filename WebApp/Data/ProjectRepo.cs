using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApp.Models;

namespace WebApp.Data
{
    public class ProjectRepo : IProjectRepo
    {
        private TriumphDbContext _context = new TriumphDbContext();
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void CreateProject(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: (DR34). " + ex.Message);
                throw;
            }
        }

        public void DeleteProject(Project project)
        {
            try
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public void UpdateProject(Project project)
        {
            try
            {
                _context.Projects.Attach(project);
                var entry = _context.Entry(project);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.DueDate).IsModified = true;
                entry.Property(e => e.Attributes).IsModified = true;
                entry.Property(e => e.Priority).IsModified = true;
                entry.Property(e => e.AssignedClientID).IsModified = true;
                entry.Property(e => e.Client).IsModified = true;
                entry.Property(e => e.EmployeeID).IsModified = true;
                entry.Property(e => e.FullName).IsModified = true;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: (DR96). " + ex.Message);
                throw;
            }
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }
    }
}
