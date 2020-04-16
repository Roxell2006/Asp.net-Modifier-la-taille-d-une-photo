<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Photo_Resize.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Photo Resize</title>
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
        <div>
            <asp:FileUpload ID="upFile" accept=".jpg, .jpeg, .png, .gif" runat="server" /><br />
            <p>Largeur: <asp:TextBox ID="Width"  Text="640" runat="server"></asp:TextBox></p>
            <p>Hauteur: <asp:TextBox ID="Height" Text="480" runat="server"></asp:TextBox></p><br />
            <asp:Button style="width: 150px; height:30px; margin-left: 25px;" ID="btnAdd" Text="ReSize" OnClick="btnAdd_Click" runat="server" />
        </div>
    </form>
</body>
</html>
