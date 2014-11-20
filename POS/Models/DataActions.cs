using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS.Models;
using System.Data;
namespace POS.Models
{
    public class DataActions
    {

        internal QuestionsList GetQuestionsList()
        {
            DataTable dt = new DataTable();
            QuestionsList ql = new QuestionsList();
            List<POS_Question> pq= new List<POS_Question>();
            int i = 0;
            Singleton s = new Singleton();
            string sql = "select Id,QuestionId,Question,AudioURL from POS.dbo.POS_Questions order by QuestionId";
            dt = s.SelectDTQuery(sql);
            foreach(DataRow  row in dt.Rows)
            {
                POS_Question q = new POS_Question();
                
                q.Id = int.Parse(row[0].ToString());
                q.QuestionId = int.Parse(row[1].ToString());
                q.Question = row[2].ToString();
                q.AudioURL = row[3].ToString();
                pq.Add(q);
            }
            ql.AddQuestionsList(pq);
            return ql;
        }

        internal AnswerOptionsList GetAnswersList()
        {
            DataTable dt = new DataTable();
            AnswerOptionsList aol = new AnswerOptionsList();
            List<POS_AnswerOptions> pq = new List<POS_AnswerOptions>();
            int i = 0;
            Singleton s = new Singleton();
            string sql = "select Id,Answer from POS.dbo.POS_AnswerOptions order by Id";
            dt = s.SelectDTQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                POS_AnswerOptions q = new POS_AnswerOptions();

                q.Id = int.Parse(row[0].ToString());
                q.Answer = int.Parse(row[1].ToString());
                pq.Add(q);
            }
           aol.AddToAnswersList(pq);
            return aol;
        }

        internal void saveResults(string insertString)
        {
            Singleton s = new Singleton();
            s.executeSql(insertString);
        }

        internal Student getStudentDetails(string studentId)
        {
            DataTable dt = new DataTable();
            Singleton s = new Singleton();
            string sql = string.Format("SELECT  [CustomerId],[CustLastName],[CustFirstName],[CustFrameName],[CustClassName],[CustFrameId] FROM [POS].[dbo].[CustomersList] where customerid = {0}", studentId);
            dt = s.SelectDTQuery(sql);
            Student st = new Student();
            st.StudentID = dt.Rows[0][0].ToString();
            st.LastName = dt.Rows[0][1].ToString();
            st.FirstName = dt.Rows[0][2].ToString();
            st.FrameName = dt.Rows[0][3].ToString();
            st.ClassName = dt.Rows[0][4].ToString();
            return st;
        }

        internal int CreateNewEvent(string customerId)
        {
            int eventId;
            Singleton s = new Singleton();
            DateTime now = new DateTime();
            now = DateTime.Now;
            string sql = string.Format("insert into POS_CustEventList values ({0},{1},GETDATE(),{2})", customerId, 999, 864);
            string getIdSql = string.Format("select max(id) from POS_CustEventList where customerId=304324684 and custEventType={0}", 999);
            s.executeSql(sql);
            eventId = (int)s.selectDBScalar(getIdSql);
            return eventId;
        }

        internal CustomersList GetCustomersList(int userId)
        {
            CustomersList cll = new CustomersList();
            Singleton s = new Singleton();
            List<Customer> cl = new List<Customer>();
            string sql = string.Format("select [CustomerId],[CustLastName],[CustFirstName],[CustFrameName],[CustClassName],[CustFrameId] from CustomersList where CustFrameId=(select userFrameId from Users where userId={0})", userId);
            DataTable dt = new DataTable();
            dt = s.SelectDTQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                Customer cust = new Customer();
                cust.CustomerId = row["CustomerId"].ToString();
                cust.CustomerLastName = row["CustLastName"].ToString();
                cust.CustomerFirstName = row["CustFirstName"].ToString();
                cust.CustomerFrameId = (int)row["CustFrameId"];
                cust.CustomerFullName = cust.CustomerLastName + " " + cust.CustomerFirstName;
                cl.Add(cust);
            }
            cll.AddToAnswersList(cl);
           
            return cll;
        }
    }
}