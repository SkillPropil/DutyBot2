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
    public partial class Otchet : System.Web.UI.Page
    {
        private string QR = "";
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



                QR = DBConnection.qrOtchet;
                if (!IsPostBack)
                {
                    gvFill(QR);

                }
            }
        }

        private void gvFill(string qr)
        {
            sdsSchedule.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsSchedule.SelectCommand = qr;
            sdsSchedule.DataSourceMode = SqlDataSourceMode.DataReader;
            gvOtchet.DataSource = sdsSchedule;
            gvOtchet.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void gvOtchet_Sorting(object sender, GridViewSortEventArgs e)
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
            sortGridView(gvOtchet, e, out sortDirection, out strField);
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
            foreach (GridViewRow row in gvOtchet.Rows)
            {
                if (row.Cells[1].Text.Equals(tbSearch.Text)
                    || row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[5].Text.Equals(tbSearch.Text)
                    || row.Cells[6].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.Green;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);


            // почти RealTime
            gvOtchet.DataBind();
        }

        protected void btExport_Click(object sender, EventArgs e)
        {
            // выбираем таблицу и источник данных
            GridView gv = new GridView();
            GridView gridView = gvOtchet;
            DBConnection.connection.Open();
            gv.DataSource = sdsSchedule;
            DBConnection.connection.Close();
            gvFill(QR);





            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            gvOtchet.AllowPaging = false;
            Response.AddHeader("content-disposition", "attachment; filename=" + "Отчет о сменах " + DateTime.Now.ToShortDateString() + ".xls");
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
    }

}