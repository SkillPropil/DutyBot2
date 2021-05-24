<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="Duty_Bot2.Role" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>

    </title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        function CheckValidInput()
        {
            var textLength = $("#tbRoleName").val().length;

            if (textLength > 20) {
                alert("Проверьте корректность вводимой информации");
                return false;
            }

            if (textLength<1) {
                alert("Проверьте корректность вводимой информации");
                return false;
            }
            return true;
        };
    </script>
   
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
             
              <asp:button ID ="Button2" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" ToolTip="Введите значение в строку поиска и нажмите на данную кнопку для поиска" Text="Поиск" OnClick="btSearch_Click"></asp:button>
      <asp:button ID ="Button3" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Фильтр" ToolTip="Введите значение в строку поиска и нажмите на данную кнопку для фильтрации" OnClick="btFilter_Click"></asp:button>
        <asp:button ID ="Button4" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Отмена" OnClick="btCancel_Click" ToolTip="Отменить все изменения"></asp:button>

      
             </div>       
                 <div class="block-center block-2"
                 <center>
                    <br>
                <asp:GridView ID ="gvRole" runat ="server" 
                    AllowSorting ="true" 
                    CurrentSortField =""
                    CurrentSortDirection ="ASC"
                    Width ="90%"
                   CssClass=" table table-striped table-responsive table-hover table-bordered "  style =" border-color: black; background-color: white; " OnRowDataBound="gvRole_RowDataBound" OnSelectedIndexChanged="gvRole_SelectedIndexChanged" OnSorting="gvRole_Sorting" 
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


              

                <br />

    
        <center>
        </center>
         <div style="overflow: unset">
            <div class="block-left block-2">
                <asp:SqlDataSource ID="sdsRole" runat="server"></asp:SqlDataSource>
              

                <br />
          <br />
         

          <br />

                
          <br />
              


        <asp:Label ID="Label2" runat="server"
                    Text="Наименование роли" CssClass="font_style"></asp:Label>

          <br />

                
                <asp:TextBox ID="tbRoleName" runat ="server" style="margin-left: 0px" CssClass="text-center textbox"></asp:TextBox>

                <br />

                
                <br />

                
                 <asp:Button ID="btDelete" runat="server" CssClass="btn btn-primary"
                    Text="Удалить" OnClick="btDelete_Click" Width="100px" ToolTip="Выберите данные из таблицы и нажмите на кнопку для удаления" />

                <asp:Button ID="btInsert" runat="server" CssClass=" btn btn-primary"
                  OnClientClick="return CheckValidInput()"  Text="Добавить"  Width="100px" OnClick="btInsert_Click" ToolTip="Выберите данные из таблицы и нажмите на кнопку для добавления" />
               
                <br />
                


                <br />
              <asp:button ID ="btBack" class="btn btn-outline-success my-2 my-sm-0" type="submit" ToolTip="Перейти в главное меню" runat="server" Text="Назад" Width="100px" OnClick="Button1_Click"  ></asp:button>

                <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-primary"
                    Text="Изменить" Width="100px" OnClientClick="return CheckValidInput()" OnClick="btUpdate_Click" ToolTip="Выберите данные из таблицы и нажмите на кнопку для изменения" />
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
