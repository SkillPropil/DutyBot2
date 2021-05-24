<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Otchet.aspx.cs" Inherits="Duty_Bot2.Otchet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .navcenter {
            text-align: center;
        }
         .btnleft {
            float:left;
        }
        
    </style>
</head>
<body>
    
    <asp:SqlDataSource ID="sdsSchedule" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsScheduleExport" runat="server"
          
                    ></asp:SqlDataSource>

    
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
             <asp:button ID ="btBack" class="btn btn-outline-success my-2 my-sm-0 btnleft" type="submit" runat="server" ToolTip="Перейти в главное меню" Text="Назад" OnClick="btBack_Click" ></asp:button>
              <asp:button ID ="btSearch" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" ToolTip="Введите значение в строку поиска и нажмите на данную кнопку для поиска" Text="Поиск" OnClick="btSearch_Click"></asp:button>
      <asp:button ID ="btExport" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Экспорт" ToolTip="Введите значение в строку поиска и нажмите на данную кнопку для фильтрации" OnClick="btExport_Click"></asp:button>
        <asp:button ID ="btCancel" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Отмена" OnClick="btCancel_Click" ToolTip="Отменить все изменения"></asp:button>

      
             </div> 
               

                        
     
        </div>
                </center>
                
                    <br>
                     
                   <%-- <br>
                    <asp:Button ID ="btSearch" runat ="server" 
                        CssClass="btn-primary" Text ="Поиск"  BorderColor="#0066FF" OnClick="btSearch_Click" />
                    <asp:Button ID ="btFilter" runat ="server" 
                        CssClass ="btn-primary" Text ="Фильтр" OnClick="btFilter_Click"   />
                    <asp:Button ID ="btCancel" runat ="server" 
                        CssClass ="btn-primary" Text ="Отмена" OnClick="btCancel_Click"  />
                    <asp:ImageButton   alt="" class="auto-style1" ID="ImageButton1" runat="server" Height="30px" Width="79px" ImageUrl="~/file-excel-fill.png" OnClick="ImageButton1_Click"   />--%>
              
                
             <asp:GridView ID ="gvOtchet" runat ="server" 
                    AllowSorting ="true"
                  
                    CssClass ="table table-striped table-responsive table-hover table-bordered"  style =" border-color:black; background-color:white; "
                    CurrentSortField =""
                    CurrentSortDirection ="ASC" 
                    ForeColor="Black" 
                    BackColor="White" 
                    BorderStyle="Dashed" 
                 Width ="95%"
                    HorizontalAlign="Center" OnSorting="gvOtchet_Sorting">
                    <Columns>
                        <asp:CommandField ShowSelectButton ="false" />
                    </Columns>
                <HeaderStyle  CssClass="table table-primary" 
                    BackColor="Black" 
                    HorizontalAlign="Center" 
                    Width="20%" />

                </asp:GridView>

               
               
        </div>
      
    </form>
</body>
</html>
