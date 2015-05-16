<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarEquipo.ascx.cs" Inherits="WSIC2010.SeleccionarEquipo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div>
<table>
    <tbody>
        <tr>
            <td>Empresa </td>
            <td>
                
                <asp:DropDownList ID="ddlEmpresa" runat="server" 
                    onselectedindexchanged="ddlEmpresa_SelectedIndexChanged"/>               
            </td>
        </tr>
        <tr>
            <td>Ubicación</td>
            <td>
                <asp:DropDownList ID="ddlArea" runat="server" 
                    onselectedindexchanged="ddlArea_SelectedIndexChanged"/>
            </td>
        </tr>
        <tr>
            <td>Equipo</td>
            <td>
                <asp:DropDownList ID="ddlEquipo" runat="server"  
                    onselectedindexchanged="ddlEquipo_SelectedIndexChanged" AutoPostBack="True"/>
            </td>
        </tr>
    </tbody>
</table>
</div>

<ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" 
    PromptText="Seleccione una Empresa" 
    TargetControlID="ddlEmpresa"    
    ServicePath="WebServiceEquipos.asmx" 
    ServiceMethod="GetEmpresas" 
    Category="Empresa" 
    UseContextKey="True" 
    ContextKey="-1"
    LoadingText="Por favor espere..."     />

<ajaxToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server"
    TargetControlID="ddlArea"
    ParentControlID="ddlEmpresa"
    PromptText="Seleccione una ubicación"
    ServiceMethod="GetAreasPorEmpresa"
    ServicePath="WebServiceEquipos.asmx"
    Category="Area" 
    LoadingText="Por favor espere..."/>

<ajaxToolkit:CascadingDropDown ID="CascadingDropDown3" runat="server"
    TargetControlID="ddlEquipo"
    ParentControlID="ddlArea"
    PromptText="Seleccione un equipo"
    ServiceMethod="GetEquiposPorArea"
    ServicePath="WebServiceEquipos.asmx"
    Category="Equipo"
    LoadingText="Por favor espere..." />
<asp:TextBox ID="TextBoxEquiCodi" runat="server" Visible="false" Width="54px"></asp:TextBox>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="inline">
    <ContentTemplate>
        <asp:Label ID="LabelEquipoElegido" runat="server" Text="[Equipo elegido: Ninguno]" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlEquipo" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
