using System;
using System.Collections.Generic;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.BusinessLogic
{
    public class ProjectService : IProjectService
    {
        private IProjectRepo _projRepo;
        private IValidationDictionary _validation;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ProjectService(IProjectRepo projRepo, IValidationDictionary validation)
        {
            _projRepo = projRepo;
            _validation = validation;
        }

        public bool CreateProject(Project project)
        {
            if (!ValidateProj(project))
                return false;

            try
            {
                _projRepo.CreateProject(project);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Service Error:  (DS48). " + ex.Message);
                throw;
            }
        }

        public bool DeleteProject(Project project)
        {
            try
            {
                _projRepo.DeleteProject(project);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Service Error:  (DS139). " + ex.Message);
                throw;
            }
        }

        public bool UpdateProject(Project project)
        {
            if (!ValidateProj(project))
                return false;

            try
            {
                _projRepo.UpdateProject(project);
                return true;
            }
            catch (Exception ex)
            {

                logger.Error(ex, "Service Error:  (DS124). " + ex.Message);
                throw;
            }
        }

        public IEnumerable<Project> GetProjects()
        {
            return _projRepo.GetProjects();
        }

        Project IProjectService.GetProjectById(int ProjectID)
        {
            return _projRepo.GetProjectById(ProjectID);
        }

        public IEnumerable<Project> Projects()
        {
            return _projRepo.GetProjects();
        }

        public bool ValidateProj(Project project)
        {
            throw new NotImplementedException();
        }


    }
}
