<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="tx_json_sample.index" %>

<%@ Register assembly="TXDocumentServer.Web.DocumentViewer, Version=32.0.300.500, Culture=neutral, PublicKeyToken=6b83fe9a75cfb638" namespace="TXTextControl.DocumentServer.Web" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TX Text Control: Merge from JSON data</title>
    <script src="Scripts/jquery-3.6.0.js"></script>
    <link href="DocumentViewer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Height="332px" TextMode="MultiLine" Width="619px"></asp:TextBox><br />

        <asp:Button ID="Button1" runat="server" Text="Merge" OnClick="Button1_Click" /><br />
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False" Font-Names="Arial" ForeColor="Red" /><br />
        <cc1:DocumentViewer runat="server" ID="DocumentViewer1" Height="332px" Width="624px" />

        <script>

            // display text JSON data in TextBox on every page load
            var sJsonData = { 'orders':{ 'order':[ { 'Id':'10', 'address':{ 'street':'9774 Kings Drive', 'city':'Charlotte' }, 'phone':'123 898 2298', 'date':'05/12/2015', 'total':'1526.88', 'item':[ { 'name':'Thin-Jam Hex Nut 4', 'price':'337.22', 'qty':'1', 'itemtotal':'337.22' }, { 'name':'ML Road Frame - Red, 58', 'price':'594.83', 'qty':'2', 'itemtotal':'1189.66' } ] } ] } };
            $("#TextBox1").text(JSON.stringify(sJsonData, null, 4));

        </script>
    </div>
        
    </form>
</body>
</html>
