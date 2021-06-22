<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListContact.aspx.cs" Inherits="Agend.ListContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #f1f1f1">




        <div runat="server">

            <asp:Label ID="Titulo" runat="server" Text="Filtro" CssClass="Titulo"></asp:Label>

            <table width="100%" id="TableFilter" runat="server">
                <tr>
                    <td>
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecondName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCountry" runat="server" Text="Pais: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
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
                        <asp:CheckBox runat="server" ID="chkCintern" onclick="EnableDisableTextBox(this)" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOrganizacion" runat="server" Text="Organizacion: "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txtOrg" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Area:  "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
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
                        <asp:Label ID="active1" runat="server" Text="Activo: "></asp:Label>

                    </td>
                    <td>

                        <asp:CheckBox ID="ActiveCheck" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="DateTimeLabel" runat="server" Text="Fecha De Ingreso: "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="DateTimeText" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>

                            <asp:Button ID="filterContact" runat="server" Text="Buscar" OnClick="SearchContact" Width="250px" Height="30px" Font-Size="Larger" BackColor="Green" ForeColor="WhiteSmoke" />
                        </div>

                    </td>
                    <td>
                        <asp:Button ID="insertContact" runat="server" Text="Guardar un Nuevo Contacto" OnClick="ContactInsert" Width="250px" Height="30px" Font-Size="Larger" BackColor="Green" ForeColor="WhiteSmoke" />
                    </td>
                </tr>
            </table>


        </div>
        <p>

            <asp:ImageButton ID="cleanFilter" ImageUrl="Img/fil.png" OnClick="CleanFilter" runat="server" AlternateText="Limpiar Filtro" />

        </p>



        <div id="DivContact" runat="server">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowEditing="EditContact" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="DelectContact" DataKeyNames="id" Height="455px" Width="1508px">
                <Columns>

                    <asp:BoundField DataField="firstName" HeaderText="Nombre" SortExpression="firstName" />
                    <asp:BoundField DataField="secondName" HeaderText="Apellido" SortExpression="secondName" />
                    <asp:BoundField DataField="gen" HeaderText="Genero" SortExpression="gen" />
                    <asp:BoundField DataField="country" HeaderText="Pais" SortExpression="country" />
                    <asp:BoundField DataField="city" HeaderText="Ciudad" SortExpression="city" />
                    <asp:CheckBoxField DataField="intern" HeaderText="Contacto Interno" SortExpression="cIntern" />
                    <asp:BoundField DataField="org" HeaderText="Organizacion" SortExpression="org" />
                    <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" />
                    <asp:BoundField DataField="dateAdmission" HeaderText="Fecha de admision" SortExpression="dateAdmission" />
                    <asp:CheckBoxField DataField="active" HeaderText="activo" SortExpression="active" />
                    <asp:BoundField DataField="direction" HeaderText="Direccion" SortExpression="direction" />
                    <asp:BoundField DataField="phone" HeaderText="Telefono" SortExpression="phone" />
                    <asp:BoundField DataField="cel" HeaderText="Celular" SortExpression="cel" />
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                    <asp:BoundField DataField="skype" HeaderText="Skype" SortExpression="skype" />
                    <asp:ButtonField ButtonType="Button" Visible="false" CommandName="Edit" HeaderText="Editar" ShowHeader="False" Text="Edit" />
                    <asp:ButtonField ButtonType="Button" Visible="false" CommandName="Delete" HeaderText="Borrar" ShowHeader="False" Text="Borrar" />
                </Columns>
            </asp:GridView>

            <div>
            </div>
        </div>
    </form>
</body>
</html>
