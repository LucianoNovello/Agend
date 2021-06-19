<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Agend.InsertContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server" style="background-color: #f1f1f1" >
        <div id="DivContact" runat="server">

            <asp:Label ID="Contact" runat="server" Text="Contact" CssClass="Titulo"></asp:Label>
            
            <table width="100%" id ="TablaSerializar" runat ="server">
                <tr> 
                    <td> 
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre: " CssClass="TextoConsulta"></asp:Label>
                    </td>
                    <td > 
                        <asp:TextBox ID="txtNombre" TextMode="Date" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                </tr> 
                <tr> 
                    <td> 
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido: " CssClass="TextoConsulta"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                </tr>
                <tr> 
                    <td> 
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: " CssClass="TextoConsulta"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                </tr>
                
                <tr> 
                     <td>
                        <asp:Button ID="insertContact" runat="server" Text="Guardar" OnClick="saveContact" Width="250px" Height="30px" Font-Size="Larger" BackColor="Green" ForeColor="WhiteSmoke" />
                    </td>
                    <td>
                        <asp:Button ID="editContact" runat="server" Text="Guardar" OnClick="editContact" Width="250px" Height="30px" Font-Size="Larger" BackColor="Green" ForeColor="WhiteSmoke" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
