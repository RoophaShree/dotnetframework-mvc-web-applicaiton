using Roopa.Repository.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;

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
