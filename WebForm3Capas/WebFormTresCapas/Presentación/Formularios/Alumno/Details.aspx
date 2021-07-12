<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Presentación.Formularios.Alumno.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container body-container">
            <h2>Consultar Alumno</h2>
                            
                    <asp:Label ID="lbIdMuestra" runat="server" Text="Id: " class="control-label col-sm-2"></asp:Label>
                                   
                        <asp:Label ID="lbId" runat="server"  class="form-control"></asp:Label>
       
                    <asp:Label ID="lbNombreMuestra" runat="server" class="control-label col-sm-2" Text="Nombre: "></asp:Label>
                    
                        <asp:Label ID="lbNombre" runat="server" class="form-control"></asp:Label>

                    <asp:Label ID="lbapellido" runat="server" class="control-label col-sm-2" Text="Primer Apellido: "></asp:Label>
                   
                        <asp:Label ID="lbPrimerApellido" runat="server" class="form-control"></asp:Label>
                             
                    <asp:Label ID="lbapellidop" runat="server" class="control-label col-sm-2" Text="Segundo Apellido: "></asp:Label>
                  
                        <asp:Label ID="lbSegundoApellido" runat="server" class="form-control"></asp:Label>
                      
                    <asp:Label ID="lbFecha" runat="server" class="control-label col-sm-2" Text="Fecha de nacimiento: "></asp:Label>
                
                        <asp:Label ID="lbFechaNacimiento" runat="server" class="form-control"></asp:Label>
                   
                    <asp:Label ID="lbCurpM" runat="server" class="control-label col-sm-2" Text="Curp: "></asp:Label>
                  
                        <asp:Label ID="lbCurp" runat="server" class="form-control"></asp:Label>
                         
                    <asp:Label ID="lbCorreoM" runat="server" class="control-label col-sm-2" Text="Correo: "></asp:Label>
             
                        <asp:Label ID="lbCorreo" runat="server" class="form-control"></asp:Label>
                 
                    <asp:Label ID="lbTelefonoM" runat="server" class="control-label col-sm-2" Text="Teléfono: "></asp:Label>
              
                        <asp:Label ID="lbTelefono" runat="server" class="form-control"></asp:Label>
              
                    <asp:Label ID="lbEstadoM" runat="server" class="control-label col-sm-2" Text="Estado: "></asp:Label>
               
                        <asp:Label ID="lbEstado" runat="server" class="form-control"></asp:Label>
                                      
                    <asp:Label ID="lbEstatusM" runat="server" class="control-label col-sm-2" Text="Estatus: "></asp:Label>
             
                        <asp:Label ID="lbEstatus" runat="server" class="form-control"></asp:Label> <br />
                  
                     <asp:Button ID="btnRegresar" runat="server" Text="Regresar a la Lista" OnClick="btnRegresar_Click" />
        </div>
    

</asp:Content>
