<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentación.Formularios.Alumno.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-outline-primary" OnClick="btnAgregar_Click" />
    <br />
    <br />
    <asp:GridView ID="gvAlumnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table" GridLines="Horizontal" OnPageIndexChanging="gvAlumnos_PageIndexChanging" OnRowCommand="gvAlumnos_RowCommand" PageSize="5" Width="1029px">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="primerApellido" HeaderText="Apellido Paterno" />
            <asp:BoundField DataField="segundoApellido" HeaderText="Apellido Materno" />
            <asp:BoundField DataField="correo" HeaderText="Correo" />
            <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha de nacimiento" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="curp" HeaderText="Curp" />
            <asp:BoundField DataField="estado" HeaderText="Estado" />
            <asp:BoundField DataField="estatus" HeaderText="Estatus" />
            <asp:ButtonField CommandName="Detalle" Text="Detalle">
                <ControlStyle CssClass="btn btn-sm btn-warning" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Editar" Text="Edtitar">
                <ControlStyle CssClass="btn btn-sm btn-success" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Eliminar" Text="Eliminar">
                <ControlStyle CssClass="btn btn-sm btn-danger" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
