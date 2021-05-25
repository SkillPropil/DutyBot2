<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Version.aspx.cs" Inherits="Duty_Bot2.Version" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="css/bootstrap.css" rel="stylesheet" />
         <script src="Scripts/jquery-3.4.1.slim.min.js"></script>
         <link href="css/bootstrap.css" rel="stylesheet" />
<style type="text/css">
              .div {
            background:  	#ded8d8; /* Цвет фона */
            color: #000000; /* Цвет текста */
            /* Чёрная рамка */
            padding: 15px; /* Поля вокруг текста */
            border-radius: 10px;
            width: 80%;
            height: 90%;
        }

     </style>
</head>
<body>
    <form id="form1" runat="server">

       
         <div>
              <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd">
                  <a class="navbar-brand" href="#">
                    <img src="logo.png" />

                       <div class="collapse navbar-collapse justify-content-end" id="navbarSupportedConten1t">
                    <ul class="navbar-nav">
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link p-2" ID="LinkButton7" runat="server"></asp:LinkButton>
                            
                        </li>
                        </ul>
      
 
   </div>
                      </nav>
                     </div> 
   
                   

               
        <asp:button ID ="btBack" class="btn btn-outline-success my-2 my-sm-0 btnleft" type="submit" runat="server" ToolTip="Перейти в главное меню" Text="Назад" OnClick="btBack_Click"></asp:button>
             </div>
        <center>
        <div class="jumbotron div">
            <center>
                 <h2><%: Title %>Версионность программного продукта DutyBot</h2>
            </center>
            <p>Программный продукт "DutyBot" предназначен для облегчения работы дежурным системным администраторам и сотрудникам отдела кадров. 
</p>
            <p>При помощи данного программного
    продукта присутствует возможность составлять график работы дежурных системных администраторов и экспортировать его в MS Excel.</p>
            <center>
            <h3>DutyBot v.1</h3>
                </center>
            <p>Дата релиза: 05.12.2021</p>
            <p>
                Функционал:
               
            </p>
                <p> &#10004; Работа со справочными и операционными таблицами базы данных</p>
                <p> &#10004; Авторизация</p>
                <p> &#10004; Добавление учетных записей</p>
                <p> &#10004; Экспорт данных из операционной таблицы в MS Excel(работало некорректно)</p>
                <p> &#10004; Составление графика дежурств вручную</p>
            <center>
        <h3>DutyBot v.1.5(test)</h3>
                </center>
            <p>Дата релиза: 17.05.2021</p>
            <p>
                Изменения:
               
            </p>
                <p> &#10004; Поправлен экспорт данных из таблицы в MS Excel</p>
                <p> &#10004; Полностью переделан интерфейс</p>
                <p> &#10004; Произведена адаптация UI и UX</p>
                <p> &#10004; Добавлена функция автоматического формирования смен</p>
            <center>
            <h3>DutyBot v.2(prod)</h3>
                </center>
            <p>Дата релиза: 25.05.2021</p>
            <p>
                Изменения:
               
            </p>
                <p> &#10004; Добавлено шифрование конфиденциальных данных пользователя </p>
                <p> &#10004; Добавлена система подсказок на элементы управления</p>
                <p> &#10004; Добавлена проверка подключения к источнику данных </p>
                <p> &#10004; В базу данных внесены необходимые для корректной работы триггеры</p>
                <p> &#10004; Добавлен элемент отображения состояния</p>
        </div>
       </center>
      
         
       
        </footer>
    </form>
     <div id="footer2" class=" footer container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 text-center">
                        <p> © 2021 Учаев Никита. По всем вопросам обращаться по адресу uchaev-nv@nko-rr.ru. ASP.NET </p>
                    </div>
                </div>
            </div>
</body>
    <footer>
</html>
