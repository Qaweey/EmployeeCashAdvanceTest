using EmployeeCashAdvance.App.ViewModels;
using EmployeeCashAdvance.Dapper.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCashAdvance.App.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEmployeeDetails _employeeDetails;

        public AdminController(IEmployeeDetails employeeDetails)
        {
            this._employeeDetails = employeeDetails;
        }
        // GET: AdminController
        public async Task< IActionResult> ListOfCashRequest()

        {
            var modellist = new List<EmployeeDetailsGetViewModel>();
            var listOfEmployeeDetails = await _employeeDetails.GetAll();
            foreach (var item in listOfEmployeeDetails)
            {
                var emplyeedetail = new EmployeeDetailsGetViewModel
                {
                    Name = item.Name,
                    Email = item.Email,
                    Amount = item.Amount,
                    IsApproved = item.IsApproved,
                    Department = item?.Departments?.DepartmentName,


                };
                modellist.Add(emplyeedetail);



            }


            return View(modellist);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
