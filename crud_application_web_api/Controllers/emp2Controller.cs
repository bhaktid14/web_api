using crud_application_web_api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace crud_application_web_api.Controllers
{
    public class emp2Controller : Controller
    {
        // GET: emp2
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Employee> emp_list =new List<Employee>();
            client.BaseAddress = new Uri("");
            var response = client.GetAsync("emp");
            response.Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
            }
            return View(emp_list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("");
            var response = client.PostAsJsonAsync<Employee>("emp",emp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Create");
        }
        public ActionResult Details(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("");
            var response = client.GetAsync("emp?T_id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
          
        
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();

                e = display.Result;
            }
            return View(e);
        }
        public ActionResult Edit(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("");
            var response = client.GetAsync("emp?T_id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {


                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();

                e = display.Result;
            }
            return View(e);
        }
        [System.Web.Http.HttpPost]
        public ActionResult Edit(Employee e) {
            client.BaseAddress = new Uri("");
            var response = client.PutAsJsonAsync<Employee>("emp", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Edit");
        }

    }
    
    
}