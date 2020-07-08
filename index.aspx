<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="APPEK2.index" EnableEventValidation="False"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/index.css" rel="stylesheet"/>
    <title> Naslovna </title>
</head>
<body>
    <div class="header">
        <h1> Aplikacija za evidenciju kemikalija </h1>
    </div>

    <div class="navbar">
		<ul>
			<li class="naslovna"><a href="index.aspx"> Naslovna </a></li>
			<li class="kemikalije"><a href="#01"> Skladište </a></li>
			<li id="register" class="registracija" runat="server"><a href="registracija.aspx"> Registracija </a></li>
			<li class="odjava"><a href="#02"> Odjava </a></li>
		</ul>
	</div>
        <br />

    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="content-wrapper">
                <div class="content">
                    <h2> - OBAVIJESTI - </h2>
                    <asp:Panel ID="Panel2" runat="server">
                        <asp:Panel ID="pano" runat="server" CssClass="dashboard">
                            <asp:GridView ID="podaci" runat="server"
                            ItemType ="APPEK2.Models.Dashboard"
                            SelectMethod="podaci_GetData"
                            OnSelectedIndexChanged ="podaci_SelectedIndexChanged"
                            AutoGenerateSelectButton="true">

                            <SelectedRowStyle backcolor="LightCyan"
                            forecolor="DarkBlue"
                            font-bold="true"/>
                            </asp:GridView> 
                        </asp:Panel>
                            <br />
                            <br />
                        <asp:Panel ID="Unos" runat="server">
                            <div class="objava">
                                <asp:TextBox ID="txtObavijest" runat="server"/>
                                <asp:Button ID="btnObavijest" runat="server" Text="Objavi" OnClick="btnObavijest_Click"/>
                                <asp:Button ID="btnObrisi" runat="server" Text="Obriši" OnClick="btnObrisi_Click"/>
                                <asp:Button ID="btnUredi" runat="server" Text="Uredi" OnClick="btnUredi_Click"/>   
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </div>   
            </div>
        </div>   
    </form>

    <div class="footer">
        Copyright &copy; Valentina Bognolo <br />
        Izrada objektno orijentiranih aplikacija, ak. god. 2019./2020.
    </div>
</body>
</html>
