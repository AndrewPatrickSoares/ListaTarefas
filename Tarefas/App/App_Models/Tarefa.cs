using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarefas.App.App_Models
{
    public class Tarefa
    {
        public int Tarefa_id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Feito { get; set; }
        public bool Desfeito { get; set; }
    }
}