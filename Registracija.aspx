<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="APPEK2.REGISTRACIJA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/registracija.css" rel="stylesheet"/>
    <title> Registracija </title>
</head>

<body>
    <div class="wrapper">
        <div class="inner">
            <form id="form1" runat="server">
                <h2> - Registracija korisnika - </h2>
                        <br />
                    <div class="form-wrapper">
                        <asp:Label ID="label1" runat="server" Text="Korisničko ime" CssClass="label"></asp:Label>
                        <asp:TextBox ID="txtKorIme" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblkorisnik" runat="server" ForeColor="#CC0000"></asp:Label>
                    </div>
                        <br />
                    <div class="form-wrapper">
                        <asp:Label ID="lbl" runat="server" Text="Lozinka" CssClass="label"/>
                        <asp:TextBox ID="txtLozinka" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                        <br />
                    <div class="form-wrapper">
                        <asp:Label ID="Label2" runat="server" Text="Potvrda lozinke" CssClass="label"/>
                        <asp:TextBox ID="txtponovi" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblneisloz" runat="server" ForeColor="#CC0000"></asp:Label>
                    </div>
                        <br />
                    <div class="form-wrapper">
                        <asp:Label ID="Label3" runat="server" Text="Ime" CssClass="label"/>
                        <asp:TextBox ID="txtIme" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                        <br />
                    <div class="form-wrapper">
                        <asp:Label ID="Label4" runat="server" Text="Prezime" CssClass="label"/>
                        <asp:TextBox ID="txtPrezime" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                        <br />
                    <div class="form-wrapper1">
                        <asp:Button ID="btnPrijava" runat="server" Text="Potvrdi" OnClick="btnPrijava_Click" />
                        <asp:Button ID="btnOcisti" runat="server" Text="Obriši" OnClick="btnOcisti_Click" />
                    </div>
            </form>
        </div>
    </div>
    
    <div class="footer">
        Copyright &copy; Valentina Bognolo <br />
        Izrada objektno orijentiranih aplikacija, ak. god. 2019./2020.
    </div>
</body>
</html>
