<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Presentación.Formularios.Alumno.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container body-container">
        <h2>Guardar ALumno</h2>
        <div class="form-horizontal">
            <div class="form-group">

                <asp:Label ID="lbNombreMuestra" runat="server" class="control-label col-sm-1" Text="Nombre: "></asp:Label>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" CssClass="alert-danger" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lbapellido" runat="server" class="control-label col-sm-1" Text="Primer Apellido: "></asp:Label>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtPrimerApellido" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrimerApellido" CssClass="alert-danger" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lbapellidop" runat="server" class="control-label col-sm-1" Text="Segundo Apellido: "></asp:Label>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtSegundoApellido" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="alert-danger" ErrorMessage="Campo requerido" ControlToValidate="txtSegundoApellido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lbFecha" runat="server" class="control-label col-sm-1" Text="Fecha de nacimiento: "></asp:Label>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtFecha" runat="server" type="date" class="form-control" Width="189px"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Date" MinimumValue="1991-01-01" MaximumValue="2021-07-01" ErrorMessage="Fecha incorrecta" ControlToValidate="txtFecha" CssClass="alert-danger"></asp:RangeValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lbCurpM" runat="server" class="control-label col-sm-1" Text="Curp: "></asp:Label>
                <div class="col-sm-2">

                    <asp:TextBox ID="txtCurp" runat="server" class="form-control"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="field-validation-valid text-danger" runat="server" ErrorMessage="Curp no valido" ControlToValidate="txtCurp" ValidationExpression="^[A-Z]{1}[AEIO]{1}[A-Z]{2}[2-9]{1}[0-9]{5}[HM]{1}[AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE]{2}[B-DF-HJ-ÑP-TV-Z]{3}[0-9]{2}$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lbCorreoM" runat="server" class="control-label col-sm-1" Text="Correo: "></asp:Label>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtCorreo" runat="server" class="form-control" TextMode="Email"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Correo invalido" ControlToValidate="txtCorreo" CssClass="alert-danger"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label class="control-label col-sm-1" ID="lbTelefonoM" runat="server" Text="Teléfono: "></asp:Label>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtTelefono" runat="server" class="form-control" placeholder="99-9999-9999"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Telfono no valido" ControlToValidate="txtTelefono" CssClass="alert-danger" ClientValidationFunction="validaTelefono"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lbEstadoM" runat="server" class="control-label col-sm-1" Text="Estado: "></asp:Label>
                <div class="col-sm-2">
                    <asp:DropDownList ID="ddlEstado" runat="server" class="form-control" Width="160px" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lbEstatus" runat="server" class="control-label col-sm-1" Text="Estatus: "></asp:Label>
                <div class="col-sm-2">
                    <asp:DropDownList ID="ddlEstatus" runat="server" class="form-control" Width="155px" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                    <br />

                </div>
            </div>
            <div class="form-group">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-default" OnClick="btnGuardar_Click" />

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
