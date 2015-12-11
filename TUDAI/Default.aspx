<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TUDAI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Santi</h1>
    <asp:Label CssClass="" Text="Santi" runat="server"></asp:Label>
    <h2>Noticias</h2>

    <asp:GridView ID="gvNoticias" runat="server" CssClass="table table-hover" GridLines="None" BorderStyle="None"
        AutoGenerateColumns="false">
        <Columns>

            <asp:BoundField  DataField="Id" HeaderText="Identificador"/>
            <asp:BoundField  DataField="Titulo" HeaderText="Titulo"/>
            <asp:BoundField  DataField="Fecha" HeaderText="Fecha"/>
            <asp:BoundField  DataField="Cuerpo" HeaderText="Cuerpo"/>
            <asp:BoundField  DataField="id_Categoria" HeaderText="IdCategoria"/>
            <asp:hyperlinkfield text="Editar"
            datatextformatstring="{0:c}"
            datanavigateurlfields="Id"
            datanavigateurlformatstring="~\alta_noticia.aspx?Id={0}"            
            headertext="Links"
            target="_self" />
            <asp:BoundField  DataField="Autor" HeaderText="Autor"/>

        </Columns>
    </asp:GridView>

    <div class="form-group">
        <asp:TextBox ID="txt_filtro" runat="server" placeholder="Autor de la noticia a filtrar" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btn_submit" runat="server" OnClick="Filtrar" Text="Filtrar" CssClass="btn btn-default"/>
    </div>

</asp:Content>
