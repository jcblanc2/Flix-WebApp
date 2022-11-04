<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadingPage.aspx.cs" Inherits="devoir4.LoadingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">

        <title>Flixster</title>
        <link rel="stylesheet" href="stylesload.css"/>

        <script type="text/javascript">
            window.onload = function () {

                setTimeout(function () {
                    window.location.replace("PageFilms.aspx");
                }, 3000)

            }
        </script>
        

    </head>

    <body>
        <form id="form1" runat="server">
            <!-- about -->
            <div class="about">

               <a class="bg_links social portfolio" href="https://github.com/jcblanc2" target="_blank">
                  <span class="icon"></span>
               </a>

               <a class="bg_links social dribbble" href="#" target="_blank">
                  <span class="icon"></span>
               </a>

               <a class="bg_links social linkedin" href="https://www.linkedin.com/in/john-clayton-blanc-222518244" target="_blank">
                  <span class="icon"></span>
               </a>

               <a class="bg_links logo"></a>
            </div>

            <!-- end about -->

            <div class="content">
               <div class="loading">
                    <p id="textLoad">loading</p>
                  <span></span>
               </div>
            </div>

        </form>
    </body>
</html>
