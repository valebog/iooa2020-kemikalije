<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prijava.aspx.cs" Inherits="APPEK2.prijava" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/prijava.css" rel="stylesheet"/>
    <title> Prijava </title>
    <link href="glowform.css" rel="stylesheet"/>
</head>
<body>
    <h1> Aplikacija za evidenciju kemikalija </h1>
    <form id="form1" runat="server" class="prijava">
        <h2> - Prijava korisnika - </h2>
            <br />
        <asp:TextBox ID="txtKorIme" runat="server" CssClass="txtBoxUser" placeholder="korisničko ime"></asp:TextBox>
        <asp:Label ID="lblKorisnik" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
        <asp:TextBox ID="txtLozinka" TextMode="Password" runat="server" CausesValidation="True" placeholder="lozinka" CssClass="txtBoxPass"></asp:TextBox>
        <asp:Label ID="lblLozinka" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
        <asp:Button ID="btnPrijava" runat="server" Text="Prijava" OnClick="Btn" />
    </form>
        <br />

    <div class="footer">
        Copyright &copy; Valentina Bognolo <br />
        Izrada objektno orijentiranih aplikacija, ak. god. 2019./2020.
    </div>
</body>
</html>
