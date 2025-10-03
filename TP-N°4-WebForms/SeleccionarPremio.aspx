<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="TP_N_4_WebForms.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container mt-5">
        <h2 class="mb-4 text-center">¡Código Validado! Elige tu Premio</h2>
        <hr />

        <asp:Repeater ID="rptPremios" runat="server" OnItemCommand="rptPremios_ItemCommand">
            
            <ItemTemplate>
                <div class="card mb-4 shadow-sm">
                    <div class="row g-0">
                        
                        <div class="col-md-4" style="padding: 0;"> 
                            <div style="height: 250px; overflow: hidden;"> 
                                
                                <div id='carousel-<%# Eval("Id") %>' class="carousel slide h-100" data-bs-ride="carousel">
                                    
                                    <div class="carousel-inner h-100">
                                        <asp:Repeater ID="rptImagenes" runat="server" DataSource='<%# Eval("ListaImagenes") %>'>
                                            <ItemTemplate>
                                                <div class='carousel-item h-100 <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                                    <img src='<%# Eval("ImagenURL") %>' 
                                                         class="d-block w-100 h-100" 
                                                         alt="Imagen de Producto" 
                                                         style="object-fit: contain;"> 
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    
                                    <button class="carousel-control-prev" type="button" data-bs-target='<%# "#carousel-" + Eval("Id") %>' data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Previous</span>
                                    </button>
                                    <button class="carousel-control-next" type="button" data-bs-target='<%# "#carousel-" + Eval("Id") %>' data-bs-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Next</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <ul class="list-group list-group-flush mb-3">
                                    <li class="list-group-item">Marca: <%# Eval("Marca.Descripcion") %></li>
                                    <li class="list-group-item">Categoría: <%# Eval("Categoria.Descripcion") %></li>
                                </ul>
                                
                                <asp:Button ID="btnElegir" runat="server" 
                                            Text="¡Lo Quiero!" 
                                            CssClass="btn btn-success"
                                            CommandName="Elegir"
                                            CommandArgument='<%# Eval("Id") %>' />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>