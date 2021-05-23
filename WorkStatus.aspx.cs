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
    public partial class WorkStatus : System.Web.UI.Page
    {
        private string QR = "";
        // при загрузке страницы заполняется таблица и выпадающий список
        protected void Page_Load(object sender, EventArgs e)
        {
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
                QR = DBConnection.qrWorkStatus;
                if (!IsPostBack)
                {
                    gvFill(QR);




                }
            }
        }

        private void gvFill(string qr)
        {
            sdsWorkStatus.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsWorkStatus.SelectCommand = qr;
            sdsWorkStatus.DataSourceMode = SqlDataSourceMode.DataReader;
            gvWorkStatus.DataSource = sdsWorkStatus;
            gvWorkStatus.DataBind();
        }

        protected void gvWorkStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvWorkStatus.SelectedRow;
            tbWorkStatus.Text = row.Cells[2].Text.ToString();





            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void gvWorkStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;

        }

        protected void gvWorkStatus_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Статус смены"):
                    e.SortExpression = "[WorkStatus]";
                    break;

            }
            sortGridView(gvWorkStatus, e, out sortDirection, out strField);
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
            textBoxes.Add(tbWorkStatus);

            if (!err)
            {
                SqlCommand command = new SqlCommand("", DBConnection.connection);




                command.CommandText = "INSERT INTO [dbo].[WorkStatus] ([WorkStatus]) values ('" + tbWorkStatus.Text + "')";



                DBConnection.connection.Open();
                command.ExecuteNonQuery();
                DBConnection.connection.Close();
                Response.Redirect(Request.RawUrl);
                gvFill(QR);

            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbWorkStatus.Text == "")
            {
                case (true):
                    tbWorkStatus.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbWorkStatus.BackColor = System.Drawing.Color.White;


                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "update [dbo].[WorkStatus] set " +
                        "[WorkStatus] ='" + tbWorkStatus.Text + "' " +
                        " where ID_Status = " + DBConnection.IDrecord + "";

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
            command.CommandText = "delete from [dbo].[WorkStatus] " +
                "where ID_Status = " + DBConnection.IDrecord + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            gvFill(QR);
            Response.Redirect(Request.RawUrl);
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvWorkStatus.Rows)
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
            string newQr = QR + " where [WorkStatus] like '%" + tbSearch.Text + "%'";


            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);



            gvWorkStatus.DataBind();
        }

      

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
}