<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Presentación.Formularios.Alumno.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container body-container">
        <h2>Actualizar ALumno</h2>

        <asp:Label ID="lbId" runat="server" class="control-label" Text="Id: "></asp:Label>

        <asp:TextBox ID="txtId" runat="server" class="form-control" Enabled="false"></asp:TextBox>

        <br />
        <br />

        <asp:Label ID="lbNombreMuestra" runat="server" class="control-label" Text="Nombre: "></asp:Label>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" CssClass="alert-danger" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>

        <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
        <asp:Label ID="lbapellido" runat="server" class="control-label" Text="Primer Apellido: "></asp:Label>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrimerApellido" CssClass="alert-danger" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>

        <asp:TextBox ID="txtPrimerApellido" runat="server" class="form-control"></asp:TextBox>

        <asp:Label ID="lbapellidop" runat="server" class="control-label" Text="Segundo Apellido: "></asp:Label>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSegundoApellido" CssClass="alert-danger" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>

        <asp:TextBox ID="txtSegundoApellido" runat="server" class="form-control"></asp:TextBox>

        <asp:Label ID="lbFecha" runat="server" class="control-label" Text="Fecha de nacimiento: "></asp:Label>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFecha" CssClass="alert-danger" MinimumValue="1991-01-01" MaximumValue="2021-07-01" ErrorMessage="Fecha incorrecta"></asp:RequiredFieldValidator>

        <asp:TextBox ID="txtFecha" runat="server" type="date" class="form-control" Width="189px"></asp:TextBox>





        <asp:Label ID="lbCurpM" runat="server" class="control-label" Text="Curp: "></asp:Label>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="field-validation-valid text-danger" runat="server" ErrorMessage="Curp no valido" ControlToValidate="txtCurp" ValidationExpression="^[A-Z]{1}[AEIO]{1}[A-Z]{2}[2-9]{1}[0-9]{5}[HM]{1}[AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE]{2}[B-DF-HJ-ÑP-TV-Z]{3}[0-9]{2}$"></asp:RegularExpressionValidator>

        <asp:TextBox ID="txtCurp" runat="server" class="form-control"></asp:TextBox>
        <asp:Label ID="lbCorreoM" runat="server" class="control-label" Text="Correo: "></asp:Label>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCorreo" CssClass="alert-danger" ErrorMessage="Correo invalido"></asp:RequiredFieldValidator>

        <asp:TextBox ID="txtCorreo" runat="server" class="form-control" TextMode="Email"></asp:TextBox>

        <asp:Label ID="lbTelefonoM" runat="server" class="control-label" Text="Teléfono: "></asp:Label>

        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Telfono no valido" ControlToValidate="txtTelefono" CssClass="alert-danger" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>

        <asp:TextBox ID="txtTelefono" runat="server" class="form-control" placeholder="99-9999-9999"></asp:TextBox>
        <asp:Label ID="lbEstadoM" runat="server" class="control-label" Text="Estado: "></asp:Label>

        <asp:DropDownList ID="ddlEstado" runat="server" class="form-control" Width="160px" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="lbEstatus" runat="server" class="control-label" Text="Estatus: "></asp:Label>

        <asp:DropDownList ID="ddlEstatus" runat="server" class="form-control" Width="155px" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
        </asp:DropDownList>
        <br />


        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-3">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn btn-default" OnClick="btnActualizar_Click" />
                &nbsp;
                        <asp:Button ID="btnRegresar" runat="server" Text="Regresar a la Lista" class="btn btn-default" OnClick="btnRegresar_Click" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validaTelefono(source, arguments) {

            var num = arguments.Value;
            var n = parseInt(num.length);

            if (n == 10) {
                arguments.IsValid = true;
            }
            else {
                arguments.IsValid = false;
            }

        }
    </script>

</asp:Content>
