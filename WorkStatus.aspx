<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkStatus.aspx.cs" Inherits="Duty_Bot2.WorkStatus" %>

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

              

    <asp:SqlDataSource ID="sdsWorkStatus" runat="server"></asp:SqlDataSource>
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
             
              <asp:button ID ="btSearch" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Поиск" ToolTip="Отменить все изменения" OnClick="btSearch_Click"></asp:button>
      <asp:button ID ="btFilter" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Фильтр" ToolTip="Введите данные в строку и нажмите на кнопку для фильтрации данных" OnClick="btFilter_Click"></asp:button>
        <asp:button ID ="btCancel" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Отмена" OnClick="btCancel_Click" ToolTip="Отменить все изменения"></asp:button>

      
             </div>
        </center>

        <div class="block-center block-2"
                 <center>
                    <br>
                <asp:GridView ID ="gvWorkStatus" runat ="server" 
                    AllowSorting ="true" 
                    CurrentSortField =""
                    CurrentSortDirection ="ASC"
                    Width ="90%"
                   CssClass=" table table-striped table-responsive table-hover table-bordered "  style =" border-color: black; background-color: white; " OnRowDataBound="gvWorkStatus_RowDataBound" OnSelectedIndexChanged="gvWorkStatus_SelectedIndexChanged" OnSorting="gvWorkStatus_Sorting"  
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
                    Text="Редактирование статусов" CssClass="font_style"></asp:Label>

          <br />

                
                <asp:TextBox ID="tbWorkStatus" runat ="server" style="margin-left: 0px" CssClass="text-center textbox"></asp:TextBox>

          <br />
              


               

                
                <br />

                
                 <asp:Button ID="btDelete" runat="server" CssClass="btn btn-primary"
                    Text="Удалить" Width="100px" OnClick="btDelete_Click" ToolTip="Выберите данные из таблицы и нажмите на кнопку для удаления" />

                <asp:Button ID="btInsert" runat="server" CssClass=" btn btn-primary"
                    Text="Добавить"  Width="100px" OnClick="btInsert_Click" ToolTip="Нажмите кнопку для внесения данных"/>
               
                <br />
                


                <br />
              <asp:button ID ="btBack" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Назад" Width="100px" OnClick="btBack_Click" ToolTip="Перейти на главное меню"   ></asp:button>

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
