using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.App.App_Models;

namespace Tarefas.App.App_Repo
{
    internal interface ITarefaRepo
    {
        List <Tarefa> TodasTarefas();
        Tarefa Tarefa_id(int tarefa_id);
        void AdicionarTarefa(Tarefa tarefa);
        void AtualizarTarefa(Tarefa tarefa);    
        void ExcluirTarefa(int tarefa_id);
    }
}
