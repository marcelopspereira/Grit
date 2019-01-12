using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebApp.Models;

namespace WebApp.Data
{
    public class ProjectRepo : IProjectRepo
    {
        private TriumphDbContext _context = new TriumphDbContext();
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void CreateProject(Project project)
        {
            return _context.Projects.Include("ProjectID").Include("Project").Include("DocumentStatus").ToList();
        }

        public void DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(int projectID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjects()
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
