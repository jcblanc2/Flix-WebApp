<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageFimlDetail.aspx.cs" Inherits="devoir4.DetailPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
            width: 233px;
        }
    </style>
</asp:Content>  

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

    <link rel="stylesheet" href="StyleDetail.css" />




    <div class="circleContainer">
            <asp:Image ID="imgCircle" runat="server" ValidateRequestMode="Disabled" Width="100%" ImageUrl="~/resources/circleRed.png" />                
      </div>


    <div>
        <table style="width:100%;">
            <tr>
                <td></td>

                <td class="auto-style1">
                    <div class="container1">
                        <div class="secondContainer">
                            <asp:Literal ID="ltVideo" runat="server"></asp:Literal>

                            <div class="btnContainer">
                                <asp:Button ID="btnBack" class="btn btn-outline-secondary" runat="server"  Text="Retour" OnClick="btnBack_Click" />
                            </div>
                        </div>
                    </div>
                </td>

                <td class="auto-style2">
                     <asp:Label ID="lblTitleDetail" runat="server" Text="Title" ForeColor="#2A313E"></asp:Label>
                    <hr/>
                     <asp:Label ID="lblOverViewDetail" runat="server" Text="OverView" Width="200px"></asp:Label>
                </td>
               
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
                    <asp:Label ID="lbtDateDetail" runat="server" Text="Date"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Language:"></asp:Label>
                    <asp:Label ID="lblOriginal_language" runat="server" Text="Language"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Popularity:"></asp:Label>
                    <asp:Label ID="lblPopularity" runat="server" Text="Popularity"></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Vote Count:"></asp:Label>
                    <asp:Label ID="lbl_vote_count" runat="server" Text="Vote Count"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Vote Average:"></asp:Label>
                    <asp:Label ID="lbl_vote_average" runat="server" Text="Vote Average"></asp:Label>
                </td>
            </tr>
         </table>
    </div>

   
</asp:Content> 
