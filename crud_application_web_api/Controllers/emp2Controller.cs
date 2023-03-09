using crud_application_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
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
            var response = client.GetAsync("");
            response.Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
            }
            return View(emp_list);
        }
    }
}