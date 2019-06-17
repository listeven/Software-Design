<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Numeric Palindromes
    </title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div id ="whole">
        <h1 style="text-align:center; font-size: 35px" >Find Numeric Palindromes</h1>
        <div style="text-align:center; font-size:18px">
            Enter a starting integer (0-1,000,000,000):&nbsp;

            <asp:TextBox ID="startIntBox" runat="server" Width="81px"></asp:TextBox>
            &nbsp;&nbsp; Enter count (1-100):&nbsp;
            <asp:TextBox ID="countBox" runat="server" Width="47px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="generate" runat="server" Text="Generate" OnClick="generate_Click" />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Rows="10" Width="100px"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="feedback" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </div>
    </form>
</body>
</html>
