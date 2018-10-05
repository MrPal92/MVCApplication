using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstMVCApplication.Models;

namespace FirstMVCApplication.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objEmployee = new EmployeeDataAccessLayer();

        public IActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList = objEmployee.GetAllEmployees().ToList();
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                objEmployee.AddNewEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        { 
            Employee employee = new Employee();
            employee = objEmployee.GetEmployeeById(ID);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                objEmployee.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        public IActionResult Details(int ID)
        {
            Employee employee = new Employee();
            employee = objEmployee.GetEmployeeById(ID);

            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Employee employee = new Employee();
            employee = objEmployee.GetEmployeeById(ID);

            return View(employee);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConformed(int Id)
        {
            objEmployee.DeleteEmployee(Id);
            return RedirectToAction("Index");
        }
    }
}