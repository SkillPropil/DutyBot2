<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Duty_Bot2.Schedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .inline {display:inline;}
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

    <form id="form1" runat="server" aria-orientation="horizontal" aria-sort="none">
       
  
       
        
        <div class="container-fluid">
        <div class="table" style="border:1px #0094ff;box-shadow: 0px 2px 5px #808080">
           
                   
               <%-- <asp:Label ID ="lblTitle" runat ="server" Text= "Формирование графика" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>--%>
            <center> 
         <div>
              <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd">
                  <a class="navbar-brand" href="#">
                    <img src="logo.png" />
                      
  <a class="navbar-brand navcenter">Введите значение для поиска</a>
  <form class="form-inline">
    <asp:textbox class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" ID="tbSearch" runat="server"/>
      
      
   
  </form>
</nav>
             <br>
             <asp:button ID ="btBack" class="btn btn-outline-success my-2 my-sm-0 btnleft" type="submit" runat="server" ToolTip="Перейти в главное меню" Text="Назад" OnClick="btBack_Click" ></asp:button>
              <asp:button ID ="btSearch" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" ToolTip="Введите значение в строку поиска и нажмите на данную кнопку для поиска" Text="Поиск" OnClick="btSearch_Click"></asp:button>
      <asp:button ID ="btFilter" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" ToolTip="Введите значение в строку поиска и нажмите на кнопку для фильтрации данных" Text="Фильтр" OnClick="btFilter_Click"></asp:button>
        <asp:button ID ="btCancel" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Отмена" ToolTip="Отменить все изменения" OnClick="btCancel_Click"></asp:button>
      <asp:button ID ="btExport" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Экспорт" ToolTip="Выгрузка данных из таблицы в Excel" OnClick="btExport_Click"></asp:button>
             <asp:button ID ="btRaspr" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Сформировать" ToolTip="Автоматическое формирование графика" OnClick="btRaspr_Click"  ></asp:button>
      
             </div>
                <center>
                   
                        <div id="divCalendars" runat="server">
                        <asp:Label Text="Дата, с которой формируется график" ID="lblDateIn" runat="server" Visible="false" style="position:relative;right:400px;margin-top:-10px;"/>
                        <asp:Calendar style="position: relative; right:400px;" id="calendar1"  runat="server" BackColor="White" BorderColor="Black" Visible="false" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" Width="330px"  ToolTip="Выберите дату">

                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />

           <OtherMonthDayStyle ForeColor="#999999">
           </OtherMonthDayStyle>

           <TitleStyle BackColor="#333399"
                       ForeColor="White" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" Height="12pt">
           </TitleStyle>

                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />

           <DayStyle BackColor="#CCCCCC">
           </DayStyle>

           <SelectedDayStyle BackColor="#333399" ForeColor="White">
           </SelectedDayStyle>

                            <TodayDayStyle BackColor="#999999" ForeColor="White" />

      </asp:Calendar>
                        <br />
                        <asp:Label Text="Дата по которую формируется график" ID="lblDateOut" runat="server" Visible="false" style="position:absolute; top: 145px; left: 1354px; height: 31px; width: 380px;"/>
                        <asp:Calendar style="position: relative; left:400px;margin-top:-270px;" id="calendar2" runat="server" BackColor="White" BorderColor="Black" float="right" ToolTip="Выберите дату" Visible="false" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px"  Width="330px" >
                            
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                            
           <OtherMonthDayStyle ForeColor="#999999">
           </OtherMonthDayStyle>

           <TitleStyle BackColor="#333399"
                       ForeColor="White" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" Height="12pt">
           </TitleStyle>

                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />

           <DayStyle BackColor="#CCCCCC">
           </DayStyle>

           <SelectedDayStyle BackColor="#333399" ForeColor="White">
           </SelectedDayStyle>

                            <TodayDayStyle BackColor="#999999" ForeColor="White" />

      </asp:Calendar>
                        <asp:button ID ="btScheduleSform" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Сформировать" OnClick="btScheduleSform_Click" Visible="false"  ></asp:button>
     
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
              
                
             <asp:GridView ID ="gvSchedule" runat ="server" 
                    AllowSorting ="true"
                  
                    CssClass ="table table-striped table-responsive table-hover table-bordered"  style =" border-color:black; background-color:white; "
                    CurrentSortField =""
                    CurrentSortDirection ="ASC" 
                    ForeColor="Black" 
                    BackColor="White" 
                    BorderStyle="Dashed" 
                 Width ="95%"
                    HorizontalAlign="Center" OnRowDataBound="gvSchedule_RowDataBound" OnSorting="gvSchedule_Sorting">
                    <Columns>
                        <asp:CommandField ShowSelectButton ="false" />
                    </Columns>
                <HeaderStyle  CssClass="table table-primary" 
                    BackColor="Black" 
                    HorizontalAlign="Center" 
                    Width="20%" />

                </asp:GridView>

                 <asp:GridView ID ="gvScheduleExport" runat ="server" 
                    AllowSorting ="true"
                  Visible="false"
                    CssClass ="table table-striped table-responsive table-hover table-bordered"  style =" border-color:black; background-color:white; "
                    CurrentSortField =""
                    CurrentSortDirection ="ASC" 
                    ForeColor="Black" 
                    BackColor="White" 
                    BorderStyle="Dashed" 
                 Width ="5%"
                    HorizontalAlign="Center" >
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
