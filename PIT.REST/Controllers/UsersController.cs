using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PIT.REST.Data.Entities;
using PIT.REST.Data.Repositories.Contracts;
using PIT.REST.Models;
using PIT.REST.Models.Factories;

namespace PIT.REST.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IRepository<User> _repository;
        private readonly IModelFactory _modelFactory;

        public UsersController(IRepository<User> userProvider, IModelFactory modelFactory)
        {
            _repository = userProvider;
            _modelFactory = modelFactory;
        }

        // GET api/<controller>
        public IEnumerable<UserModel> Get()
        {
            var users = _repository.GetAll();
            return users.ToList().Select(u => _modelFactory.CreateUser(u));
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var user = _repository.Get(id);
                if (user.Exists())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, _modelFactory.CreateUser(user));
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]UserModel userModel)
        {
            try
            {
                var user = _modelFactory.ParseUser(userModel);
                var responseModel = _repository.Create(user);
                return Request.CreateResponse(HttpStatusCode.Created, _modelFactory.CreateUser(responseModel));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]UserModel userModel)
        {
            try
            {
                var user = _modelFactory.ParseUser(userModel);
                var responseModel = _repository.Update(user);
                return Request.CreateResponse(HttpStatusCode.OK, responseModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var responseModel = _repository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, responseModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
