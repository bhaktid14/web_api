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

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeesById(int id)
        {
            using (web_api_crud_dbEntities1 entities = new web_api_crud_dbEntities1())
            {
                var emp = db.Employees.Where(model => model.T_id == id).FirstOrDefault();
                return Ok(emp);
            }
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
            using (web_api_crud_dbEntities1 entities = new web_api_crud_dbEntities1())
            {
                db.Employees.Add(e);
                db.SaveChanges();
                return Ok();
            }
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            using (web_api_crud_dbEntities1 entities = new web_api_crud_dbEntities1())
            {
                var emp = db.Employees.Where(model => model.T_id == e.T_id).FirstOrDefault();
                if(emp != null)
                {
                    emp.T_id = e.T_id;
                    emp.T_name= e.T_name;   
                    emp.T_priority = e.T_priority;  
                    emp.Date= e.Date;
                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
        }
    }
}