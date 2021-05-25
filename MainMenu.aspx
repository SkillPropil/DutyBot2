<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Duty_Bot2.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title></title>
         <link href="css/bootstrap.css" rel="stylesheet" />
         <script src="Scripts/jquery-3.4.1.slim.min.js"></script>
         <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .bt_Style {}
        .navright {
            float: right;
        }
         .btleft {
            text-align: left;
            float:left;
        }
        .div {
            background:  	#ded8d8; /* Цвет фона */
            color: #000000; /* Цвет текста */
            /* Чёрная рамка */
            padding: 15px; /* Поля вокруг текста */
            border-radius: 10px;
            width: 70%;
            height: 400px;
        }

        .footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  /* Set the fixed height of the footer here */
  height: 60px;
  background-color: #f5f5f5;
}

    </style>
</head>
<body>
    
  <form id="form1" runat="server" >
  
      <div>

            <nav class="navbar navbar-expand-lg navbar-light " style="background-color:#e3f2fd">
                <a class="navbar-brand" href="#">
                    <img src="logo.png" />
                </a>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">

                    
                    </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav">
                        <li class="nav-item active" id="navSchedule">
                            <asp:LinkButton class="nav-link" ID="LinkSchedule" href="Schedule.aspx" runat="server">График</asp:LinkButton>
                        </li>
                        <li class="nav-item active" id="navOtchet">
                            <asp:LinkButton class="nav-link" ID="LinkOtchet" href="Otchet.aspx" runat="server">Отчет</asp:LinkButton>
                        </li>
                        <li class="nav-item active" id="navUser">
                              <asp:LinkButton class="nav-link" ID="LinkUser" href="User.aspx" runat="server" >Добавление учетных записей</asp:LinkButton>
                        </li>
                        <li class="nav-item active" id="navScheduleRed">
                            <asp:LinkButton class="nav-link" ID="LinkScheduleRed" href="ScheduleRed.aspx" runat="server">Редактирование смен</asp:LinkButton>
                        </li>
                      
                        
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link" ID="LinkRole" href="Role.aspx" runat="server">Роли</asp:LinkButton>
                        </li>
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link" ID="LinkScheduleType" href="ScheduleType.aspx" runat="server">Тип графика</asp:LinkButton>
                        </li>
                         <li class="nav-item active">
                            <asp:LinkButton class="nav-link" ID="LinkWorkStatus" href="WorkStatus.aspx" runat="server">Статус смен</asp:LinkButton>
                        </li>
                        

                    </ul>
                    <div class="collapse navbar-collapse justify-content-end" id="navbarSupportedConten1t">
                    <ul class="navbar-nav">
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link p-2" ID="LinkButton7" runat="server"></asp:LinkButton>
                            
                        </li>
                       <li class="nav-item active" id="navVersion">
                            <asp:LinkButton class="nav-link" ID="LinkButton1" href="Version.aspx" runat="server">Версионность</asp:LinkButton>
                        </li>
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link p-2" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Выйти</asp:LinkButton>
                        </li>
                       
                        
                         
                    </ul>
                        </div>
                </div>
            </nav>
      
     </div>
      <br>
      <br>
      <br>
      <center>
      <div class="jumbotron div">
          
        <h1>Добро пожаловать!</h1>
            
         
          <br>
          <br>
          <br>
          
        <p class="lead btleft">Данный модуль предназначен для работы с расписанием дежурных администраторов.</p>
             <br>
             <br>
          <br>
           <br>
          
          <asp:Button ID ="btInsert" runat ="server" 
                        CssClass ="btn btn-primary btn-lg btleft" Text ="Узнать больше" OnClick="btInsert_Click" />
         

          <br>
          <br>

          
          <br>
          <br>
          <br>
          <br>
          <br>
    </div>
          </center>
      
         <div id="footer2" class=" footer container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 text-center">
                        <p> © 2021 Учаев Никита. По всем вопросам обращаться по адресу uchaev-nv@nko-rr.ru. ASP.NET </p>
                    </div>
                </div>
            </div>

        </footer>
        <!-- ./Footer -->
     </form>
    
</body>
     <!-- Footer -->
        <footer>
           
                
           
</html>
