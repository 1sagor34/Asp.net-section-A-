using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_LAb_task.Models.Database;

namespace WebAPI_LAb_task.Controllers
{
    public class DeptController : ApiController
    {
        Labtask_finalEntities db = new Labtask_finalEntities();
        [Route("api/Deptcreate/Dept")]
        [HttpPost]
        public HttpResponseMessage Deptcreate(Department data)
        {
            Department obj = new Department();
            obj.Deptname = data.Deptname;
            db.Departments.Add(obj);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Department created successfully");
        }
        [Route("api/Departmentedit/Dept/{id}")]
        [HttpPost]
        public HttpResponseMessage Departmentedit(Department dp, int id)
        {
            var dept = db.Departments.Where(l => l.Deptid.Equals(id)).FirstOrDefault();
            dept.Deptname = dp.Deptname;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Department Edited");
        }
        [Route("api/Departmentdelete/Dept/{id}")]
        [HttpPost]
        public HttpResponseMessage Departmentdelete(int id)
        {
            var dept = db.Departments.Where(l => l.Deptid.Equals(id)).FirstOrDefault();
            db.Departments.Remove(dept);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Department deleted");
        }
        [Route("api/Departmentdetails/Dept/{id}")]
        [HttpGet]
        public HttpResponseMessage Departmentdetails(int id)
        {
            var item = db.Departments.Where(l => l.Deptid.Equals(id)).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }
    }
}

