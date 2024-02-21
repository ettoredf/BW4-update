<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="BW4._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="d-flex flex-wrap  gap-4 ms-5">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="card mx-2 my-2 text-white ombra prodotto">
                    <img src='<%# Eval("Immagine") %>' class="card-img-top img-fluid imgProdotto" alt='<%# Eval("NomeProdotto") %>'>
                    <div class="card-body d-flex flex-column justify-content-between cardBody">
                        <div>
                            <h5 class="card-title text-center fStyle"><%# Eval("NomeProdotto") %></h5>
                            <p class="card-text text-center fStyle"><%# Eval("Prezzo", "{0:c2}") %></p>
                        </div>


                    </div>
                    <div class="card-footer cardBody">
                        <a href='<%# "Dettagli.aspx?IdProdotto=" + Eval("Id") %>' class="btn btn-sm btnChange text-white">Dettagli</a>
                        <asp:Button ID="addToCart" class="btn btn-sm btnChange   text-white" runat="server" Text="Add To Cart" OnClick="addToCart_Click" CommandArgument='<%# Eval("Id") %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>
