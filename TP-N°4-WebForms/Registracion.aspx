<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registracion.aspx.cs" Inherits="TP_N_4_WebForms.Registracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <h2 class="mb-4 text-center">Datos de Canje y Envío</h2>
            <p class="text-center text-secondary">Ingresa tu DNI para verificar si ya estás registrado o para crear tu cuenta y confirmar tu premio.</p>

            <div class="card p-4 shadow">
                
                <h4 class="mb-3">1. Identificación</h4>
                <div class="input-group mb-3">
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingresa tu DNI"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar Cliente" CssClass="btn btn-outline-secondary" OnClick="btnBuscar_Click" />
                </div>
                
                <hr />

                <h4 class="mb-3">2. Datos Personales</h4>
                
                <div class="row g-3">
                    <div class="col-md-6">
                        <label class="form-label" for="txtNombre">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label" for="txtApellido">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-12">
                        <label class="form-label" for="txtEmail">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <hr />
                
                <div class="d-grid gap-2 mt-4">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Canje y Registrar Datos" 
                                CssClass="btn btn-primary btn-lg" OnClick="btnConfirmar_Click" Enabled="false"/>
                </div>
                
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="text-center mt-3"></asp:Label>

            </div>
        </div>
    </div>
</div>
</asp:Content>
