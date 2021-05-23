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
    public partial class Authorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkConnection();
        }

        public static bool checkConnection()
        {
            /// Проверяем соединение к базе
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-A2PIL339\LYSYISERVER");
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        protected void btEnter_Click(object sender, EventArgs e)
        {
            /// Получаем данные о пользователе из таблицы
            DBConnection connection = new DBConnection();
            connection.dbEnter(tbLogin.Text, tbPassword.Text);

            switch (DBConnection.IDuser)
            {
                case (0):
                    tbLogin.BackColor = System.Drawing.Color.Red;
                    tbPassword.BackColor = System.Drawing.Color.Red;

                    lblTitle.Text = "Введён не верный логин или пароль!";
                    tbPassword.Text = "";
                    tbLogin.Text = "";
                    break;
                default:
                    /// Определяем имя сессии
                    Table_Class roletable = new Table_Class(DBConnection.qrUser + string.Format("where [Login] = '{0}' and [Password] = '{1}'", tbLogin.Text, tbPassword.Text));
                    DBConnection.RolePerm_ID = roletable.table.Rows[0][6].ToString();
                    var s = DBConnection.RolePerm_ID;
                    Session["uname"] = tbLogin.Text;
                    Response.Redirect("MainMenu.aspx");
                    break;
            }
        }
    }
}