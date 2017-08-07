using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sgprojectmanagement.Models;

namespace sgprojectmanagement.Services
{
    interface IemployeeProfile
    {
        void Insert(EmployeeProfile employeeProfile);
        Task<EmployeeProfile> Get(string i);
        Task<IEnumerable<EmployeeProfile>> GetAll();
        void Delete(string id);
        void Update(string id, string firstName);
    }
}
