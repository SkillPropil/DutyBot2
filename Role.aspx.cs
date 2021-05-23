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
    public partial class Role : System.Web.UI.Page
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
                QR = DBConnection.qrRole;
                if (!IsPostBack)
                {
                    gvFill(QR);




                }
            }
        }

        private void gvFill(string qr)
        {
            sdsRole.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsRole.SelectCommand = qr;
            sdsRole.DataSourceMode = SqlDataSourceMode.DataReader;
            gvRole.DataSource = sdsRole;
            gvRole.DataBind();
        }

        protected void gvRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvRole.SelectedRow;
            tbRoleName.Text = row.Cells[2].Text.ToString();





            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }



        protected void gvRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;


        }

        protected void gvRole_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {

                case ("Наименование роли"):
                    e.SortExpression = "[RoleName]";
                    break;

            }
            sortGridView(gvRole, e, out sortDirection, out strField);
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
            textBoxes.Add(tbRoleName);

            if (!err)
            {
                SqlCommand command = new SqlCommand("", DBConnection.connection);




                command.CommandText = "INSERT INTO [dbo].[Role] ([RoleName]) values ('" + tbRoleName.Text + "')";



                DBConnection.connection.Open();
                command.ExecuteNonQuery();
                DBConnection.connection.Close();
                Response.Redirect(Request.RawUrl);
                gvFill(QR);

            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            


                    switch (tbRoleName.Text == "")
                    {
                case (true):
                    tbRoleName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbRoleName.BackColor = System.Drawing.Color.White;


                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "update [dbo].[Role] set " +
                        "[RoleName] ='" + tbRoleName.Text + "' " +
                        " where ID_Role = " + DBConnection.IDrecord + "";

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
            command.CommandText = "delete from [dbo].[Role] " +
                "where ID_Role = " + DBConnection.IDrecord + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            gvFill(QR);
            Response.Redirect(Request.RawUrl);
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvRole.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[2].Text.Equals(tbSearch.Text))
                    //|| row.Cells[4].Text.Equals(tbSearch.Text)
                    //|| row.Cells[5].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.Green;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [RoleName] like '%" + tbSearch.Text + "%'";


            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);



            gvRole.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }


        // При нажатии на дату календаря дата выводится в текстовое поле


    }
}