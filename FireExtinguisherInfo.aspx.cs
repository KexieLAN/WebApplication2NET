using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2NET
{
    public partial class FireExtinguisherInfo : System.Web.UI.Page
    {
        string connectString = @"Data Source=KEXIELAN\SQLEXPRESS;Database=MySer;User ID=WebMSU;Pwd=LXY621621;";
        private SqlConnection sConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LogIn.aspx");
                return;
            }
            sConn = new SqlConnection(connectString);
            sConn.Open();
            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (sConn != null)
            {
                sConn.Close();
            }
        }

        protected void ButtonCleanInfo_Click(object sender, EventArgs e)
        {
            string sqlString = "DELETE FROM FireExtinguisherInfo";
            SqlCommand cmd = new SqlCommand(sqlString, sConn);
            cmd.ExecuteNonQuery();
        }

        protected void ButtonClearHis_Click(object sender, EventArgs e)
        {
            string sqlString = "DELETE FROM FireExtinguisherInfo_History";
            SqlCommand cmd = new SqlCommand(sqlString, sConn);
            cmd.ExecuteNonQuery();
        }

        protected void ButtonF_Click(object sender, EventArgs e)
        {
            Response.Redirect("FireExtinguisherInfo.aspx");
        }

        protected void ButtonF2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FireExtinguisherInfo.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // 得到该控件
            GridView theGrid = sender as GridView;
            int newPageIndex = 0;
            if (e.NewPageIndex == -3)
            {
                //点击了Go按钮
                TextBox txtNewPageIndex = null;

                //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
                GridViewRow pagerRow = theGrid.BottomPagerRow;

                if (pagerRow != null)
                {
                    //得到text控件
                    txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
                }
                if (txtNewPageIndex != null)
                {
                    //得到索引
                    newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
                }
            }
            else
            {
                //点击了其他的按钮
                newPageIndex = e.NewPageIndex;
            }
            //防止新索引溢出
            newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
            newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

            //得到新的值
            theGrid.PageIndex = newPageIndex;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}