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
    public partial class RolePerm : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["uname"] == null)
            {
                Response.Redirect("Authorization.aspx");
            }
            else
            {
                QR = DBConnection.qrSchedule;
                if (!IsPostBack)
                {
                    gvFill(QR);

                    FillDropLists1();
                    FillDropLists2();
                    FillDropLists3();


                }
            }
        }

        private void gvFill(string qr)
        {
            sdsSchedule.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsSchedule.SelectCommand = qr;
            sdsSchedule.DataSourceMode = SqlDataSourceMode.DataReader;
            gvSchedule.DataSource = sdsSchedule;
            gvSchedule.DataBind();

        }

        public void FillDropLists1()
        {
            sdsUser.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsUser.DataSourceMode = SqlDataSourceMode.DataReader;

        }

        public void FillDropLists2()
        {
            sdsTypeSchedule.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsTypeSchedule.DataSourceMode = SqlDataSourceMode.DataReader;

        }

        public void FillDropLists3()
        {
            sdsStatus.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsStatus.DataSourceMode = SqlDataSourceMode.DataReader;

        }

        protected void gvSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
        }

        protected void gvSchedule_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Дата работы"):
                    e.SortExpression = "[WorkDate]";
                    break;

                case ("Фамилия"):
                    e.SortExpression = "[UserSurname]";
                    break;

                case ("Имя"):
                    e.SortExpression = "[UserName]";
                    break;

                case ("Статус"):
                    e.SortExpression = "[WorkStatus]";
                    break;
                case ("Тип графика"):
                    e.SortExpression = "[NameScheduleType]";
                    break;

            }
            sortGridView(gvSchedule, e, out sortDirection, out strField);
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

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvSchedule.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[5].Text.Equals(tbSearch.Text)
                    || row.Cells[6].Text.Equals(tbSearch.Text)
                    || row.Cells[7].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.Green;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void tbFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [UserName] + ' ' + [UserSurname] like '%" + tbSearch.Text + "%' or " + "[UserName] like '%" + tbSearch.Text + "%' or " + "[WorkStatus] like '%" + tbSearch.Text + "%' or " + "[NameScheduleType] like '%" + tbSearch.Text + "%' or " + "[WorkDate] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void tbCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);


            // почти RealTime
            gvSchedule.DataBind();
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            //string DataValue;

            bool err = false;
          
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbDate);
            textBoxes.Add(tbTimeIn);
            textBoxes.Add(tbTimeOut);




            if (!err)
            {
                SqlCommand command = new SqlCommand("", DBConnection.connection);


                int User_ID = int.Parse(lstUser.SelectedValue);
                int TypeSchedule_ID = int.Parse(lstTypeSchedule.SelectedValue);
                int Status_ID = int.Parse(lstStatus.SelectedValue);
                string tbDateValue; 
                Table_Class DateValue = new Table_Class(DBConnection.qrSchedule);
                tbDateValue = DateValue.table.Rows[0][3].ToString();
                if (tbDateValue == tbDate.Text) 
                {
                    Response.Write("<script>alert(' Такая дата уже есть ');</script>");
                }
              else { 
                try
                {
                    command.CommandText = "INSERT INTO [dbo].[Schedule] ([WorkDate],[TimeIn],[TimeOut],[User_ID],[ScheduleType_ID],[Status_ID]) values ('" + tbDate.Text + "','" + tbTimeIn.Text + "','" + tbTimeOut.Text + "','" + User_ID + "','" + TypeSchedule_ID + "','" + Status_ID + "')";
                    DBConnection.connection.Open();
                    command.ExecuteScalar();
                }
                catch
                {
                        Response.Write("<script>alert(' Такая дата уже есть ');</script>");
                    }
                finally
                {
                    DBConnection.connection.Close();
                    gvFill(QR);
                    gvSchedule.DataBind();
                }
              }
            }
        }

            protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbDate.Text == "")
            {
                case (true):
                    tbDate.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbDate.BackColor = System.Drawing.Color.White;
                    switch (tbTimeIn.Text == "")
                    {
                        case (true):
                            tbTimeIn.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbTimeIn.BackColor = System.Drawing.Color.White;
                            SqlCommand command = new SqlCommand("", DBConnection.connection);
                            command.CommandText = "update [dbo].[Schedule] set " +
                                "[WorkDate] ='" + tbDate.Text + "', " +
                                "[TimeIn] ='" + tbTimeIn.Text + "', " +
                                "[TimeOut] ='" + tbTimeOut.Text + "', " +
                                "[User_ID] ='" + lstUser.SelectedValue + "', " +
                                "[ScheduleType_ID] ='" + lstTypeSchedule.SelectedValue + "', " +
                                "[Status_ID] ='" + lstStatus.SelectedValue + "' " +
                                " where ID_Schedule = " + DBConnection.IDrecord + "";

                            DBConnection.connection.Open();
                            command.ExecuteNonQuery();
                            DBConnection.connection.Close();
                            gvFill(QR);
                            Response.Redirect(Request.RawUrl);
                            break;
                    }
                    break;
            }
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", DBConnection.connection);
            command.CommandText = "delete from [dbo].[Schedule] " +
                "where ID_Schedule = " + DBConnection.IDrecord + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            gvFill(QR);
            Response.Redirect(Request.RawUrl);
        }

        protected void tbBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void gvSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvSchedule.SelectedRow;
            tbDate.Text = row.Cells[4].Text.ToString();
            tbTimeIn.Text = row.Cells[5].Text.ToString();
            tbTimeOut.Text = row.Cells[6].Text.ToString();


            lstUser.SelectedValue = row.Cells[8].Text;
            lstTypeSchedule.SelectedValue = row.Cells[9].Text;
            lstStatus.SelectedValue = row.Cells[10].Text;
            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }



    }
}