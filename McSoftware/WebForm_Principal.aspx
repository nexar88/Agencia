<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_Principal.aspx.cs" Inherits="McSoftware.WebForm_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/master.css" rel="stylesheet" />
</head>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<body runat="server">
    <form runat="server">
        <div class="container">
            <div class="row" style="margin-top: 10%;">
                <div class="col-sm-12 col-md-8 col-sm-offset-0 col-md-offset-2">
                    <fieldset class="scheduler-border">
                        <legend class="scheduler-border">
                            <asp:Label ID="lblTitulo" runat="server" Text="AUTENTICACIÓN DE CREDENCIALES" Style="font-weight: 700;"></asp:Label>
                        </legend>
                        <div class="col-md-4">
                            <div style="text-align: center; margin-top: 30%; border: 5px;">
                                <img src="util/banco.png" height="250px" width="350px" class="img-responsive center-block" />
                                <br />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">

                                <div class="form-group">
                                    <label for="txtUsuario">
                                        Usuario</label>
                                    <asp:TextBox ID="txtLogin" MaxLength="25" runat="server" CssClass="form-control" placeholder="" Text="45465030" autocomplete="off" />
                                </div>
                                <div class="form-group">
                                    <label for="txtClave">
                                        Contraseña</label>
                                    <asp:TextBox ID="txtPas" MaxLength="25" runat="server" CssClass="form-control" placeholder="" Text="12345" TextMode="Password" autocomplete="off" />
                                </div>
                                <label for="txtCaptcha">
                                    Captcha</label>
                                <asp:Panel ID="divEnviaCC" runat="server" CssClass="visto">
                                    <div style="text-align: center">
                                        <cc1:CaptchaControl ID="ccEnvia" runat="server" BackColor="WhiteSmoke" BorderColor="GrayText"
                                            BorderStyle="Solid" BorderWidth="1" CaptchaBackgroundNoise="none" CaptchaHeight="60"
                                            CaptchaLength="5" CaptchaLineNoise="None" CaptchaMaxTimeout="650" CaptchaMinTimeout="5"
                                            CaptchaWidth="200" Style="font-size: 10px;" />
                                    </div>
                                    <br />
                                    <asp:TextBox ID="txtCaptcha" runat="server" autocomplete="off" CssClass="form-control text-uppercase"
                                        placeholder="Ingrese el código de imagen" onpaste="return false" MaxLength="5" />
                                </asp:Panel>
                                <div class="form-group" id="DecJur" runat="server" visible="false">
                                    <asp:CheckBox ID="chkDecJur" Text="&nbsp;Acepto Declaración Jurada" runat="server"
                                        class="form-control font-in" Checked="true" />
                                    <a href="#" data-toggle="modal" data-target="#modalCartillaSeguridad" style="text-decoration: none;">
                                        <span class="label label-warning" style="cursor: pointer;">Ver Detalle</span></a>
                                </div>
                                <div class="form-group">
                                    <div style="text-align: center">
                                        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" class="btn btn-primary"
                                            OnClick="btnLogin_Click" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-group">
                                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                    </div>

                                    <div runat="server" id="MensajeAlerta" visible="false">
                                        <div class="alert alert-warning custom-combobox-input" style="font-size: smaller; color: Red">
                                            <asp:Label ID="lblMensajeAlerta" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">

                            <div class="form-group">
                                <div style="text-align: center; margin-top: 80%; border: 5px;">
                                    <img src="util/descarga.png" height="50px" width="140px" class="img-responsive center-block" />
                                    <br />
                                </div>

                            </div>

                        </div>
                        <input type="hidden" runat="server" name="hash" id="hash" />
                    </fieldset>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
