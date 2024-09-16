<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adicionar.aspx.cs" Inherits="Tarefas.Adicionar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/App/App_Assets/Css/Adicionar.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="/App/App_Assets/Js/Adicionar.js"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image: url('App/App_Assets/Img/Task.jpg'); background-size: cover; background-position: center">
    <form id="form1" runat="server">
    <div class="container container-adicionar">
        <h2 id="tituloTela" class="tituloTela" runat="server"></h2>

        <div class="form-group">
            <label for="txtTitulo" class="tituloItem">Título</label>
            <asp:TextBox id="txtTitulo" CssClass="form-control" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtDescricao" class="descricaoItem">Descrição</label>
            <asp:TextBox id="txtDescricao" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server" />
        </div>

        <div class="btn-group">
            <div class="form-group form-check">
                <asp:RadioButton id="blnFeito" CssClass="form-check-input[type=radio] " GroupName="Status" Checked="true" runat="server" />
                <label  class="form-check-label" for="blnFeito">Concluída</label>
            </div>

            <div class="form-group form-check">
                <asp:RadioButton id="blnDesfeito" CssClass="form-check-input[type=radio] " GroupName="Status" runat="server"/>
                <label class="form-check-label" for="blnDesfeito">Não Concluída</label>
            </div>
                <asp:Button id="btnSalvar" CssClass="btn btn-primary btn-salvar" Text="Salvar" OnClick="BntSalvar_Click" runat="server" />
                <asp:HiddenField ID="hfMensagemErro" runat="server" />
                <asp:HiddenField ID="hfMensagemSucesso" runat="server" />
        </div>
    </div>
</form>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
