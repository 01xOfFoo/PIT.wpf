using System;
using System.Linq;
using PIT.REST.Data.Context;
using PIT.REST.Data.Entities;
using PIT.REST.Data.Repositories.Contracts;
using PIT.REST.Data.Repositories.Exceptions;

namespace PIT.REST.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PITContext _context;

        public ProjectRepository(PITContext context)
        {
            _context = context;
        }

        public IQueryable<Project> GetAllProjects()
        {
            return _context.Projects.AsQueryable();
        }

        public Project GetProject(int projectId)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == projectId);
        }

        public Project Create(Project project)
        {
            try
            {
                var createdProject = _context.Projects.Add(project);
                _context.SaveChanges();

                return createdProject;
            }
            catch (Exception ex)
            {
                throw new EntityNotSavedException("project", ex);
            }
        }

        public Project Update(Project project)
        {
            try
            {
                var foundProject = _context.Projects.Find(project.Id);
                if (foundProject.Exists())
                {
                    _context.Entry(foundProject).CurrentValues.SetValues(project);
                    _context.SaveChanges();
                    return project;
                }
                throw new EntityNotFoundException();
            }
            catch (Exception ex)
            {
                throw new EntityNotSavedException("project", ex);
            }
        }

        public Project Delete(int projectId)
        {
            try
            {
                var foundProject = _context.Projects.Find(projectId);
                if (foundProject != null)
                {
                    _context.Projects.Remove(foundProject);
                    _context.SaveChanges();
                    return foundProject;
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
            catch (Exception ex)
            {
                throw new EntityNotDeletedException("project", ex);
            }
        }
    }
}