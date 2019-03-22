<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="CRUD_InterAlpha.Cliente" %>

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
    <title>Cliente</title>
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
                            <asp:TextBox ID="txtClienteId" runat="server" OnTextChanged="txtClienteId_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Nome</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="270px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">CPF</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCPF" runat="server" Width="118px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Sexo</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSexo" runat="server" Width="121px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Telefone &nbsp;</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefone" runat="server" Width="118px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Endereço</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndereco" runat="server" Width="270px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Bairro &nbsp;</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBairro" runat="server" Width="270px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">Email</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="270px"></asp:TextBox>
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
