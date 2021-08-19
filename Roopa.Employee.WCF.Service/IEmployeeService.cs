using Roopa.Repository.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Roopa.Employee.WCF.Service
{

    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [WebInvoke(Method = "GET" , UriTemplate = "/CheckHealth", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        String CheckHealth();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddEmployee", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool AddEmployee(Services.Model.EmpModel obj);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllEmployees", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Roopa.Services.Model.EmpModel> GetAllEmployees();

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/UpdateEmployee", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool UpdateEmployee(EmpModel obj);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteEmployee", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool DeleteEmployee(int Id);
    }
}
