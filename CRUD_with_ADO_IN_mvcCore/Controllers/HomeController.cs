using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUD_with_ADO_IN_mvcCore.Models;
using System.Data;
using System.Data.SqlClient;
namespace CRUD_with_ADO_IN_mvcCore.Controllers
{
    public class HomeController : Controller
    {
       public string msg = String.Empty;
        db contest = new db();
        public IActionResult Index()
        {
            Employee model = new Employee();
            model.flag = "get";
            DataSet ds = contest.Empget(model,out msg);
            List<Employee> employeesList = new List<Employee>();
            if(ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    employeesList.Add(new Employee
                    {
                        sr_No = Convert.ToInt32(item["sr_No"]),
                        City = item["City"].ToString(),
                        Emp_name = item["Emp_name"].ToString(),
                        Country = item["Country"].ToString(),
                        Department = item["Department"].ToString()
                    });
                }
            }
            
            return View(employeesList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind]Employee model)
        {
            try
            {
                model.flag = "insert";
                contest.Empdml(model, out msg);

                TempData["msg"] = msg;
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
                throw;
            }

            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee model = new Employee();
            model.sr_No = id;
            model.flag = "getd";
         DataSet ds= contest.Empget(model, out msg);
            List<Employee> employeesList = new List<Employee>();

            foreach (DataRow item in ds.Tables[0].Rows)
            {

                model.sr_No = Convert.ToInt32(item["sr_No"]);
                model.City = item["City"].ToString();
                model.Emp_name = item["Emp_name"].ToString();
                model.Country = item["Country"].ToString();
                model.Department = item["Department"].ToString();
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int id,[Bind]Employee model)
        {
            try
            {
                model.sr_No = id;
                model.flag = "update";
                contest.Empdml(model, out msg);

                TempData["msg"] = msg;
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
                throw;
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                Employee model = new Employee();
                model.flag = "delete";
                model.sr_No = id;
                contest.Empdml(model, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
                throw;
            }

            return RedirectToAction(nameof(Index));

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
