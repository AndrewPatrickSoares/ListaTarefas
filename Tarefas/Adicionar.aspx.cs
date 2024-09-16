using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarefas.App.App_Models;
using Tarefas.App.App_Repo;

namespace Tarefas
{
    public partial class Adicionar : System.Web.UI.Page
    {
        // TarefaRepo repo = new TarefaRepo();
        private TarefaRepo repo;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BdListaTarefas"].ConnectionString;
            repo = new TarefaRepo(connectionString);
            tituloTela.InnerText = "Adicionar Tarefa";
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                tituloTela.InnerText = "Editar Tarefa";
                int tarefa_id = Convert.ToInt32(Request.QueryString["id"]);
                Tarefa tarefa = repo.Tarefa_id(tarefa_id);
                txtTitulo.Text = tarefa.Titulo;
                txtDescricao.Text = tarefa.Descricao;
                blnFeito.Checked = tarefa.Feito;
                blnDesfeito.Checked = tarefa.Desfeito;
            }

            if (ViewState["msgErro"] != null)
            {
                hfMensagemErro.Value = ViewState["msgErro"].ToString();
            }

            string script = $"var hfMensagemErroClientID = '{hfMensagemErro.ClientID}';";
            ClientScript.RegisterStartupScript(this.GetType(), "hfMensagemErroClientIDScript", script, true);
        }

        protected void BntSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string msgErro = "";
            int tarefa_id = 0;

            if (!string.IsNullOrEmpty(titulo))
            {
                if (Request.QueryString["id"] != null)
                {

                    tarefa_id = Convert.ToInt32(Request.QueryString["id"]);

                    Tarefa tarefaAtual = repo.Tarefa_id(tarefa_id);


                    if (!tarefaAtual.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                    {

                        bool tituloJaExiste = repo.TarefaExiste(titulo);
                        if (tituloJaExiste)
                        {
                            msgErro = "Outra tarefa já possui este título.";
                        }
                    }
                }
                else
                {
                    bool tarefaExiste = repo.TarefaExiste(titulo);
                    if (tarefaExiste)
                    {
                        msgErro = "A tarefa já existe.";
                    }
                }

                if (string.IsNullOrEmpty(msgErro))
                {
                    Tarefa tarefa = new Tarefa
                    {
                        Titulo = txtTitulo.Text,
                        Descricao = txtDescricao.Text,
                        Feito = blnFeito.Checked,
                        Desfeito = blnDesfeito.Checked
                    };

                    if (Request.QueryString["id"] != null) 
                    {
                        tarefa.Tarefa_id = tarefa_id;
                        repo.AtualizarTarefa(tarefa);
                    }
                    else // Adicionando uma nova tarefa
                    {
                        repo.AdicionarTarefa(tarefa);
                    }
                }
            }
            else
            {
                msgErro = "O título não pode estrar vazio.";
            }

            // Exibir mensagem de erro, se houver
            if (!string.IsNullOrEmpty(msgErro))
            {
                string script = $"Swal.fire({{title: 'Erro', text: '{msgErro}', icon: 'error'}});";
                ScriptManager.RegisterStartupScript(this, GetType(), "Erro", script, true);
                return;
            }

            Response.Redirect("Default.aspx");
        }
    }
}