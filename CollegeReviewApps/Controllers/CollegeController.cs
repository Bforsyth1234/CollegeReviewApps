using CollegeReviewApps.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollegeReviewApps.Controllers
{
    public class CollegeController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<CollegeReviewApps.DataModel.College> colleges;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                colleges = db.Colleges.ToList();
            }
            return Ok(colleges);
        }
        public IHttpActionResult Get(int id)
        {
            CollegeReviewApps.DataModel.College college;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                college = db.Colleges.Find(id);
            }
            return Ok(college);
        }
        public IHttpActionResult Post([FromBody] CollegeVM name)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = new College();
                model.Name = name.name;
                db.Colleges.Add(model);
                db.SaveChanges();
            }
            return Ok();
        }
        public IHttpActionResult PUT([FromBody] CollegeVM college)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = db.Colleges.Find(college.id);
                model.Name = college.name;
                db.SaveChanges();
            }
            return Ok();
        }
        public IHttpActionResult Delete([FromBody] CollegeVM collegeDelete)
        {

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = db.Colleges.Find(collegeDelete.id);
                db.Colleges.Remove(model);
                db.SaveChanges();
            }
            return Ok();
        
        }
    }


}