using System;
using System.Web.Mvc;
using Roopa.Employee.Services;
using EmpModel = Roopa.Controller.Model.EmpModel;
using System.Collections.Generic;
using Roopa.Employee.Repository;

namespace MVC_ADO.Net.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Student
        public ActionResult GetAllEmpDetails()
        {
            EmployeeServices employee = new EmployeeServices();
            ModelState.Clear();
            List<Roopa.Controller.Model.EmpModel> controllerListOFEmployeeModel = new List<Roopa.Controller.Model.EmpModel>();
            var listOfServiceModels = employee.GetAllEmployeesWCF();
            foreach (var item in listOfServiceModels)
            {
                controllerListOFEmployeeModel.Add(new EmpModel
                {
                    Address = item.Address,
                    City = item.City,
                    Empid = item.Empid,
                    Name = item.Name,

                });
            }
            

            return View(controllerListOFEmployeeModel);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        public ActionResult GetService()
        {
            Roopa.Employee.Services.EmployeeServices service = new Roopa.Employee.Services.EmployeeServices();
            ViewBag.Message = service.WCF();
            return View("AddEmployee");
        }


        [HttpPost]
        public ActionResult AddEmployee(EmpModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    EmployeeServices emp = new EmployeeServices();

                    Roopa.Services.Model.EmpModel employee = new Roopa.Services.Model.EmpModel();

                    employee.Address = Emp.Address;
                    employee.Name = Emp.Name;
                    employee.City = Emp.City;
                    employee.Empid = Emp.Empid;

                    if (emp.AddEmployeeWCF(employee))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();

            }

            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult EditEmpDetails(int id)
        {
            EmployeeServices EmpRepo = new EmployeeServices();

            return View(EmpRepo.GetAllEmployeesWCF().Find(Emp => Emp.Empid == id));
        }

        [HttpPost]

        public ActionResult EditEmpDetails(int id, EmpModel obj)
        {
            try
            {
                EmployeeServices EmpRepo = new EmployeeServices();

                //EmpRepo.UpdateEmployee(obj);




                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteEmp(int id)
        {
            try
            {

                EmpRepository EmpRepo = new EmpRepository(string.Empty);
                
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");
                

            }
            catch
            {
                return View();
            }
        }

    }
}