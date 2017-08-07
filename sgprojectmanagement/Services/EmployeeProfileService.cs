using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sgprojectmanagement.unitOfWork;
using sgprojectmanagement.Models;
using System.Threading.Tasks;

namespace sgprojectmanagement.Services
{
    public class EmployeeProfileService :IemployeeProfile
    {
        protected readonly EmployeeProfileUnitOfWork _employeeProfileUnitOfWork;
        public EmployeeProfileService()
        {
            _employeeProfileUnitOfWork = new EmployeeProfileUnitOfWork();
        }

        public  void Insert(EmployeeProfile employeeProfile)
        {
            _employeeProfileUnitOfWork.EmployeeProfile.Add(employeeProfile);
        }

        public Task<EmployeeProfile> Get(string i)
        {
            return _employeeProfileUnitOfWork.EmployeeProfile.Get(i);
        }

        public Task<IEnumerable<EmployeeProfile>> GetAll()
        {
            return _employeeProfileUnitOfWork.EmployeeProfile.GetAll();
        }

        public void Delete(string id)
        {
             _employeeProfileUnitOfWork.EmployeeProfile.Delete(id);
        }

        public void Update(string id, string firstName)
        {
            _employeeProfileUnitOfWork.EmployeeProfile.Update(id, firstName);
        }
    }
}