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
    public partial class Schedule : System.Web.UI.Page
    {
        private string QR = "";
        private string QR1 = "";
        // при загрузке страницы заполняется таблица
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["uname"] == null)
            {
                Response.Redirect("Authorization.aspx");
            }
            else
            {



                QR = DBConnection.qrSchedule;
                QR1 = DBConnection.qrScheduleExport;
                if (!IsPostBack)
                {
                    gvFill(QR);
                    gvFill1(QR1);

                }
            }
        }
        // функция заполнения таблицы
        private void gvFill(string qr)
        {
            sdsSchedule.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsSchedule.SelectCommand = qr;
            sdsSchedule.DataSourceMode = SqlDataSourceMode.DataReader;
            gvSchedule.DataSource = sdsSchedule;
            gvSchedule.DataBind();
        }

        private void gvFill1(string qr)
        {
            sdsScheduleExport.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsScheduleExport.SelectCommand = qr;
            sdsScheduleExport.DataSourceMode = SqlDataSourceMode.DataReader;
            gvScheduleExport.DataSource = sdsScheduleExport;
            gvScheduleExport.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
        // экспорт данных
       

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
                    ||row.Cells[7].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.Green;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [UserName] + ' ' + [UserSurname] like '%" + tbSearch.Text + "%' or " + "[UserName] like '%" + tbSearch.Text + "%' or " + "[WorkStatus] like '%" + tbSearch.Text + "%' or " + "[WorkDate] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);


            // почти RealTime
            gvSchedule.DataBind();
        }

        protected void btExport_Click(object sender, EventArgs e)
        {
            // выбираем таблицу и источник данных
            GridView gv = new GridView();
            GridView gridView = gvScheduleExport;
            DBConnection.connection.Open();
            gv.DataSource = sdsScheduleExport;
            DBConnection.connection.Close();
            gvFill1(QR1);





            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            gvSchedule.AllowPaging = false;
            Response.AddHeader("content-disposition", "attachment; filename=" +"Дежурства " + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();





        }

        protected void btScheduleSform_Click(object sender, EventArgs e)
        {
            int[] userlist = new int[4] { 1, 2, 3, 4 };
            int i = 0;
            DateTime DateIn = calendar1.SelectedDate;
            DateTime DateOut = calendar2.SelectedDate;
            DateTime apDate = DateIn;
            string Time = "10:00";
            int ScheduleType = 2;
            int Status = 2;
            SqlCommand command = new SqlCommand("", DBConnection.connection);
            while (apDate <= DateOut)
            {
                command.CommandText = "INSERT INTO [dbo].[Schedule] ([WorkDate],[TimeIn],[TimeOut],[User_ID],[ScheduleType_ID],[Status_ID]) values ('" + apDate.ToShortDateString() + "','" + Time + "','" + Time + "','" + userlist[i] + "','" + ScheduleType + "','" + Status + "')";
                try
                {
                    DBConnection.connection.Open();
                    command.ExecuteScalar();
                }
                catch
                {
                    Response.Write("<script>alert(' На данные даты график уже сформирован. Воспользуйтесь поиском ');</script>");
                }
                finally
                {
                    DBConnection.connection.Close();
                }
                apDate = apDate.AddDays(1);
                i++;
                if (i == 4)
                {
                    i = 0;
                }
                string tbDateValue;
                Table_Class DateValue = new Table_Class(DBConnection.qrSchedule);
                tbDateValue = DateValue.table.Rows[0][3].ToString();
                if (tbDateValue == apDate.ToShortDateString())
                {
                    Response.Write("<script>alert(' Такая дата уже есть ');</script>");
                }


            }
            gvFill(QR);
            calendar1.Visible = false;
            calendar2.Visible = false;
            lblDateIn.Visible = false;
            lblDateOut.Visible = false;
            btScheduleSform.Visible = false;
            gvSchedule.DataBind();
        }

        protected void btRaspr_Click(object sender, EventArgs e)
        {
            lblDateIn.Visible = true;
            lblDateOut.Visible = true;
            calendar1.Visible = true;
            calendar2.Visible = true;
            btScheduleSform.Visible = true;
        }
    }

}