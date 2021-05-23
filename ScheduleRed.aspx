<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleRed.aspx.cs" Inherits="Duty_Bot2.RolePerm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/bootstrap.css" rel="stylesheet" />
     <style type="text/css">
         .bt_Style {
         }
         .gvAddUser {}

         .navcenter {
            text-align: center;
        }
         .btnleft {
            float:left;
        }
         .textbox { 
    background: white; 
    border: 1px double #DDD; 
    border-radius: 5px; 
    box-shadow: 0 0 5px #333; 
    color: #666; 
    outline: none; 
    height:25px; 
    width: 275px; 
  } 
          .block-left {
        width: 15%;
        height: 800px;
        overflow: auto;
    }

    .block-right {
        
        width: 85%;
        height: 100%;
        overflow: auto;
        float: right;
    }
    </style>
</head>
<body>
      <form id="ScheduleRed" runat="server" style="background-color:white">

                
      <asp:SqlDataSource ID="sdsSchedule" runat="server"></asp:SqlDataSource>
              <center> 
<div>
              <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd">
                  <a class="navbar-brand" href="#">
                    <img src="logo.png" />
                      
  <a class="navbar-brand navcenter">Введите значение для поиска</a>
  
    <asp:textbox class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" ID="tbSearch" runat="server"/>
      
      <br>
   

</nav>
     <br>
<asp:button ID ="btSearch" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Поиск" OnClick="btSearch_Click" ToolTip="Введите данные в строку и нажмите на кнопку для поиска данных"></asp:button>
      <asp:button ID ="tbFilter" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Фильтр" OnClick="tbFilter_Click" ToolTip="Введите данные в строку и нажмите на кнопку для фильтрации данных"></asp:button>
        <asp:button ID ="tbCancel" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Отмена" OnClick="tbCancel_Click" ToolTip="Нажмите на кнопку для отмены изменений"></asp:button>

      
             </div>
                
       <div class="block-right block-2"
       
                <center>
                    <br>


                <asp:GridView ID ="gvSchedule" runat ="server" 
                    AllowSorting ="true" 
                    CurrentSortField =""
                    CurrentSortDirection ="ASC"
                    Width="90%"
                   CssClass=" table table-striped table-responsive table-hover table-bordered"  style =" border-color:black; background-color:white; " OnRowDataBound="gvSchedule_RowDataBound" OnSorting="gvSchedule_Sorting" OnSelectedIndexChanged="gvSchedule_SelectedIndexChanged"
                    >
                    <Columns>
                       
                     <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                     <HeaderStyle   CssClass="table table-primary" 
                    BackColor="Black" 
                    HorizontalAlign="Center" 
                    Width="33%" />
                </asp:GridView>
            </center>
            </div>
          <div style="overflow: unset">
            <div class="block-left block-2">
                
                
                 <asp:SqlDataSource ID="sdsUser" runat="server"
                    SelectCommand ="SELECT [ID_User] , [UserSurname] FROM [dbo].[User]"
                    ></asp:SqlDataSource>


                <asp:SqlDataSource ID="sdsStatus" runat="server"
                    SelectCommand="SELECT ID_Status , WorkStatus FROM WorkStatus"
                    ></asp:SqlDataSource>

                
                 <asp:SqlDataSource ID="sdsTypeSchedule" runat="server"
                    SelectCommand="SELECT ID_ScheduleType , NameScheduleType FROM ScheduleType"
                    ></asp:SqlDataSource>


             <br />
              

                
            

               <asp:DropDownList ID="lstUser" runat="server" DataSourceID="sdsUser" DataTextField="UserSurname" DataValueField="ID_User" CssClass="mr-sm-2" Width="280px">
                </asp:DropDownList>

                    <br />
                
                <br />
             
              

                
            

                <asp:DropDownList ID="lstTypeSchedule" runat="server" DataSourceID="sdsTypeSchedule" DataTextField="NameScheduleType" DataValueField="ID_ScheduleType" CssClass="mr-sm-2" Width="280px">
                </asp:DropDownList>

                    
                 <br />
                <br />
               <asp:DropDownList ID="lstStatus" runat="server" DataSourceID="sdsStatus" DataTextField="WorkStatus" DataValueField="ID_Status" CssClass="mr-sm-2" Width="280px">
                </asp:DropDownList>

                <br />
                
                              
                  <br />
            

                
            

                

                
                <asp:Label ID="lblQuantity" runat="server"
                    Text="Дата смены" CssClass="font_style"></asp:Label>

                <br />

                
                <asp:TextBox ID="tbDate" CssClass="text-center textbox" runat ="server" style="margin-left: 0px" TextMode="Date"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit" runat="server"
                    CssClass="font_style" Text="Время начала смены"></asp:Label>
                <br />


                
                <asp:TextBox ID="tbTimeIn" runat ="server" CssClass="text-center textbox" style="margin-left: 0px" TextMode="Time"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit1" runat="server"
                    CssClass="font_style" Text="Время конца смены"></asp:Label>
                <br />

                <asp:TextBox ID="tbTimeOut" runat ="server" style="margin-left: 0px" TextMode="Time" CssClass="text-center textbox"></asp:TextBox>
                <br />


                
                <br />


                
               

                
               
               
                 <asp:Button ID="btDelete" runat="server" CssClass="btn btn-primary"
                    Text="Удалить" OnClick="btDelete_Click" ToolTip="Выберите данные из таблицы и нажмите на кнопку для удаления" />

                <asp:Button ID="btInsert" runat="server" CssClass=" btn btn-primary"
                    Text="Добавить"  Width="100px" OnClick="btInsert_Click" ToolTip="Нажмите на кнопку для добавления"/>
               
                <br />
                


                <br />
              <asp:button ID ="tbBack" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Назад"  ToolTip="Перейти на главное меню" Width="100px" OnClick="tbBack_Click"></asp:button>

                <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-primary"
                    Text="Изменить" Width="100px" OnClick="btUpdate_Click" ToolTip="Выберите данные из таблицы и нажмите на кнопку для изменения" />
                <br />

                <br />

                <br />
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
