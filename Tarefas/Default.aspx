<%@ Page Title="Tarefas" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tarefas._Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Lista de Tarefas</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <link href="~/App/App_Assets/Css/Default.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.14.0/dist/sweetalert2.min.css" rel="stylesheet">
    <script src="/App/App_Assets/Js/default.js"></script>

</head>
<body style="background-image: url('App/App_Assets/Img/Task.jpg'); background-size: cover; background-position: center">
    <form id="form1" runat="server">
        <div class="container">
            <div class="header-section">
                <h1 class="header-title">Lista de Tarefas</h1>
                <asp:Button ID="btnAdicionar" runat="server" Text="Nova Tarefa" OnClick="BtnAdicionar_click" CssClass="btn btn-primary" />
            </div>

            <asp:GridView ID="TarefasGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="TarefasGrid_RowCommand" DataKeyNames="Tarefa_id" CssClass="table table-striped table-dark">
                <Columns>
                    <asp:TemplateField HeaderText="Título">
                        <HeaderStyle CssClass="default-titulo-header" />
                        <ItemTemplate>
                            <div class="truncar-titulo">
                                <%# Eval("Titulo") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descrição">
                        <HeaderStyle CssClass="default-descricao-header" />
                        <ItemTemplate>
                            <div class="truncar-descricao">
                                <%# Eval("Descricao") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Status">
                      <HeaderStyle CssClass="default-status-header" />
                    <ItemTemplate>
                        <div class='<%# Convert.ToBoolean(Eval("Feito")) ? "status-feito" : "status-desfeito" %>'>
                            <i class='<%# Convert.ToBoolean(Eval("Feito")) ? "fas fa-check text-success" : "fas fa-times text-danger" %>'></i>
                        </div> 
                    </ItemTemplate>
                </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Ações">
                        <HeaderStyle  CssClass="default-acao-header" />
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning btn-sm" CommandName="Editar" CommandArgument='<%# Eval("Tarefa_id") %>' />
                            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CssClass="btn btn-danger btn-sm btn-excluir" CommandName="Excluir" CommandArgument='<%# Eval("Tarefa_id") %>' data-tarefaid='<%# Eval("Tarefa_id") %>' />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.14.0/dist/sweetalert2.all.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
