using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Duty_Bot2
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (DBConnection.Status == "Неактивный")
            {
                
                Response.Redirect("Authorization.aspx");

            }

            if (DBConnection.RolePerm_ID == "Дежурный админ")
            {
                LinkRole.Visible = false;
                LinkUser.Visible = false;
                LinkScheduleType.Visible = false;
                LinkWorkStatus.Visible = false;
            }
            else
            {
                LinkRole.Visible = true;
                LinkUser.Visible = true;
                LinkScheduleType.Visible = true;
                LinkWorkStatus.Visible = true;
            }

            if ((string)Session["uname"] == null)
                {
                Response.Redirect("Authorization.aspx");
            }
                else
                {
                   
                LinkButton7.Text = "Привет, " + (string)Session["uname"];
            }
           
        }

       

        protected void btGraphik_Click(object sender, EventArgs e)
        {
            Response.Redirect("Schedule.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Otchet.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Role.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleType.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkStatus.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleRed.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Permission.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Authorization.aspx");
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Вы единственный человек, который решил прочитать эту информацию.');</script>");
        }
    }
}