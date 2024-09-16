using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarefas.App.App_Repo;
using Tarefas.App.App_Services;

namespace Tarefas
{
    public partial class _Default : Page
    {
        private ITarefaServices _services;
        private ITarefaRepo _repo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["delete"] != null)
            {
                int tarefaId = Convert.ToInt32(Request.QueryString["delete"]);
                ExcluirTarefa(tarefaId);
                Response.Redirect("Default.aspx");
            }
            else if (!IsPostBack)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BdListaTarefas"].ConnectionString;
                var repo = new TarefaRepo(connectionString);
                _services = new TarefaServices(repo);
                ExibirTarefas();
            }
        }

        private void ExibirTarefas()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BdListaTarefas"].ConnectionString;
            if (_services == null)
            {
                var repo = new TarefaRepo(connectionString);
                _services = new TarefaServices(repo);
            }

            var tarefas = _services.TodasTarefas();
            TarefasGrid.DataSource = tarefas;
            TarefasGrid.DataBind();
        }

         private void ExcluirTarefa(int tarefaId)
         {
             string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BdListaTarefas"].ConnectionString;
             if(_repo == null)
             {
                 _repo = new TarefaRepo(connectionString);
             }
             _repo.ExcluirTarefa(tarefaId);
             ExibirTarefas();
         }

        protected void btnAdicionar_click(object sender, EventArgs e)
        {
            Response.Redirect("Adicionar.aspx");
        }

        // Ajuste no evento RowCommand para editar/excluir com base no ID da tarefa
        protected void TarefasGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Verifica o nome do comando (Editar ou Excluir)
            if (e.CommandName == "Editar")
            {
                // Obtém o ID da tarefa do CommandArgument
                int tarefaId = Convert.ToInt32(e.CommandArgument);

                // Redireciona para a página de edição com o ID da tarefa
                Response.Redirect($"Adicionar.aspx?id={tarefaId}");
            }
            else if (e.CommandName == "Excluir")
            {
                // Obtém o ID da tarefa do CommandArgument
                int tarefaId = Convert.ToInt32(e.CommandArgument);

                // Chama o método para excluir a tarefa
                ExcluirTarefa(tarefaId);

                ExibirTarefas();
            }
        }
    }
}
