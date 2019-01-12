using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.BusinessLogic
{
    public interface IProjectService
    {
        IEnumerable<Project> Projects();
        IEnumerable<Project> GetProjects();
        Project GetProjectById(int ProjectID);
        bool CreateProject(Project project);
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);
        bool ValidateProj(Project project);
    }
}
