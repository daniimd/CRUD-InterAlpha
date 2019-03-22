<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdCli.aspx.cs" Inherits="CRUD_InterAlpha.ProdCli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        {
            margin: 0;
            padding: 0;
            font-family: Tahoma;
            font-size: 11pt;
        }

        #divCenter {
            background-color: #e1e1e1;
            width: 550px;
            height: 170px;
            left: 50%;
            margin: -170px 0 0 -300px;
            padding: 20px;
            position: absolute;
            top: 50%;
        }
    </style>
    <title>Produto por Cliente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divCenter">
            <div>
                <asp:DropDownList ID="ddlTipoOperacao" runat="server" OnSelectedIndexChanged="ddlTipoOperacao_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <br />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server">ID</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProdCliId" runat="server" OnTextChanged="txtProdCliId_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">ID Cliente &nbsp;</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtClienteId" runat="server" OnTextChanged="txtClienteId_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            Nome</td>
                        <td>
                            <asp:TextBox ID="txtClienteNome" runat="server" AutoPostBack="true" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">ID Produto &nbsp;</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProdutoId" runat="server" OnTextChanged="txtProdutoId_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label runat="server">Nome &nbsp;</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProdutoNome" runat="server" AutoPostBack="true" Width="200px" ></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnConfirmar" runat="server" OnClick="btnConfirmar_Click" Text="Confirmar" AutoPostBack="true" />
                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
            </div>
        </div>
    </form>
</body>
</html>
