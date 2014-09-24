using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CollegeReviewApps.DataModel.Migrations
{
    public class Seeder
    {
        public static void Seed(ApplicationDbContext context, bool createCollege = true)
        {
            if (createCollege) CreateCollege(context);
        }
        private static void CreateCollege(ApplicationDbContext context)
        {
            context.Colleges.AddOrUpdate(a => a.Name,
                new College() { Name = "VTC", id = 1 },
                new College() { Name = "UVM", id = 2 },
                new College() { Name = "USC", id = 3 }
                );
        }
    }
}
