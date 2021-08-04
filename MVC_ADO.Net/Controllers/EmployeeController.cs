using System;
using System.Web.Mvc;
using Roopa.Employee.Services;
using Roopa.Controller.Model;

namespace MVC_ADO.Net.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Student
        public ActionResult GetAllEmpDetails()
        {
            EmployeeServices employee = new EmployeeServices();
            ModelState.Clear();
            return View(employee.GetAllEmployees());
        }

        public ActionResult AddEmployee()
        {
            return View();
        }
       

        [HttpPost]
        public ActionResult AddEmployee(EmpModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeServices employee = new EmployeeServices();

                    EmployeeServices emp = new EmployeeServices();
                    
                    if (employee.AddEmployee(emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
                
            }
            
            catch(Exception)
            {
                return View();
            }
        }

        public ActionResult EditEmpDetails(int id)
        {
            EmployeeServices EmpRepo = new EmployeeServices();

            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.Empid == id));
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
                //EmployeeServices EmpRepo = new EmployeeServices();
                //if (EmpRepo.DeleteEmployee(id))
                //{
                //    ViewBag.AlertMsg = "Employee details deleted successfully";

                //}
                //return RedirectToAction("GetAllEmpDetails");
                return null;

            }
            catch
            {
                return View();
            }
        }

    }
}