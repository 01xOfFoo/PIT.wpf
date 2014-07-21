using System;
using System.Linq;
using PIT.REST.Data.Context;
using PIT.REST.Data.Entities;
using PIT.REST.Data.Repositories.Contracts;
using PIT.REST.Data.Repositories.Exceptions;

namespace PIT.REST.Data.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly PITContext _context;

        public IssueRepository(PITContext context)
        {
            _context = context;
        }

        public IQueryable<Issue> GetAllIssues()
        {
            return _context.Issues.AsQueryable();
        }

        public Issue GetIssue(int issueId)
        {
            return _context.Issues.FirstOrDefault(i => i.Id == issueId);
        }

        public Issue Create(Issue issue)
        {
            try
            { 
                var createdIssue = _context.Issues.Add(issue);
                _context.SaveChanges();
                return createdIssue;
            }
            catch (Exception ex)
            {
                throw new EntityNotSavedException("issue", ex);
            }
        }

        public Issue Update(Issue issue)
        {
            try
            {
                var foundIssue = _context.Issues.Find(issue.Id);
                if (foundIssue != null)
                {
                    _context.Entry(foundIssue).CurrentValues.SetValues(issue);
                    foundIssue.Project = issue.Project;
                    _context.SaveChanges();

                    return issue;
                }
                throw new EntityNotFoundException();
            }
            catch (Exception ex)
            {
                throw new EntityNotSavedException("issue", ex);
            }
        }

        public void Delete(int issueId)
        {
            try
            {
                var entity = _context.Issues.Find(issueId);
                if (entity != null)
                {
                    _context.Issues.Remove(entity);
                    _context.SaveChanges();
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
            catch (Exception ex)
            {
                throw new EntityNotDeletedException("issue", ex);
            }
        }
    }
}