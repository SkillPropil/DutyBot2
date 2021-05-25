using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Duty_Bot2
{
    public partial class Version : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DBConnection.Status == "Неактивный")
            {


                Response.Redirect("Authorization.aspx");

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
        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    } }