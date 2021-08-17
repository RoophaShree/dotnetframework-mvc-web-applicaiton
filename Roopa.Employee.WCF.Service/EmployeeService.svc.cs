using Roopa.Employee.Repository;
using Roopa.Services.Model;
using System;
using System.Collections.Generic;

namespace Roopa.Employee.WCF.Service
{

    public class EmployeeService : IEmployeeService
    {
        
        public bool AddEmployee(Roopa.Services.Model.EmpModel obj)
        {
            try
            {
                EmpRepository empRepository = new EmpRepository();

                Roopa.Repository.Model.EmpModel empModel = new Roopa.Repository.Model.EmpModel
                {
                    Address = obj.Address,
                    Name = obj.Name,
                    City = obj.City

                };
                var result = empRepository.AddEmployee(empModel);
                return result;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int Id)
        {
            EmpRepository empRepository = new EmpRepository();
            var result = empRepository.DeleteEmployee(Id);
            return result;
        }

        public List<EmpModel> GetAllEmployees()
        {
            EmpRepository emp = new EmpRepository();
            var result = emp.GetAllEmployees();

            List<Roopa.Services.Model.EmpModel> empModels = new List<Roopa.Services.Model.EmpModel>();
            foreach (var item in result)
            {
                empModels.Add(new Roopa.Services.Model.EmpModel
                {
                    Address = item.Address,
                    Name = item.Name,
                    City = item.City


                });
            }
            return empModels;
        }

        public string CheckHealth()
        {
            return "Service Is Running";
        }

        public bool UpdateEmployee(Roopa.Repository.Model.EmpModel obj)
        {
            EmpRepository empRepository = new EmpRepository();
            var result = empRepository.UpdateEmployee(obj);
            return result;
        }
    }
}
