using Roopa.Employee.Services.EmployeeServiceReference;
using System;
using System.Collections.Generic;
using servicemodels = Roopa.Services.Model;

namespace Roopa.Employee.Services
{
    public class EmployeeServices
    {

        //public object Address;

        //public object ViewBag { get; private set; }

        //public List<Roopa.Services.Model.EmpModel> GetAllEmployees()
        //{
        //    EmpRepository emp = new EmpRepository();
        //    var result = emp.GetAllEmployees();

        //    List<servicemodels.EmpModel> empModels = new List<servicemodels.EmpModel>();
        //    foreach (var item in result)
        //    {
        //        empModels.Add(new servicemodels.EmpModel
        //        {
        //            Address = item.Address


        //        });
        //    }
        //    return empModels;
        //}
        //public bool AddEmployee(Roopa.Services.Model.EmpModel obj)   //To Add Emp Details
        //{
        //    EmpRepository empRepository = new EmpRepository();

        //    repositorModels.EmpModel empModel = new repositorModels.EmpModel
        //    {
        //        Address = obj.Address,
        //        Name=obj.Name,
        //        City=obj.City

        //    };
        //    var result = empRepository.AddEmployee(empModel);


        //    return result;
        //}

        
            public List<Roopa.Services.Model.EmpModel> GetAllEmployeesWCF()
        {
            EmployeeServiceClient employeeServiceClient = GetEmployeeServiceClient();
            var result = employeeServiceClient.GetAllEmployees();
            List<servicemodels.EmpModel> empModels = new List<servicemodels.EmpModel>();
            foreach (var item in result)
            {
                empModels.Add(new servicemodels.EmpModel
                {
                    Address = item.Address,
                    Name=item.Name,
                    City = item.City


                });
            }
            return empModels;

        }
        public bool AddEmployeeWCF(servicemodels.EmpModel employee)
        {
            try
            {
                EmployeeServiceClient employeeServiceClient = GetEmployeeServiceClient();
                var result = employeeServiceClient.AddEmployee(employee);

                return result;
            }

            catch(Exception)
            {
                return false;
            }
        }

        private static EmployeeServiceClient GetEmployeeServiceClient()
        {
            return new EmployeeServiceClient();
        }

        public string WCF()
        {
            EmployeeServiceReference.EmployeeServiceClient employeeServiceClient = GetEmployeeServiceClient();
            return employeeServiceClient.Message();
        }


    }
}
