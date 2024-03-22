<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="asp.net_CRUD_operation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1">
                <tr>
                    <th colspan="2">CRUD</th>
                </tr>
                <tr>
                    <th>Id:</th>
                    <td>
                        <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Name:</th>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Email:</th>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Phone:</th>
                    <td>
                        <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Address</th>
                    <td>
                        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                        <asp:Button ID="txtupdate" runat="server" Text="Update" OnClick="txtupdate_Click" />
                        <asp:Button ID="txtdelete" runat="server" Text="Delete" OnClick="txtdelete_Click" />
                        <asp:Button ID="txtselect" runat="server" Text="Select" OnClick="txtselect_Click" />

                    </th>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
