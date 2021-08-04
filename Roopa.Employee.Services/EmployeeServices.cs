
using Roopa.Employee.Repository;
using System.Collections.Generic;
using Roopa.Services.Model;
using System;
using Roopa.Repository.Model;
using servicemodels = Roopa.Services.Model;
using repositorModels = Roopa.Repository.Model;

namespace Roopa.Employee.Services
{
    public class EmployeeServices
    {
        public object Address;

        public List<Roopa.Services.Model.EmpModel> GetAllEmployees()
        {
            EmpRepository emp = new EmpRepository();
            var result = emp.GetAllEmployees();

            List<servicemodels.EmpModel> empModels = new List<servicemodels.EmpModel>();
            foreach (var item in result)
            {
                empModels.Add(new servicemodels.EmpModel
                {
                    Address = item.Address+"123"
                });
            }
            return empModels;
        }
        public bool AddEmployee(Roopa.Services.Model.EmpModel obj)   //To Add Emp Details
        {
            EmpRepository emp = new EmpRepository();

            repositorModels.EmpModel empModel = new repositorModels.EmpModel
            {
                Address = obj.Address
            };
            var result = emp.AddEmployee(empModel);


            return result;
        }

        public bool AddEmployee(EmployeeServices emp)
        {
            throw new NotImplementedException();
        }
    }
}
