<%@ Page Title="" Language="C#" MasterPageFile="~/WebForm/Master/master_login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WSIC2010.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .lb_error
    {
        color:#F00;
        font-size: 10px;
        font-weight:bold;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                    <div class="marco_basico_main">
                        <div class="marco_login" style="background-color:#c8d9eb;">
                            <div class="marco_login_titulo">
                                <div class="login_titulo">
                                    <h2>Acceso al SGO-COES</h2>
                                </div>
                            </div>
                            <div class="login_login_logo">
                                <img alt="" src="../images/UserConfig.png" />
                            </div>
                            <div class="marco_login_main">
                                <div class="fila_general">
                                    <label>Usuario:</label>
                                    <asp:TextBox ID="TextBoxUserLogin" runat="server" Width="200px" ></asp:TextBox>
                                </div>
                                <div class="fila_general">
                                    <label>Contrase&ntilde;a:</label>
                                    <asp:TextBox ID="TextBoxUserPassword" runat="server" TextMode="Password" Width="200px" ></asp:TextBox>
                                </div>
                                <div class="fila_general">
                                    <asp:Button ID="ButtonLogin" runat="server" Text="Ingresar" 
                                        onclick="ButtonLogin_Click"/>
                                </div>
                                <div class="fila_general">
                                    ¿No está registrado? 
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForm/Account/Register.aspx">Obtenga su cuenta de acceso</asp:HyperLink>
                                </div>
                                <div class="fila_general" style="text-align:left;margin-left:0px;padding-left:0px;">
                                    <asp:Label ID="labelmessage" runat="server" Text="" CssClass="lb_error"></asp:Label>
                                </div>
                                <div class="fila_general">
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/WebForm/Account/RestorePassword.aspx" Enabled="false" Visible="false">¿Olvido su contrase&ntilde;a? (clic aqu&iacute;)</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
