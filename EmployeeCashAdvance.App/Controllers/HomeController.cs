
using EmployeeCashAdvance.App.Models;
using EmployeeCashAdvance.App.ViewModels;
using EmployeeCashAdvance.Dapper.Interface;
using EmployeeCashAdvanceApp.Contract.Interface;
using EmployeeCashAdvanceApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCashAdvance.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartment department;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork  unitOfWork,IDepartment department)
        {
            _logger = logger;
            this._unitOfWork = unitOfWork;
            this.department = department;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Response")]
        public IActionResult SucessResponse()
        {
            return View();
        }
        [HttpGet]
        public async  Task <IActionResult> CashAdvanceForm()
        {
            ViewBag.department = new SelectList(await department.GetAll(), "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public async   Task<IActionResult> CashAdvanceForm(EmployeeCreateViewModel model )
        {
            if (ModelState.IsValid)
            {
                if (model.Amount.Contains(","))
                {
                    ModelState.AddModelError("", "Invalid amount format enter the amount without comma");
                    ViewBag.department = new SelectList(await department.GetAll(), "DepartmentId", "DepartmentName");
                    return View();
                }
                else
                {

                    var empdetails = new EmployeeDetails
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Amount = model.Amount,
                       
                    };
                    await _unitOfWork.Employeedetails.Insert(empdetails);
                    await _unitOfWork.Save();
                    return View("Index");
                    // Send a mail to the HOD for Approval

                    //Send a mail to the employee for successful submission of the form
                }
            }
            
            
                ModelState.AddModelError("", "Invalid Credentials");
                ViewBag.department = new SelectList(await department.GetAll(), "DepartmentId", "DepartmentName");
                return View();
            
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
