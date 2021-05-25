using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Duty_Bot2
{
    public partial class User : System.Web.UI.Page
    {
        private string QR = "";
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
                QR = DBConnection.qrUser;
                if (!IsPostBack)
                {
                    gvFill(QR);
                    //FillDropLists1();
                    FillDropLists2();


                }

            }
        }

        private void gvFill(string qr)
        {
            sdsUser.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsUser.SelectCommand = qr;
            sdsUser.DataSourceMode = SqlDataSourceMode.DataReader;
            gvAddUser.DataSource = sdsUser;
            gvAddUser.DataBind();

        }
        // заполнение выпадающего списка

        //public void FillDropLists1()
        //{
        //    sdsPPerm.ConnectionString = DBConnection.connection.ConnectionString.ToString();
        //    sdsPPerm.DataSourceMode = SqlDataSourceMode.DataReader;


        //}

        public void FillDropLists2()
        {
            sdsProle.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsProle.DataSourceMode = SqlDataSourceMode.DataReader;
          
        }


        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
        protected void btInsert_Click(object sender, EventArgs e)
        {
            bool err = false;

            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tbName);
            textBoxes.Add(tbSurname);
            textBoxes.Add(tbLogin);
            textBoxes.Add(tbPassword);
            textBoxes.Add(tbStatus);
            string password = tbPassword.Text;
            string Passwords = encryption(password);

            if (!err)
            {
                SqlCommand command = new SqlCommand("", DBConnection.connection);


                
                int Role_ID = int.Parse(lstRole.SelectedValue);
                //int Role_ID = int.Parse(lstPerm.SelectedValue);

                command.CommandText = "INSERT INTO [dbo].[User] ([UserName],[UserSurname],[Login],[Password],[UserStatus],[Role_ID]) values ('" + tbName.Text + "','" + tbSurname.Text + "','" + tbLogin.Text + "','" + Passwords.ToString() + "','" + tbStatus.Text + "','" + Role_ID + "')";



                DBConnection.connection.Open();
                command.ExecuteNonQuery();
                DBConnection.connection.Close();
                Response.Redirect(Request.RawUrl);
                gvFill(QR);

            }
        }

        protected void gvAddUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[8].Visible = false;
        }

        protected void gvAddUser_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Имя"):
                    e.SortExpression = "[UserName]";
                    break;
                case ("Фамилия"):
                    e.SortExpression = "[UserSurname]";
                    break;

                case ("Логин"):
                    e.SortExpression = "[Login]";
                    break;
                case ("Статус"):
                    e.SortExpression = "[UserStatus]";
                    break;
            }
            sortGridView(gvAddUser, e, out sortDirection, out strField);
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

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbName.Text == "")
            {
                case (true):
                    tbName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbName.BackColor = System.Drawing.Color.White;
                    switch (tbSurname.Text == "")
                    {
                        case (true):
                            tbSurname.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbSurname.BackColor = System.Drawing.Color.White;
                            SqlCommand command = new SqlCommand("", DBConnection.connection);
                            command.CommandText = "update [dbo].[User] set " +
                                "[UserName] ='" + tbName.Text + "', " +
                                "[UserSurname] ='" + tbSurname.Text + "', " +
                                "[Login] ='" + tbLogin.Text + "', " +
                                "[Password] ='" + tbPassword.Text + "', " +
                                "[UserStatus] ='" + tbStatus.Text + "', " +
                                "[Role_ID] ='" + lstRole.SelectedValue + "' " +
                                " where ID_User = " + DBConnection.IDrecord + "";

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
            command.CommandText = "delete from [dbo].[User] " +
                "where ID_User = " + DBConnection.IDrecord + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            gvFill(QR);
            Response.Redirect(Request.RawUrl);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void gvAddUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAddUser.SelectedRow;
            tbName.Text = row.Cells[2].Text.ToString();
            tbSurname.Text = row.Cells[3].Text.ToString();
            tbLogin.Text = row.Cells[4].Text.ToString();
            tbPassword.Text = row.Cells[5].Text.ToString();
            tbStatus.Text = row.Cells[6].Text.ToString();

           lstRole.SelectedValue = row.Cells[8].Text;
            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAddUser.Rows)
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

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [UserSurname] like '%" + tbSearch.Text + "%' or " + "[UserName] like '%" + tbSearch.Text + "%' or " + "[UserStatus] like '%" + tbSearch.Text + "%' or " + "[Login] like '%" + tbSearch.Text + "%' or "  + "[RoleName] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);


            // почти RealTime
            gvAddUser.DataBind();
        }
    }
}
