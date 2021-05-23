<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleType.aspx.cs" Inherits="Duty_Bot2.ScheduleType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>

    </title>
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

    .block-center {
        
        width: 85%;
        height: 100%;
        overflow: auto;
        float:right;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">

              

    <asp:SqlDataSource ID="sdsScheduleType" runat="server"></asp:SqlDataSource>
        <center>
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
             
              <asp:button ID ="btSearch" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Поиск" ToolTip="Введите данные в строку и нажмите на кнопку для поиска данных" OnClick="btSearch_Click"></asp:button>
      <asp:button ID ="btFilter" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Фильтр" ToolTip="Введите данные в строку и нажмите на кнопку для фильтрации данных" OnClick="btFilter_Click"></asp:button>
        <asp:button ID ="btCancel" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Отмена" OnClick="btCancel_Click" ToolTip="Отмена всех изменений"></asp:button>

      
             </div>

            </center>
            <div class="block-center block-2"
                 <center>
                    <br>
                <asp:GridView ID ="gvScheduleType" runat ="server" 
                    AllowSorting ="true" 
                    CurrentSortField =""
                    CurrentSortDirection ="ASC"
                    Width ="90%"
                   CssClass=" table table-striped table-responsive table-hover table-bordered "  style =" border-color: black; background-color: white; " OnSelectedIndexChanged="gvScheduleType_SelectedIndexChanged" OnSorting="gvScheduleType_Sorting" OnRowDataBound="gvScheduleType_RowDataBound"
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

              

                <br />
          <br />
         

        <asp:Label ID="Label1" runat="server"
                    Text="Наименование доступа" CssClass="font_style"></asp:Label>

          <br />

                
                <asp:TextBox ID="tbScheduleType" runat ="server" CssClass="text-center textbox" style="margin-left: 0px"></asp:TextBox>

          <br />
              


                <br /

                
                <br />

                
                <asp:Button ID="btDelete" runat="server" CssClass="btn btn-primary"
                    Text="Удалить" OnClick="btDelete_Click" Width="100px" ToolTip="Выберите данные из таблицы и нажмите на кнопку для удаления" />

                <asp:Button ID="btInsert" runat="server" CssClass=" btn btn-primary"
                    Text="Добавить"  Width="100px" OnClick="btInsert_Click" ToolTip="Нажмите на кнопку для внесения данных" />
               
                <br />
                


                <br />
              <asp:button ID ="btBack" class="btn btn-outline-success my-2 my-sm-0" type="submit" ToolTip="Перейти на главное меню" runat="server" Text="Назад" Width="100px" OnClick="Button1_Click"  ></asp:button>

                <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-primary"
                    Text="Изменить" Width="100px" ToolTip="Выберите данные из таблицы и нажмите на кнопку для изменения" OnClick="btUpdate_Click"  />
                <br />

                <br />

                <br />
                <br />
                <br />
            </div>


    </form>
</body>
</html>
