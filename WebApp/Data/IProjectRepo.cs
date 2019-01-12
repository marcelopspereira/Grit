using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Data
{
    public interface IProjectRepo
    {
        Project GetProjectById(int projectID);
        IEnumerable<Project> GetProjects();
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
    }
}
