<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageFilms.aspx.cs" Inherits="devoir4.PageFilms" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>  


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
     <link rel="stylesheet" href="StylePageFilm.css" />

      <div class="circleContainer">
            <asp:Image ID="imgCircle" runat="server" ValidateRequestMode="Disabled" Width="100%" ImageUrl="~/resources/circleRed.png" />                
      </div>
     
     <div class="Maincontainer">
         <div class="secondContainer">
              <a href="PageFimlDetail.aspx">
                    <asp:Image ID="img" runat="server" ValidateRequestMode="Disabled" Width="100%" />
              </a>


              <div class="containerTitle">
                    <asp:Label ID="lblTitle2" runat="server" Text="Title"></asp:Label>
              </div>
        </div>
     </div>

     <div class="btnContainer">
           <asp:Button ID="btnPrecedent"  class="btn btn-outline-secondary" runat="server"  Text="Precedent" OnClick="btnPrecedent_Click" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnSuivant" class="btn btn-outline-secondary" runat="server"   Text="Suivant" OnClick="btnSuivant_Click" Width="93px" />
     </div>

 
</asp:Content> 



