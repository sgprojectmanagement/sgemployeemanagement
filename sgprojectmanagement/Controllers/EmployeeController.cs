using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sgprojectmanagement.Services;
using sgprojectmanagement.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Web.Http;

namespace sgprojectmanagement.Controllers
{
   
    public class EmployeeController : ApiController
    {
        IService<EmployeeProfile> service;

        public EmployeeController()
        {
            service = new Service<EmployeeProfile>();
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("api/Employee")]
        public Task<IEnumerable<EmployeeProfile>> Get()
        {
            return service.GetAll();
        }
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("api/Employee/Get/{id:string}")]
        public Task<EmployeeProfile> Get(string id)
        {
            var filter = Builders<EmployeeProfile>.Filter.Eq("EmployeeId", id);
            var employee = service.Get(filter);
            return employee;
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("api/Employee/Insert")]
        public void Post([System.Web.Http.FromBody]EmployeeProfile e)
        {
            service.Add(e);
        }
        [System.Web.Mvc.HttpPut]
        [System.Web.Mvc.Route("api/Employee/Update/{id:string}")]
        public void Put(string id, [System.Web.Http.FromBody]EmployeeProfile p)
        {
            var filter = Builders<EmployeeProfile>.Filter.Eq(s => s.EmployeeId, id);
            var update = Builders<EmployeeProfile>.Update
                                .Set(s => s.FirstName, p.FirstName);

            service.Update(filter, update);
        }

        [System.Web.Mvc.HttpDelete]
        public void Delete(string id)
        {
            var filter = Builders<EmployeeProfile>.Filter.Eq("EmployeeId", id);
            service.Delete(filter);
        }
    }
}

