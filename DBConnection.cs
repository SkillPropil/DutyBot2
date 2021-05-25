using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace Duty_Bot2
{
    public class DBConnection
    {
        /// Строка подключения к БД
        public static string connectionString = @"Data Source=LAPTOP-A2PIL339\LYSYISERVER; Initial Catalog=Duty_ASP;Integrated Security=True;" +
            @"Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            @"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection connection = new SqlConnection(connectionString);
        public DataTable dtRole = new DataTable("Role");
        public DataTable dtSchedule = new DataTable("Schedule");
        public DataTable dtScheduleType = new DataTable("ScheduleType");
        public DataTable dtUser = new DataTable("User");
        public DataTable dtWorkStatus = new DataTable("WorkStatus");
        //public DataTable dtRolePerm = new DataTable("RolePerm");
        /// Заполнение данных из БД в переменную
        public static string qrRole = "SELECT " +
         "[ID_Role], " +
         "[RoleName] as \"Наименование роли\" " +
         "FROM [dbo].[Role] ",

       qrSchedule = "SELECT " +
        "[ID_Schedule], " +
        "[UserName] + ' ' + [UserSurname] as \"Дежурный\" , " +
        "[WorkStatus] as \"Статус смены\", " +
        "[WorkDate] as \"Дата смены\", " +
        "[TimeIn] as \"Дата начала\", " +
        "[TimeOut] as \"Дата ухода\", " +
        "[NameScheduleType] as \"Тип графика\", " +
        "[User_ID], " +
        "[ScheduleType_ID], " +
        "[Status_ID] " +
        "FROM [dbo].[Schedule]  " +
        "INNER JOIN [dbo].[User] ON [ID_User] = [User_ID] " +
        "INNER JOIN [dbo].[ScheduleType] ON [ID_ScheduleType] = [ScheduleType_ID] " +
        "INNER JOIN [dbo].[WorkStatus] ON [ID_Status] = [Status_ID] ",

       qrScheduleType = "SELECT " +
        "[ID_ScheduleType], " +
        "[NameScheduleType] as \"Тип графика\" " +
        "FROM [dbo].[ScheduleType]  ",


       //     qrRolePerm = "SELECT " +
       //"[ID_RolePerm], " +
       //"[RoleName] + ' | ' + [PermName] as Rol_Perm  FROM [dbo].[RolePerm] " +

       //"INNER JOIN [dbo].[Role] ON [ID_Role] = [Role_ID] " +
       //"INNER JOIN [dbo].[Permission] ON [ID_Perm] = [Perm_ID] ",

       qrUser = "SELECT " +
         "[ID_User], " +
         "[UserName] as \"Имя\", " +
         "[UserSurname] as \"Фамилия\", " +
         "[Login] as \"Логин\", " +
         "[Password] as \"Пароль\", " +
         "[UserStatus] as \"Статус пользователя\", " +
         "[RoleName] as \"Наименование роли\", " +
         "[Role_ID] " +
         "FROM [dbo].[User] " +
         "INNER JOIN [dbo].[Role] ON [ID_Role] = [Role_ID] ",

       qrWorkStatus = "SELECT" +
        "[ID_Status], " +
        "[WorkStatus] as \"Статус смены\" " +
        "FROM [dbo].[WorkStatus]",

        qrScheduleExport = "SELECT " +
        "[UserName] + ' ' + [UserSurname] as \"Дежурный\" , " +
        "[WorkStatus] as \"Статус смены\", " +
        "[WorkDate] as \"Дата смены\", " +
        "[TimeIn] as \"Дата начала\", " +
        "[TimeOut] as \"Дата ухода\", " +
        "[NameScheduleType] as \"Тип графика\" " +
        "FROM [dbo].[Schedule]  " +
        "INNER JOIN [dbo].[User] ON [ID_User] = [User_ID] " +
        "INNER JOIN [dbo].[ScheduleType] ON [ID_ScheduleType] = [ScheduleType_ID] " +
        "INNER JOIN [dbo].[WorkStatus] ON [ID_Status] = [Status_ID] ",


        qrOtchet = "SELECT " +
        "[UserName] + ' ' + [UserSurname] as \"Дежурный\" , " +
        "[WorkStatus] as \"Статус смены\", " +
        "[WorkDate] as \"Дата смены\", " +
        "[TimeIn] as \"Дата начала\", " +
        "[TimeOut] as \"Дата ухода\", " +
        "[NameScheduleType] as \"Тип графика\" " +
        "FROM [dbo].[Schedule]  " +
        "INNER JOIN [dbo].[User] ON [ID_User] = [User_ID] " +
        "INNER JOIN [dbo].[ScheduleType] ON [ID_ScheduleType] = [ScheduleType_ID] " +
        "INNER JOIN [dbo].[WorkStatus] ON [ID_Status] = [Status_ID] " +
        "Where [Status_ID] = 1";

        private SqlCommand command = new SqlCommand("", connection);
        public static Int32 IDrecord, IDuser;
        public static string RolePerm_ID;
        public static int ScheduleType=3;
        public static string Status;

        public void dbEnter(string login, string password)
        {
            
           
            /// Берем из базы данные пользователей для дальнейшей авторизации
            command.CommandText = "SELECT count(*) FROM [dbo].[User]" +
                "where [Login] = '" + login + "' and [Password] = '" +
                password + "'";
            
            connection.Open();
            IDuser = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }
        
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

       

      
        

    }
}