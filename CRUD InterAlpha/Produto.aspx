<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="CRUD_InterAlpha.Produto" %>

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
            width: 500px;
            height: 270px;
            left: 50%;
            margin: -170px 0 0 -300px;
            padding: 20px;
            position: absolute;
            top: 50%;
        }
    </style>
    <title>Produto</title>
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
                            <asp:TextBox ID="txtProdutoId" runat="server" OnTextChanged="txtProdutoId_TextChanged" AutoPostBack="true" Width="120px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Nome</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="265px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                    <asp:Label runat="server">Descrição &nbsp;</asp:Label>
                        </td>
                        <td>
                    <asp:TextBox ID="txtDescricao" runat="server" Height="53px" Width="265px"></asp:TextBox>
                        </td>
                    </tr>
                    &nbsp;
            <tr>
                <td>
                            <asp:Label runat="server">Preço &nbsp;</asp:Label>
                </td>
                <td>
                            <asp:TextBox ID="txtPreco" runat="server" Width="116px"></asp:TextBox>
                </td>
            </tr>
                    <tr>
                        <td>Tipo &nbsp;</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoProduto" runat="server" Width="120px">
                            </asp:DropDownList>
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
