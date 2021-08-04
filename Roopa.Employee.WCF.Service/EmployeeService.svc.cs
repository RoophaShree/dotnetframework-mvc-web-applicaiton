using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Roopa.Employee.WCF.Service
{
    
    public class EmployeeService : IEmployeeService
    {
        public string Message()
        {
            return "Hello World";
        }
    }
}
