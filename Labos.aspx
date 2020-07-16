<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Labos.aspx.cs" Inherits="APPEK2.Labos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/labos.css" rel="stylesheet"/>
    <title> Laboratorij </title>
</head>
<body>
    <div class="header">
        <h1> Aplikacija za evidenciju kemikalija </h1>
    </div>

    <div class="navbar">
		<ul>
			<li class="naslovna"><a href="index.aspx"> Naslovna </a></li>
            <li id="labos" class="laboratorij" runat="server"><a href="Labos.aspx"> Laboratorij </a></li>
		</ul>
	</div>
        <br />

    <form id="form" runat="server">
        <div class="wrapper">
            <div class="content-wrapper">
                <div class="content">
                    <h2> - KEMIKALIJE - </h2>
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:Panel ID="stalak" runat="server" CssClass="dashboard">
                                <asp:GridView ID="podaci" runat="server"
                                    ItemType ="APPEK2.Models.Laboratorij"
                                    SelectMethod="podaci_GetData"
                                    OnSelectedIndexChanged ="podaci_SelectedIndexChanged"
                                    AutoGenerateSelectButton="true">

                                    <SelectedRowStyle backcolor="LightCyan"
                                    forecolor="DarkBlue"
                                    font-bold="true"/>

                                    <HeaderStyle Height="2%" />
                                    <RowStyle Height="2%" />
                                </asp:GridView>
                            </asp:Panel>
                                <br />

                            <asp:Panel ID="Unos" runat="server">
                                <div class="objava">
                                    <asp:TextBox ID="txtKom" runat="server"/>
                                    <asp:Button ID="btnDodaj" runat="server" Text="+" OnClick="btnDodaj_Click"/>
                                    <asp:Button ID="btnUzmi" runat="server" Text="-" OnClick="btnUzmi_Click"/>
                                        <br />
                                    <asp:Button ID="btnDonesi" runat="server" Text="Ulaz u skladište" OnClick="btnDonesi_Click" />
                                    <asp:Button ID="btnSakrij" runat="server" Text="Izlaz iz skladišta" OnClick="btnSakrij_Click" />
                                        <br />
                                        <br />
                                        <br />
                                </div>
                             </asp:Panel>
                            
                            <asp:panel ID="skladistePano" runat="server" Visible="false">
                                <asp:GridView ID="chemSkladiste" runat="server"
                                    ItemType ="APPEK2.Models.dbSkladiste"
                                    SelectMethod="chemSkladiste_GetData"
                                    OnSelectedIndexChanged ="chemSkladiste_SelectedIndexChanged"
                                    AutoGenerateSelectButton="true">

                                    <SelectedRowStyle backcolor="LightCyan"
                                        forecolor="DarkBlue"
                                        font-bold="true"/>

                                    <HeaderStyle Height="2%" />
                                    <RowStyle Height="2%" />
                                </asp:GridView>
                                    <br />

            	                <asp:Label ID="kolicine" runat="server" Text="Koliko komada želite prenijeti iz skladišta: "></asp:Label>
                                <asp:TextBox ID="txtPrenesi" runat="server"/>
                                <asp:Button ID="btnPrenesi" runat="server" Text="Prenesi" OnClick="btnPrenesi_Click" />
				                    <br />
                                    <br />
                                    <br />
                            </asp:panel>
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
