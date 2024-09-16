using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tarefas.App.App_Models;
using Tarefas.App.App_Repo;

namespace Tarefas.App.App_Services
{
    public class TarefaServices : ITarefaServices
    {
        private readonly TarefaRepo _repo;
        public TarefaServices(TarefaRepo repo)
        {
            _repo = repo;
        }

        public void Feito(int tarefa_id)
        {
            Tarefa tarefa = _repo.Tarefa_id(tarefa_id);
            tarefa.Feito = true;
            tarefa.Desfeito = false;
            _repo.AtualizarTarefa(tarefa);
        }

        public void Desfeito(int tarefa_id)
        {
            Tarefa tarefa = _repo.Tarefa_id(tarefa_id);
            tarefa.Feito = false;
            tarefa.Desfeito = true;
            _repo.AtualizarTarefa(tarefa);
        }

        public List<Tarefa> TodasTarefas()
        {
            return _repo.TodasTarefas();
        }

    }
}

