<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IngresoVoucher.aspx.cs" Inherits="TP_N_4_WebForms.IngresoVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <h2 class="mb-4 text-center">Ingresá tu Código Promocional</h2>
                
                <div class="card p-4 shadow">
                    <p class="text-secondary text-center">Introduce el código alfanumérico que recibiste en tu compra.</p>

                    <div class="mb-3">
                        <label class="form-label" for="txtCodigoVoucher">Código del Voucher</label>
                        
                        <asp:TextBox ID="txtCodigoVoucher" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="d-grid gap-2">
                        <asp:Button ID="btnValidar" runat="server" Text="Validar Código" 
                                    CssClass="btn btn-primary btn-lg" OnClick="btnValidar_Click" />
                    </div>

                    <hr />
                    <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red" EnableViewState="false" CssClass="text-center mt-3"></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>