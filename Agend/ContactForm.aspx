<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="Agend.ContactForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #f1f1f1">
        <div id="DivContact" runat="server">



            <table width="100%" id="TableFilter" title="Crea un nuevo Contacto" runat="server">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Nombre: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSecondName" runat="server" Text="Apellido: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecondName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Gen: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGen" runat="server" TextMode ="SingleLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCountry" runat="server" Text="Pais: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="cIntern" runat="server" Text="Contacto Interno: "></asp:Label>

                    </td>
                    <td>
                        <script type="text/javascript">
                            function EnableDisableTextBox(chkCintern) {
                                var txtArea = document.getElementById("txtArea");
                                var txtOrg = document.getElementById("txtOrg");
                                txtOrg.disabled = chkCintern.checked ? true : false;
                                txtArea.disabled = chkCintern.checked ? false : true;
                                if (!txtArea.disabled) {
                                    txtArea.focus();
                                }
                                if (!txtOrg.disable) {
                                    txtOrg.focus();
                                }
                            }

                        </script>
                        <asp:CheckBox  runat="server" ID="chkCintern" onclick="EnableDisableTextBox(this)" />
                    </td>
                </tr>
                <tr>

                    <td>

                        <asp:Label ID="lblOrganizacion" runat="server" Text="Organizacion: "></asp:Label>

                    </td>




                    <td>
                        <asp:TextBox ID="txtOrg" runat="server" disable="disable"></asp:TextBox>

                    </td>

                </tr>

                <tr>
                    <td>

                        <asp:Label ID="Label2" runat="server" Text="Area:  "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txtArea" runat="server" disable=" disable "></asp:TextBox>


                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Localidad" runat="server" Text="Localidad: "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Email" runat="server" Text="Email: "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Phone" runat="server" Text="Telefono: "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Cel" runat="server" Text="Cel: "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txtCel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="skype" runat="server" Text="Skype: "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txtSkype" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="active1" runat="server" Text="Activo: "></asp:Label>

                    </td>
                    <td>

                        <asp:CheckBox ID="ActiveCheck" runat="server" />

                    </td>
                </tr>
            </table>
        </div>

        <div>
            <asp:Button ID="insertContact" runat="server" Text="Guardar" OnClick="SaveContact" Width="250px" Height="30px" Font-Size="Larger" BackColor="Green" ForeColor="WhiteSmoke" />

        </div>
        
     

    </form>
</body>
</html>

