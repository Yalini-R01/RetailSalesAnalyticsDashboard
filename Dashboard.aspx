<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Retail Sales Dashboard</title>
</head>
<body>
<form id="form1" runat="server">

<h2>Retail Sales Dashboard</h2>

<!-- FILTER -->
<asp:DropDownList ID="ddlFilter" runat="server">
    <asp:ListItem Value="All">All</asp:ListItem>
    <asp:ListItem Value="Today">Today</asp:ListItem>
    <asp:ListItem Value="Month">This Month</asp:ListItem>
</asp:DropDownList>

<asp:Button ID="btnFilter" runat="server" Text="Apply Filter" OnClick="btnFilter_Click" />

<br /><br />

<!-- EXPORT -->
<asp:Button ID="btnExcel" runat="server" Text="Export Excel" OnClick="btnExcel_Click" />

<br /><br />

<!-- SUMMARY -->
<asp:Label ID="lblRevenue" runat="server" ForeColor="Green"></asp:Label>
<br />
<asp:Label ID="lblBest" runat="server"></asp:Label>

<br /><br />

<!-- GRIDVIEW -->
<asp:GridView ID="gvDashboard" runat="server" AutoGenerateColumns="False">

    <Columns>

        <asp:BoundField DataField="Product" HeaderText="Product" />
        <asp:BoundField DataField="Category" HeaderText="Category" />

        <asp:BoundField DataField="Date"
            HeaderText="Date"
            DataFormatString="{0:dd-MM-yyyy}" />

        <asp:BoundField DataField="Total" HeaderText="Total" />

    </Columns>

</asp:GridView>

<br /><br />

<!-- CHART 1 -->
<asp:Chart ID="Chart1" runat="server">
    <Series>
        <asp:Series Name="Sales" ChartType="Column"></asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
    </ChartAreas>
</asp:Chart>

<br /><br />

<!-- CHART 2 -->
<asp:Chart ID="Chart2" runat="server">
    <Series>
        <asp:Series Name="CategorySales" ChartType="Pie"></asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
    </ChartAreas>
</asp:Chart>

</form>
</body>
</html>