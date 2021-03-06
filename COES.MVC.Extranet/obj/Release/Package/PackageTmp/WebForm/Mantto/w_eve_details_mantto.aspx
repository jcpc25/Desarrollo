﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForm/Master/master_noFooter.Master" AutoEventWireup="true" CodeBehind="w_eve_details_mantto.aspx.cs" Inherits="WSIC2010.Mantto.w_eve_details_mantto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.4.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.custom.min.js"></script>
    <link rel="Stylesheet" type="text/css" href="../Styles/jquery-ui-1.8.custom.css"/>
    <style type="text/css">
            .amantto_tabla
            {
                margin:10px;
                font-size:10px;              
            }
            .amantto_tabla tr
            {
                /*background-color:Gray;*/   
            }
            .amantto_tabla td
            {
                padding-left:10px;
	            border-style:solid;
	            border-width:thin;
	            border-color:#CCCCCC;
	            border-collapse:collapse;
	            border-spacing:0px;
	            padding-top:5px;
	            padding-bottom:5px;        
            }
            .amantto_tit_col
            {
                /*background-color: #9FFFFF;*/
                background-color:#DCE6F2;
                font-weight: bold;
                width: 85px;
                text-align: right;
                padding: 5px;
                color:#000;
            }
            .amantto_tit
            {
                font-weight:bold;
                padding:5px;
                text-align: right;
                vertical-align:text-top;
                background-color:#DCE6F2;
            }

            .atab_img
            {
	            border:0px;
	            padding:0px;
	            border-style:none;
	            margin:0px;
                background-color:transparent;		
            }
            .tbFecha
            {
                text-align:left;
            }
            table.ui-datepicker-calendar td
            {
                width:5px;
                text-align: center;
            } 
    </style>
    <script type="text/javascript">
        jQuery(function ($) {
            $.datepicker.regional['es'] = {
                clearText: 'Borra',
                clearStatus: 'Borra fecha actual',
                closeText: 'Cerrar',
                closeStatus: 'Cerrar sin guardar',
                prevText: '<Ant',
                prevBigText: '<<',
                prevStatus: 'Mostrar mes anterior',
                prevBigStatus: 'Mostrar año anterior',
                nextText: 'Sig>',
                nextBigText: '>>',
                nextStatus: 'Mostrar mes siguiente',
                nextBigStatus: 'Mostrar año siguiente',
                currentText: 'Hoy',
                currentStatus: 'Mostrar mes actual',
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                monthStatus: 'Seleccionar otro mes',
                yearStatus: 'Seleccionar otro año',
                weekHeader: 'Sm',
                weekStatus: 'Semana del año',
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Jue', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                dayStatus: 'Set DD as first week day',
                dateStatus: 'Select D, M d',
                dateFormat: 'dd/mm/yy',
                firstDay: 1,
                initStatus: 'Seleccionar fecha',
                isRTL: false
            };
            $.datepicker.setDefaults($.datepicker.regional['es']);
        });
        $(function () {
            $('#MainContent_tBoxInicio').datepicker({
                dateFormat: "dd/mm/yy 00:00",
                changeMonth: true,
                showOthersMonths: true,
                onSelect: function (dateStr) {
                    var d = $.datepicker.parseDate('dd/mm/yy', dateStr);
                    $('#MainContent_tBoxFin').datepicker('setDate', new Date(d.getFullYear(), d.getMonth(), d.getDate() + 1));
                    $('#MainContent_tBoxFin').datepicker("option", "minDate", dateStr);
                    $('#MainContent_tBoxFin').datepicker("option", "maxDate", new Date(d.getFullYear(), d.getMonth() + 2, d.getDate()));
                }
            });
            $('#MainContent_tBoxFin').datepicker({
                dateFormat: "dd/mm/yy 00:00"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <h2>DETALLE MANTENIMIENTO</h2>
        <table style="width:650px;"class="amantto_tabla">
        <tr>
            <td class="amantto_tit_col">EMPRESA</td>
            <td><asp:Label ID="lbl_Empresa" runat="server" Enabled="false"/></td>
        </tr>
        <tr>
            <td class="amantto_tit_col">UBICACI&Oacute;N</td>
            <td><asp:Label ID="lbl_area" runat="server" Enabled="false"/></td>
        </tr>
        <tr>
            <td class="amantto_tit_col">FAMILIA</td>
            <td><asp:Label ID="lbl_familia" runat="server" Enabled="false"/></td>
        </tr>
        <tr>
            <td class="amantto_tit_col">EQUIPO</td>
            <td><asp:Label ID="lbl_equipo" runat="server" Enabled="false"/></td>
        </tr>
        <tr>
            <td class="amantto_tit_col">TIPO</td>
            <td>
                <asp:DropDownList  ID="ddlTipoEven" runat="server" Enabled="false">
                    <asp:ListItem Text="NO DEFINIDO" Value="-1" Selected="True"/>
                    <asp:ListItem Text="PREVENTIVO" Value="1"/>
                    <asp:ListItem Text="CORRECTIVO" Value="2"/>
                    <asp:ListItem Text="AMPLIACION/MEJORAS" Value="3"/>
                    <asp:ListItem Text="PRUEBAS" Value="6"/>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">INICIO</td>
            <td>
                <input id="txtBoxInicio" type="text" class="tbFecha" runat="server" disabled="disabled"/>&nbsp;(dd/mm/aaaa hh:mm)
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">FINAL</td>
            <td>
                <input id="txtBoxFin" type="text" class="tbFecha" runat="server" disabled="disabled"/>&nbsp;(dd/mm/aaaa hh:mm)
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">MW INDISPONIBLES</td>
            <td><asp:TextBox ID="ddlMWIndisp" runat="server" Text='<%# Bind("evenmwindisp","{0:0.#}") %>' Enabled="false"/></td>
        </tr>
        <tr>
            <td class="amantto_tit_col">INDISPONIBILIDAD (E/F)</td>
            <td>
                <asp:DropDownList  ID="ddlIndisp" runat="server" Enabled="false">
                    <asp:ListItem Text="NO DEFINIDO" Value="-1" Selected="True" />
                    <asp:ListItem Text="En Servicio" Value="E"/>
                    <asp:ListItem Text="Fuera de Servicio" Value="F"/>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">INTERRUPCI&Oacute;N (S/N)</td>
            <td>
                <asp:DropDownList ID="ddlInterrup" runat="server" Enabled="false">
                    <asp:ListItem Text="NO DEFINIDO" Value="-1" Selected="True" />
                    <asp:ListItem Text="SI" Value="S"/>
                    <asp:ListItem Text="NO" Value="N"/>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">SITUACIÓN</td>
            <td>
                <asp:DropDownList ID="ddlTipoMantto" runat="server" Enabled="false">
                    <asp:ListItem Text="NO DEFINIDO" Value="-1" Selected="True"/>
                    <asp:ListItem Text="PROGRAMADO" Value="P"/>
                    <asp:ListItem Text="REPROGRAMADO" Value="R"/>
                    <asp:ListItem Text="FORZADO/IMPREVISTO" Value="F"/>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">DESCRIPCIÓN</td>
            <td>
                <asp:TextBox ID="txtBoxDescrip" runat="server" Enabled="false"
                             Height="100px" TextMode="MultiLine" 
                             Width="95%" Font-Names="Arial">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">OBSERVACIONES</td>
            <td>
                <asp:TextBox ID="txtBoxObserv" runat="server" Enabled="false"
                             Height="100px" TextMode="MultiLine" 
                             Width="95%" Font-Names="Arial">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">DOCUMENTOS ADJUNTOS</td>
            <td>                               
                <asp:ListBox ID="ListBoxArchivosCargados" runat="server" Rows="4" Width="600" Enabled="false"></asp:ListBox>                                
                <div style="vertical-align: top">                                 
                <asp:Button id="ButtonAbrirArchivo" Text="Abrir Documento" OnClick="ButtonAbrirArchivo_Click" runat="server" Enabled="false"/>
                <asp:Button id="ButtonBorrarArchivo" Text="Borrar Documento" OnClick="ButtonBorrarArchivo_Click" runat="server" Enabled="false"/>
                </div>
            </td>
        </tr>
        <tr>
            <td class="amantto_tit_col">PARA ADJUNTAR =></td>
            <td>  
                <asp:Label ID="LabelUploadText" runat="server" Text="Descripción que se mostrará:"></asp:Label><br />
                <asp:TextBox ID="TextBoxDescArchivo" runat="server" Width="500"/> 
                <asp:Label ID="Label2" runat="server" Text="Llenar este campo"></asp:Label>        
                <asp:FileUpload id="FileUpload1" runat="server" Width="500" Enabled="false"></asp:FileUpload>                               
                <asp:Button id="UploadButton" Text="Cargar Archivo" OnClick="UploadButton_Click" runat="server" Enabled="false"> </asp:Button>                                                                 
            </td> 
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Guardar" onclick="UpdateButton_Click" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancelar" onclick="CancelButton_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                    <asp:Label ID="LabelMensaje" runat="server" Text="Registros" ForeColor="#006666"/>
            </td>
        </tr>
</table>
</asp:Content>

