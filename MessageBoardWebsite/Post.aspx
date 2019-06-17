<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Posting Page</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="whole">
        <h1 style ="text-align:center; font-size:40px">Posting Page</h1>
    
        <p>
            <asp:TextBox ID="commentBox" runat="server" Height="175px" Width="421px" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Post" OnClick="Button1_Click" />
        </p>
        <p>
            <asp:Label ID="msg" runat="server" Text=""></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Posts]"></asp:SqlDataSource>
        </p>
    </div>
    </form>
</body>
</html>
