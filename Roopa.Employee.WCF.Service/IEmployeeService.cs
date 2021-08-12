using Roopa.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Roopa.Employee.WCF.Service
{
    
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        String Message();

        [OperationContract]
        bool AddEmployee(Services.Model.EmpModel obj);

        [OperationContract]
        List<Roopa.Services.Model.EmpModel> GetAllEmployees();

        [OperationContract]
        bool UpdateEmployee(EmpModel obj);

        [OperationContract]
        bool DeleteEmployee(int Id);
    }
}
