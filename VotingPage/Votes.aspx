<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Votes.aspx.cs" Inherits="Votes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Voting Page</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="voteWhole">
        <h1>Thanks For Voting!</h1>
        <div id ="table">
            <asp:Table ID="Table1" runat="server" CssClass="collapse" CellPadding="0" CellSpacing="0"></asp:Table>
        </div>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Candidate], [Vote Count] AS Vote_Count FROM [Candidates]"></asp:SqlDataSource>
    </form>
</body>
</html>
