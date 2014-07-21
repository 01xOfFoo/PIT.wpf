using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PIT.REST.Data.Repositories.Contracts;
using PIT.REST.Models;
using PIT.REST.Models.Factories;

namespace PIT.REST.Controllers
{
    public class IssuesController : ApiController
    {
        private readonly IIssueRepository _repository;
        private readonly IModelFactory _modelFactory;

        public IssuesController(IIssueRepository issueRepository, IModelFactory modelFactory)
        {
            _repository = issueRepository;
            _modelFactory = modelFactory;
        }

        // GET api/<controller>
        public IEnumerable<IssueModel> Get()
        {
            var issues = _repository.GetAllIssues();
            return issues.ToList().Select(i => _modelFactory.CreateIssue(i));
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var issue = _repository.GetIssue(id);
                if (issue.Exists())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, _modelFactory.CreateIssue(issue));
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // GET api/<controller>?project=1
        public HttpResponseMessage GetIssuesByProject(int projectId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repository.GetAllIssues().Where(i => i.Project.Id == projectId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]IssueModel issueModel)
        {
            try
            {
                var model = _modelFactory.ParseIssue(issueModel);
                var createdIssue = _repository.Create(model);
                return Request.CreateResponse(HttpStatusCode.Created, _modelFactory.CreateIssue(createdIssue));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }
    }
}