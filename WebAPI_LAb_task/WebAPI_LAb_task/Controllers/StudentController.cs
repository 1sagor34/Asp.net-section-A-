using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_LAb_task.Models.Database;

namespace WebAPI_LAb_task.Controllers
{
    public class StudentController : ApiController
    {
        Labtask_finalEntities db = new Labtask_finalEntities();
        [Route("api/Studentcreate/student")]
        [HttpPost]
        public HttpResponseMessage Studentcreate(Student data)
        {
            Student obj = new Student();
            obj.St_name = data.St_name;
            obj.Dob = data.Dob;
            obj.Deptid = data.Deptid;
            db.Students.Add(obj);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Student created successfully");
        }

        [Route("api/Studentedit/Student/{id}")]
        [HttpPost]
        public HttpResponseMessage Studentedit(Student stu, int id)
        {
            var stud = db.Students.Where(l => l.Stid.Equals(id)).FirstOrDefault();
            if (stud != null)
            {
                stud.St_name = stu.St_name;
                stud.Dob = stu.Dob;
                db.Entry(stud).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Student details Edited");
        }
        [Route("api/Studentdelete/Student/{id}")]
        [HttpPost]
        public HttpResponseMessage Studentdelete(int id)
        {
            var Stu = db.Students.Where(l => l.Stid.Equals(id)).FirstOrDefault();
            db.Students.Remove(Stu);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Student deleted");
        }
        [Route ("api/studentdetails/student/{id}")]
        [HttpGet]
        public HttpResponseMessage Studentdetails(int id)
        {
            var item = db.Students.Where(l => l.Stid.Equals(id)).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK,item);
        }
    }
}
