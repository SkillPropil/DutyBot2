using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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

        protected void btEnter_Click(object sender, EventArgs e)
        {
           
            
            /// Получаем данные о пользователе из таблицы
            DBConnection connection = new DBConnection();
           string password = tbPassword.Text;
            string Passwords = encryption(password);
            connection.dbEnter(tbLogin.Text, Passwords.ToString());
           


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
                   
                    System.Threading.Thread.Sleep(2000);
                    prgLoadingStatus.Visible = true;
                    /// Определяем имя сессии
                    Table_Class roletable = new Table_Class(DBConnection.qrUser + string.Format("where [Login] = '{0}' and [Password] = '{1}'", tbLogin.Text, Passwords.ToString()));
                    DBConnection.RolePerm_ID = roletable.table.Rows[0][6].ToString();

                    var s = DBConnection.RolePerm_ID;

                    Table_Class Status1 = new Table_Class(DBConnection.qrUser);
                    DBConnection.Status = Status1.table.Rows[0][5].ToString();

                    Session["uname"] = tbLogin.Text;
                    Response.Redirect("MainMenu.aspx");
                    break;
            }
            //prgLoadingStatus.Visible = false;

        }
    }
}