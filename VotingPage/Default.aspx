<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Voting System</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id ="whole">
        <h1 style="text-align:center; font-size: 40px">Online Voting System</h1>
        <div style="font-size:20px">
            Please place your vote:
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Candidate" DataValueField="Id"></asp:RadioButtonList>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Candidate], [Vote Count] AS Vote_Count FROM [Candidates]" UpdateCommand="UPDATE Candidates SET [Vote Count] = [Vote Count] + 1 WHERE (Id = @id)">
                <UpdateParameters>
                    <asp:ControlParameter ControlID="RadioButtonList1" Name="id" PropertyName="SelectedValue" />
                </UpdateParameters>
            </asp:SqlDataSource>

            <br />
            <asp:Button ID="Button1" runat="server" Text="Vote" OnClick="Button1_Click" />

            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        </div>
    
    </div>
    </form>
</body>
</html>
