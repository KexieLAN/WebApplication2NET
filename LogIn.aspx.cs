using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2NET
{
    public partial class LogIn : System.Web.UI.Page
    {
        string connectString = @"Data Source=KEXIELAN\SQLEXPRESS;Database=MySer;User ID=WebMSU;Pwd=LXY621621;";
        private SqlConnection sConn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"]!=null)
            {
                Response.Redirect("index.aspx");
                return;
            }
            sConn = new SqlConnection(connectString);
            sConn.Open();
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string sqlString = "SELECT Upass FROM UserInfo WHERE Uname='"+Login1.UserName+"'";
            SqlCommand cmd = new SqlCommand(sqlString, sConn);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string ss;
            try{
                ss = dr[0].ToString();
                if (ss.Equals(Login1.Password))
                {
                    Session["User"] = Login1.UserName;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Login1.FailureText = "登陆失败，请检查用户名或密码是否正确";
                }
            }
            catch
            {
                Login1.FailureText = "登陆失败，请检查用户名或密码是否正确";
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (sConn!=null)
            {
                sConn.Close();
            }
        }
    }
}