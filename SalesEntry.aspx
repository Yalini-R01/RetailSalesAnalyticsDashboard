<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesEntry.aspx.cs" Inherits="RetailSalesAnalyticsDashboard.SalesEntry" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Sales Entry</title>
</head>
<body>
<form id="form1" runat="server">

<h2 style="font-style: inherit; text-transform: capitalize; top: auto">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Retail Store Sales Management System</h2>
    <p>
        <asp:Image ID="Image1" runat="server" ImageUrl="https://i.pinimg.com/originals/ce/56/99/ce5699233cbc0f142250b520d967dff7.png" Width="200px" />
    </p>

Product:
<asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>
<br /><br />

Category:
<asp:DropDownList ID="ddlCategory" runat="server">
    <asp:ListItem>Electronics</asp:ListItem>
    <asp:ListItem>Grocery</asp:ListItem>
    <asp:ListItem>Stationery</asp:ListItem>
</asp:DropDownList>
<br /><br />

Unit:
<asp:DropDownList ID="ddlUnit" runat="server">
    <asp:ListItem>Piece</asp:ListItem>
    <asp:ListItem>Kg</asp:ListItem>
    <asp:ListItem>Box</asp:ListItem>
</asp:DropDownList>
<br /><br />

Quantity:
<asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
<br /><br />

Price:
<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
<br /><br />

Discount %:
<asp:TextBox ID="txtDiscount" runat="server" Text="0"></asp:TextBox>
<br /><br />

Payment:
<asp:RadioButtonList ID="rblPayment" runat="server">
    <asp:ListItem>Cash</asp:ListItem>
    <asp:ListItem>UPI</asp:ListItem>
    <asp:ListItem>Card</asp:ListItem>
</asp:RadioButtonList>

<br />

Date:
<asp:Calendar ID="calDate" runat="server"></asp:Calendar>

<br /><br />

<asp:Button ID="btnAddSale" runat="server" Text="Add Sale"
    OnClick="btnAddSale_Click" />

<asp:Button ID="btnClear" runat="server" Text="Clear"
    OnClick="btnClear_Click" />

<br /><br />

<asp:GridView ID="gvSales" runat="server"></asp:GridView>

<body style="background-color: lightblue;">
</form>
</body>
</html>