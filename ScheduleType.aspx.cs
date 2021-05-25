using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;


namespace Duty_Bot2
{
    public partial class ScheduleType : System.Web.UI.Page
    {
        private string QR = "";
        // при загрузке страницы заполняется таблица и выпадающий список
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DBConnection.Status == "Неактивный")
            {
               
                Response.Redirect("Authorization.aspx");

            }

            if (DBConnection.RolePerm_ID == "Дежурный админ")
            {
                Response.Redirect("MainMenu.aspx");
            }

            if ((string)Session["uname"] == null)
            {
                Response.Redirect("Authorization.aspx");
            }
            else
            {
                QR = DBConnection.qrScheduleType;
                if (!IsPostBack)
                {
                    gvFill(QR);




                }
            }
        }

        private void gvFill(string qr)
        {
            sdsScheduleType.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsScheduleType.SelectCommand = qr;
            sdsScheduleType.DataSourceMode = SqlDataSourceMode.DataReader;
            gvScheduleType.DataSource = sdsScheduleType;
            gvScheduleType.DataBind();
        }

        protected void gvScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvScheduleType.SelectedRow;
            tbScheduleType.Text = row.Cells[2].Text.ToString();





            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void gvScheduleType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
           

        }

        protected void gvScheduleType_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Тип графика"):
                    e.SortExpression = "[ScheduleType]";
                    break;

            }
            sortGridView(gvScheduleType, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        private void sortGridView(GridView gridView,
     GridViewSortEventArgs e,
     out SortDirection sortDirection,
     out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            bool err = false;

            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbScheduleType);

            if (!err)
            {
                SqlCommand command = new SqlCommand("", DBConnection.connection);




                command.CommandText = "INSERT INTO [dbo].[ScheduleType] ([NameScheduleType]) values ('" + tbScheduleType.Text + "')";



                DBConnection.connection.Open();
                command.ExecuteNonQuery();
                DBConnection.connection.Close();
                Response.Redirect(Request.RawUrl);
                gvFill(QR);

            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbScheduleType.Text == "")
            {
                case (true):
                    tbScheduleType.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbScheduleType.BackColor = System.Drawing.Color.White;


                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "update [dbo].[ScheduleType] set " +
                        "[NameScheduleType] ='" + tbScheduleType.Text + "' " +
                        " where ID_ScheduleType = " + DBConnection.IDrecord + "";

                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    gvFill(QR);
                    Response.Redirect(Request.RawUrl);
                    break;
            }
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", DBConnection.connection);
            command.CommandText = "delete from [dbo].[ScheduleType] " +
                "where ID_ScheduleType = " + DBConnection.IDrecord + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            gvFill(QR);
            Response.Redirect(Request.RawUrl);
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvScheduleType.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[2].Text.Equals(tbSearch.Text))
                    //|| row.Cells[3].Text.Equals(tbSearch.Text))
                    //|| row.Cells[4].Text.Equals(tbSearch.Text)
                    //|| row.Cells[5].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.Green;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [NameScheduleType] like '%" + tbSearch.Text + "%'";


            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);



            gvScheduleType.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
}