<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Skladiste.aspx.cs" Inherits="APPEK2.Skladiste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/skladiste.css" rel="stylesheet"/>
    <title></title>
</head>
<body>
    <div class="header">
        <h1> Aplikacija za evidenciju kemikalija </h1>
    </div>

    <div class="navbar">
		<ul>
			<li class="naslovna"><a href="index.aspx"> Naslovna </a></li>
			<li id="chemicals" class="kemikalije" runat="server"><a href="Skladiste.aspx"> Skladište </a></li>
            <li id="labos" class="laboratorij" runat="server"><a href="Labos.aspx"> Laboratorij </a></li>
			<li id="register" class="registracija" runat="server"><a href="registracija.aspx"> Registracija </a></li>
            <li id="odjava" runat="server"><a href="prijava.aspx"> Odjava </a></li>
		</ul>
	</div>
        <br />

    <form id="form" runat="server">
        <div class="wrapper">
            <div class="content-wrapper">
                <div class="content">
                    <h2> - OBAVIJESTI - </h2>
                        <asp:Panel ID="Panel" runat="server">
                            <asp:Panel ID="vitrina" runat="server">
                                <asp:GridView ID="podaci" runat="server"
                                    ItemType ="APPEK2.Models.dbSkladiste"
                                    SelectMethod="podaci_GetData"
                                    OnSelectedIndexChanged ="podaci_SelectedIndexChanged"
                                    AutoGenerateSelectButton="true">

                                    <SelectedRowStyle backcolor="LightCyan"
                                        forecolor="DarkBlue"
                                        font-bold="true"/>
                                </asp:GridView>
                                    <br />
                            </asp:Panel>

                                <br />

                            <h2 style="text-align: center; color: black;"> - UNOS NOVE KEMIKALIJE - </h2>
                                <asp:Panel ID="NoviUnos" runat="server">
                                    <asp:Label ID="lblNaziv" runat="server" Text="Naziv kemikalije: "/>
                                    <asp:TextBox ID="txtNaziv" runat="server"/>
                                        <br/>
                                    <asp:Label ID="lblKolicina" runat="server" Text="Količina: "/>
                                    <asp:TextBox ID="txtKolicina" runat="server" />
                                        <br />
                                    <asp:Label ID="lblOpis" runat="server" Text="Opis kemikalije: " />
                                    <asp:TextBox ID="txtOpis" runat="server" />
                                        <br />

                                    <div class="trajanje">
                                        <asp:Label ID="lblExp" runat="server" Text="Rok trajanja: "/> <br />
                                        <asp:Calendar ID="dateExp" runat="server" OnSelectionChanged="dateExp_SelectionChanged" BorderWidth="1px"
                                        ForeColor="#663399" Font-Names="Century Gothic" Font-Size="16pt" Font-Bold="true"></asp:Calendar>
                                    </div>

                                    <div class="zaprimanje">
                                        <asp:Label ID="lblRec" runat="server" Text="Datum zaprimanja: "/> <br/>
                                        <asp:Calendar ID="dateRec" runat="server" OnSelectionChanged="dateRec_SelectionChanged" BorderWidth="1px"
                                        ForeColor="#663399" Font-Names="Century Gothic" Font-Size="16pt" Font-Bold="true"></asp:Calendar>
                                    </div>
                                    
                                    <div class="objava">
                                        <asp:Button ID="btnPohrani" Text="Spremi" runat="server" OnClick="btnPohrani_Click" />
                                        <asp:Button ID="btnModify" Text="Uredi" runat="server" OnClick="btnModify_Click" />
                                        <asp:Button ID="btnDelete" Text="Obriši" runat="server" OnClick="btnDelete_Click" />
                                        <asp:Button ID="btnOcisti" Text="Resetiraj" runat="server" OnClick="btnOcisti_Click" />
                                    </div>

                                        <br />
                                        <br />
                                        <br />
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
