<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PostGetMVC.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Product.aspx?id=1" runat="server">Карандаш</asp:HyperLink><br />
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Product.aspx?id=2" runat="server">Книга</asp:HyperLink><br />
            <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Product.aspx?id=3" runat="server">Телефон</asp:HyperLink><br />
            <asp:HyperLink ID="HyperLink4" NavigateUrl="~/Product.aspx?id=4" runat="server">Машин</asp:HyperLink>
        </div>
        
    </form>
</body>
</html>
