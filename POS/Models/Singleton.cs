using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace POS.Models
{
    public class Singleton
    {
        public static Singleton instance;

        public Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public SqlConnection GetDBConnection()
        {
            //SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["POS"].ConnectionString);
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Book10PE"].ConnectionString);
            return conn;
        }

        public DataTable SelectDTQuery(string sqlString)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = GetDBConnection();
            conn.Open();
            if (conn == null)
            {
                throw new System.ArgumentException("The connection is closed");
            }
            SqlCommand sql = new SqlCommand(sqlString, conn);
            sql.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sql;
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public object selectDBScalar(string sql)
        {
            SqlConnection cn = GetDBConnection();
            SqlCommand cD = new SqlCommand(sql, cn);
            cD.CommandType = CommandType.Text;
            cn.Open();
            object o = null;
            try
            {
                o = cD.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return o;
        }


        public Exception executeSql(string sql)
        {
            Exception eex = null;
            SqlConnection cn = GetDBConnection();
            DataTable dt = new DataTable();
            SqlCommand cD = new SqlCommand(sql, cn);
            cD.CommandType = CommandType.Text;
            cn.Open();
            object o = null;
            try
            {
                o = cD.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eex = ex;
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return eex;

        }
       
    }
}