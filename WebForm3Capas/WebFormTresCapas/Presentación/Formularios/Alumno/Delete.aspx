<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentación.Formularios.Alumno.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-container">
        <h2>Consultar Alumno</h2>

        <asp:Label ID="lbIdMuestra" runat="server" Text="Id: " class="control-label col-sm-2"></asp:Label>

        <asp:Label ID="lbId" runat="server" class="form-control"></asp:Label>

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

        <asp:Label ID="lbEstatus" runat="server" class="form-control"></asp:Label>
        <br />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        
        &nbsp;<asp:Button ID="btnRegresar" runat="server" Text="Regresar a la Lista" OnClick="btnRegresar_Click" />
        <asp:Button ID="btnASMX" runat="server" OnClick="btnASMX_Click" Text="Elimar ASMX" />
        <asp:Label ID="lbRespuesta" runat="server" Text="Label"></asp:Label>
         &nbsp;&nbsp;
         <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal" id="IdEliminar" onclick="eliminar()">
            Eliminar
        </button>
    
    </div>

    <div class="modal" id="ventanaModal"  role="dialog">
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Encabezado Modal -->
        <div class="modal-header">
          <h4 class="modal-title">Detalle Alumno</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        
        <!-- Curepo de la Modal -->
        <div class="modal-body" id="cuerpoModal">
            <p id="Modal">Parrafo de Prueba</p>
        </div>
        
        <!-- Modal footer -->
        <div class="modal-footer">
        <button type="button" id="btnEliminarConfirmar" name="submit" class="btn btn-success" data-dismiss="modal" onclick="eliminarConfirmar()">Confirmar</button>
          <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
        </div>
        
      </div>
    </div>
  </div>
  

    
    <script>

        function eliminar() {
            var nombre = $("#<%=lbId.ClientID %>").text() + ' ' +
                         $("#<%=lbNombre.ClientID %>").text() + ' ' +
                         $("#<%=lbPrimerApellido.ClientID %>").text() + ' ' +
                         $("#<%=lbSegundoApellido.ClientID %>").text()

                         $("#Modal").text("Desea eliminar al usuario: " + nombre);
                         $("#ventanaModal").modal();
        }

        function eliminarConfirmar() {
            var json = $("#<%=lbId.ClientID %>").text();
            
            var parametro = " { 'id':'" + json + " '}";
            var urlw = 'https://localhost:44348/WS_Alumno.asmx/eliminarModal';
            $.ajax({
                type: 'POST',
                url: urlw,
                data: parametro,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: exito,
                error: errorGenerico
            });
        }

        function exito(data) {
            var json = JSON.parse(data.d);
            if (json.respuesta != null) {
                alert("Transacción con exito");
                window.location.replace("Index.aspx");
                } else {
                alert("La respues recibida del web services es incorrecta" + data.d);
            }

        }

        function errorGenerico(jqXHR, exeception) {
            var mensaje = '';
            if (jqXHR.status === 0) {
                mensaje = 'No está conectado';
            }
            else if (jqXHR.status === 404) {
                mensaje = 'Página no encontrada [404]';
            }
            else if (jqXHR.status === 500) {
                mensaje = 'Error no hay conexión al servidor [500]';
            }
            else if (jqXHR.status === 'parseerror') {
                mensaje = 'El parseo del JSON es erroneo';
            }
            else if (jqXHR.status === 'timeout') {
                $('body').addClass('loaded');
            }
            else if (jqXHR.status === 'abort') {
                mensaje = 'La petición Ajax fue afortada';
            }
            else {
                mensaje = 'Error no conocido';
                console.log(exeception);
            }
            alert(mensaje);
        }
            
    </script>


   
</asp:Content>
