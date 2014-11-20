using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using POS.Models;

namespace POS.Controllers
{
    public class POSController : Controller
    {
        // GET: POS
        public ActionResult Index(string studentId)
        {
            QuestionsList QuestionsList = new QuestionsList();
            AnswerOptionsList answersList = new AnswerOptionsList();
            POS_Row row = new POS_Row();
            DataTable dt = new DataTable();
            DataActions da = new DataActions();
            QuestionsList=da.GetQuestionsList();
            answersList = da.GetAnswersList();
            row.ql = QuestionsList;
            row.aol = answersList;
          //  string studentId = "304324684";
            Student st = new Student();
            st = da.getStudentDetails(studentId);
            ViewBag.studentId = st.StudentID;
            ViewBag.studentLastName = st.LastName;
            ViewBag.studentFirstName = st.FirstName;
            ViewBag.studentFrameName = st.FrameName;
            ViewBag.studentClassName = st.ClassName;
            return View(QuestionsList);
        }

        [HttpPost]
        public void saveResults(Results[] results  )
        {
            DataTable dt = new DataTable();
            DataActions da = new DataActions();
            int eventId = da.CreateNewEvent("304324684");
            string sql="insert into POS_Results values ({0},{1},{2})";
            string insert = "";
            foreach (var item in results)
            {
                insert = insert + string.Format(sql,eventId, item.QuestionId, item.SelectedAnswer) + " ";
            }
            //dt = arrayToTable(results);
            //da.saveResults(dt);
            da.saveResults(insert);
        }

        private DataTable arrayToTable(Results[] results)
        {
            DataTable dt = new DataTable();
            Results res = new Results();
            res = results[0];
            dt.Columns.Add("questionId", typeof(int));
            dt.Columns.Add("selectedAnswer", typeof(int));           

            for (int j = 0; j < results.Length; j++)
            {
                DataRow row = dt.NewRow();
                    row["questionId"] = results[j].QuestionId;
                    row["selectedAnswer"] = results[j].SelectedAnswer;
                dt.Rows.Add(row);
            }
            return dt;
        }

        // GET: POS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: POS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: POS/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: POS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: POS/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: POS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: POS/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
