<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Duty_Bot2.User" %>

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

    .block-center {
        
        width: 85%;
        height: 100%;
        overflow: auto;
        float:right;
    }

    
    </style>
</head>
<body>
      <form id="User" runat="server" style="background-color:white">
      <asp:SqlDataSource ID="sdsUser" runat="server"></asp:SqlDataSource>
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
        <asp:button ID ="btCancel" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Отмена" ToolTip="Отменить все изменения" OnClick="btCancel_Click"></asp:button>
      
      
             </div>
                <div class="block-center block-2"
                 <center>
                    <br>
                <asp:GridView ID ="gvAddUser" runat ="server" 
                    AllowSorting ="true" 
                    CurrentSortField =""
                    CurrentSortDirection ="ASC"
                    Width ="90%"
                   CssClass=" table table-striped table-responsive table-hover table-bordered "  style =" border-color: black; background-color: white; "
                OnRowDataBound="gvAddUser_RowDataBound" OnSorting="gvAddUser_Sorting" OnSelectedIndexChanged="gvAddUser_SelectedIndexChanged">
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
        </center>
            <br>
        <div style="overflow: unset">
            <div class="block-left block-2">
                
                

                <asp:SqlDataSource ID="sdsProle" runat="server"
                    SelectCommand="SELECT [ID_Role], RoleName FROM [dbo].[Role]"
                    ></asp:SqlDataSource>

                  <%--<asp:SqlDataSource ID="sdsPPerm" runat="server"
                    SelectCommand="SELECT [ID_RolePerm], [Perm_ID] FROM [dbo].[RolePerm]"
                    ></asp:SqlDataSource>--%>

                
             
              

                
            

                <asp:DropDownList ID="lstRole" runat="server" DataSourceID="sdsProle" DataTextField="RoleName" DataValueField="ID_Role" CssClass="mr-sm-2" Width="280px">
                </asp:DropDownList>

                <%--<asp:DropDownList ID="lstPerm" runat="server" DataSourceID="sdsPPerm" DataTextField="Perm_ID" DataValueField="Perm_ID" CssClass="mr-sm-2" Width="280px">
                </asp:DropDownList>--%>

                              
                    <br />
                 <br />
                
                
                              
                  <br />
            

                
            

                

                
                <asp:Label ID="lblQuantity" runat="server"
                    Text="Имя" CssClass="font_style"></asp:Label>

                <br />

               
                <asp:TextBox ID="tbName" CssClass="text-center textbox" runat ="server" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit" runat="server"
                    CssClass="font_style" Text="Фамилия"></asp:Label>
                <br />


                
                <asp:TextBox ID="tbSurname" runat ="server" CssClass="text-center textbox" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit1" runat="server"
                    CssClass="font_style" Text="Логин"></asp:Label>
                <br />

                <asp:TextBox ID="tbLogin" runat ="server" style="margin-left: 0px" CssClass="text-center textbox" ></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit0" runat="server"
                    CssClass="font_style" Text="Пароль"></asp:Label>
                <br />


                
                <asp:TextBox ID="tbPassword" runat ="server" style="margin-left: 0px" CssClass="text-center textbox"></asp:TextBox>
                <br />


                
                <asp:Label ID="lblUnit2" runat="server"
                    CssClass="font_style" Text="Статус"></asp:Label>
                <br />


                
                <asp:TextBox ID="tbStatus" runat ="server" style="margin-left: 0px" CssClass="text-center textbox"></asp:TextBox>
                <br />
                <br />
               
                <asp:Button ID="btDelete" runat="server" CssClass="btn btn-primary"
                    Text="Удалить" OnClick="btDelete_Click" ToolTip="Выберите данные из таблицы и нажмите на кнопку для удаления" />

                <asp:Button ID="btInsert" runat="server" CssClass=" btn btn-primary"
                    Text="Добавить"  Width="100px" OnClick="btInsert_Click" ToolTip="Нажмите на кнопку для внесения данных"/>
               
                <br />
                


                <br />
              <asp:button ID ="Button1" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Назад" Width="90px" ToolTip="Перейти в главное меню" OnClick="Button1_Click" ></asp:button>

                <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-primary"
                    Text="Изменить" Width="100px" OnClick="btUpdate_Click" ToolTip="Выберите данные из таблицы и нажмите на кнопку для изменения"/>
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
