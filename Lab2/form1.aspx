<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form1.aspx.cs" Inherits="Lab2.form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>U17</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Rodyti duomenis" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Keliautojų failas:"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Būtina nurodyti keliautojus" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Viešbučių failas:"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Būtina nurodyti viešbučius" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server">Keliautojų sarašas:</asp:Label>
        <asp:Table ID="Table1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Viesbučių sarašas:"></asp:Label>
        <asp:Table ID="Table2" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Keliautojų pasirinktų viešbučių sarašas:"></asp:Label>
        <asp:Table ID="Table3" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Nepasirinktų viešbučių sarašas:"></asp:Label>
        <asp:Table ID="Table4" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Keliautojai su daugiausia naktų:"></asp:Label>
        <asp:Table ID="Table5" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <br />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Iveskite, pinigų sumą:"></asp:Label>
        &nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Iveskite skaičių" Text="*" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Keliautojai su kurie sumokejo daugiau:"></asp:Label>
        <asp:Table ID="Table6" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
    </form>
</body>
</html>
