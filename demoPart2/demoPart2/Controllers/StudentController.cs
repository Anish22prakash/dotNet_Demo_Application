using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoPart2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public String search(int id) {

            if (id == 2)
            {
                return "you are student of this college";
            }
            else
                return "you are not a student of this college";
        }

        public ActionResult find()
         {
            return Redirect("www.google.com");
         }
    }
}