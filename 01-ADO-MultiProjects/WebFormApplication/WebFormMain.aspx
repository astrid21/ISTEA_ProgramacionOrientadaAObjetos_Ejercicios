<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="WebFormApplication.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" style="border-collapse: collapse;">
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="LinkButtonAltaProducto" runat="server" OnClick="LinkButtonAltaProducto_Click">Limpiar</asp:LinkButton>
                    &nbsp;&nbsp; <!-- espacios en blanco -->
                    <asp:LinkButton ID="LinkButtonGuardar" runat="server" OnClick="LinkButtonGuardar_Click">Guardar</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    ID:
                </td>
                <td>
                    <asp:TextBox ID="TextBoxId" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Marca:
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMarca" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Precio:
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPrecio" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="LabelMensaje" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:LinkButton ID="LinkButtonRefrescarListado" runat="server" OnClick="LinkButtonRefrescarListado_Click">Refrescar listado</asp:LinkButton>

        <asp:GridView ID="GridViewProductos" AutoGenerateColumns="false" runat="server" OnRowCommand="GridViewProductos_RowCommand" cellpadding="5">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID"/>
                <asp:BoundField DataField="marca" HeaderText="Marca"/>
                <asp:BoundField DataField="precio" HeaderText="Precio"/>
                
                    <asp:buttonfield buttontype="Link" 
                                    commandname="Editar" 
                                    text="Editar"/>

                <asp:buttonfield buttontype="Link" 
                                    commandname="Eliminar" 
                                    text="Eliminar"/>

            </Columns> 
        </asp:GridView>
    </div>
    </form>
</body>
</html>
