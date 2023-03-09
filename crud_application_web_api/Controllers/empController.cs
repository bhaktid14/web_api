using crud_application_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace crud_application_web_api.Controllers
{
    public class empController : ApiController
    {
        web_api_crud_dbEntities1 db = new web_api_crud_dbEntities1();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployees()
        {
            using (web_api_crud_dbEntities1 entities = new web_api_crud_dbEntities1())
            {
                List<Employee> list = db.Employees.ToList();
                return Ok();
            }
               

        }
    }
}
