using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.App.App_Models;

namespace Tarefas.App.App_Services
{
    internal interface ITarefaServices
    {
        void Feito(int tarefa_id);
        void Desfeito(int tarefa_id);
        List<Tarefa> TodasTarefas();
    }
}
