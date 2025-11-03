<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConfirmacionCanje.aspx.cs" Inherits="TP_N_4_WebForms.ConfirmacionCanje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-8 text-center">
            
            <div class="card p-5 shadow-lg border-success">
                <i class="bi bi-check-circle-fill text-success" style="font-size: 4rem;"></i>
                <h1 class="card-title text-success mt-3">¡Canje Exitoso!</h1>
                <p class="lead mb-4">
                    Tu premio ha sido registrado y tus datos de contacto han sido guardados.
                    En breve recibirás un correo electrónico con los detalles para la coordinación de la entrega.
                </p>
                
                <hr />
                
                <asp:Button ID="btnVolverInicio" runat="server" 
                            Text="Volver al Inicio (Nuevo Canje)" 
                            CssClass="btn btn-primary btn-lg mt-3" 
                            OnClick="btnVolverInicio_Click" />
            </div>

        </div>
    </div>
</div>

</asp:Content>
