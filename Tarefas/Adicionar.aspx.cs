using System;
using System.Web.UI;
using Tarefas.App.App_Models;
using Tarefas.App.App_Repo;

namespace Tarefas
{
    public partial class Adicionar : System.Web.UI.Page
    {
        private TarefaRepo repo;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BdListaTarefas"].ConnectionString;
            repo = new TarefaRepo(connectionString);

            if (!IsPostBack)
            {
                CarregarTarefaParaEdicao();
            }

            AtualizarMensagemErro();
        }

        private void CarregarTarefaParaEdicao()
        {
            if (Request.QueryString["id"] != null)
            {
                tituloTela.InnerText = "Editar Tarefa";
                int tarefaId = Convert.ToInt32(Request.QueryString["id"]);
                Tarefa tarefa = repo.Tarefa_id(tarefaId);
                if (tarefa != null)
                {
                    txtTitulo.Text = tarefa.Titulo;
                    txtDescricao.Text = tarefa.Descricao;
                    blnFeito.Checked = tarefa.Feito;
                    blnDesfeito.Checked = tarefa.Desfeito;
                }
            }
            else
            {
                tituloTela.InnerText = "Adicionar Tarefa";
            }
        }

        private void AtualizarMensagemErro()
        {
            if (ViewState["msgErro"] != null)
            {
                hfMensagemErro.Value = ViewState["msgErro"].ToString();
            }

            string script = $"var hfMensagemErroClientID = '{hfMensagemErro.ClientID}';";
            ClientScript.RegisterStartupScript(GetType(), "hfMensagemErroClientIDScript", script, true);
        }

        protected void BntSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            string msgErro = ValidarDados(titulo, descricao);

            if (string.IsNullOrEmpty(msgErro))
            {
                SalvarTarefa(titulo);
            }
            else
            {
                MostrarMensagemErro(msgErro);
            }
        }

        private string ValidarDados(string titulo, string descricao)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                return "O título não pode estar vazio.";
            }

            if (string.IsNullOrEmpty(descricao))
            {
                return "A descrição não pode estar vazia.";
            }

            // Se estamos editando uma tarefa, não precisamos verificar o título da tarefa atual
            if (Request.QueryString["id"] != null)
            {
                int tarefaId = Convert.ToInt32(Request.QueryString["id"]);
                Tarefa tarefaAtual = repo.Tarefa_id(tarefaId);
                if (tarefaAtual != null && !tarefaAtual.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) && repo.TarefaExiste(titulo))
                {
                    return "Outra tarefa já possui este título.";
                }
            }
            else
            {
                // Verificação para novo título
                if (repo.TarefaExiste(titulo))
                {
                    return "A tarefa já existe.";
                }
            }

            return string.Empty;
        }


        private void SalvarTarefa(string titulo)
        {
            Tarefa tarefa = new Tarefa
            {
                Titulo = titulo,
                Descricao = txtDescricao.Text,
                Feito = blnFeito.Checked,
                Desfeito = blnDesfeito.Checked
            };

            if (Request.QueryString["id"] != null)
            {
                tarefa.Tarefa_id = Convert.ToInt32(Request.QueryString["id"]);
                repo.AtualizarTarefa(tarefa);
                MostrarMensagemSucesso("Tarefa atualizada com sucesso!");
            }
            else
            {
                repo.AdicionarTarefa(tarefa);
                MostrarMensagemSucesso("Tarefa adicionada com sucesso!");
            }
        }

        private void MostrarMensagemSucesso(string mensagem)
        {
            string script = $@"
                Swal.fire({{
                    title: 'Sucesso',
                    text: '{mensagem}',
                    icon: 'success',
                    timer: 1500,
                    showConfirmButton: false
                }}).then(function() {{
                    window.location.href = 'Default.aspx';
                }});";
            ScriptManager.RegisterStartupScript(this, GetType(), "Sucesso", script, true);
        }

        private void MostrarMensagemErro(string mensagem)
        {
            string script = $"Swal.fire({{title: 'Erro', text: '{mensagem}', icon: 'error'}});";
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", script, true);
        }
    }
}
