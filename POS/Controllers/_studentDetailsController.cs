using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Models;
using POS.Controllers;
using System.Data;

namespace POS.Controllers
{
    public class _studentDetailsController : Controller
    {
        // GET: _studentDetails
        public ActionResult _studentDetails()
        {
            DataTable dt = new DataTable();
            string studentId = "304324684";
            DataActions da = new DataActions();
            Student st = new Student();
            st = da.getStudentDetails(studentId);
            return View(dt);
        }
    }
}