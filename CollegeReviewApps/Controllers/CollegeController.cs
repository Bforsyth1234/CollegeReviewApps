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
        public IHttpActionResult Post(string name)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = new College();
                model.Name = name;
                db.Colleges.Add(model);
                db.SaveChanges();
            }
            return Ok();
        }
        public IHttpActionResult PUT(CollegeReviewApps.DataModel.College college)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var currentCollege = db.College.Find(college.id);
                currentCollege = college.Name;
                db.SaveChanges();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var currentCollege = db.Colleges.Find(id);
                db.Colleges.Remove(currentCollege);
                db.SaveChanges();
            }
            return Ok();
        
        }
    }


}