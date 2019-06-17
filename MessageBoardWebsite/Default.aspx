<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="border-style: solid; border-width: thin; margin: auto;" class="auto-style1">
    
        <div style="background-color: #808080; position: absolute; right: 0; top: 0px; left: 0px; height: 30px;">
            <asp:Panel ID="Panel1" runat="server" style="position: absolute; width: 150px; left: 550px; height: 25px; text-align: center; padding-top: 5px;">
            <a href="Login.aspx">Login</a>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href="Register.aspx">Register</a>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" style="position: absolute; width: 300px; left: 400px; height: 25px; text-align: right; padding-top: 5px; top: 0px;">
                Hello
                <asp:Label ID="hello" runat="server" Text="user"></asp:Label>
                &nbsp; &nbsp;
                <asp:LinkButton ID="logout" runat="server" OnClick="logout_Click">Logout</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </asp:Panel>
        </div>
       <div style="position: absolute; top: 30px; padding: 30px; width: 700px">
        <h1 style="text-align: center">Main Page</h1>
             <table style="border-collapse: separate; overflow: auto;">
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <tr>
                            <td style="border-width: thin; width: 100px; border-bottom:solid 1px black;">
                                <%# Eval("UserName")%> <br />
                                <%# Eval("DateTime")%>
                            </td>
                            
                            <td style="border-width: thin; width: 400px;border-bottom:solid 1px black;">
                                <%# Eval("Comment")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                           
            </table>
            <asp:Button ID="postButton" runat="server" Text="Go to Posting Page" OnClick="postClick" /> <br />
           <asp:Label ID="msg" runat="server" Text=""></asp:Label>
 </div>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Posts]"></asp:SqlDataSource>
    </form>
</body>
</html>
