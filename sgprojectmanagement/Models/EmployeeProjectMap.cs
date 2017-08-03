using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgprojectmanagement.Models
{
    public class EmployeeProjectMap
    {
        public string EmployeeId { get; set; }
        public string ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectManager { get; set; }
    }
}