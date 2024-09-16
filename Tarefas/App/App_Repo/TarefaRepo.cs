using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tarefas.App.App_Models;
using MySql.Data.MySqlClient;

namespace Tarefas.App.App_Repo
{
    public class TarefaRepo : ITarefaRepo
    {
        private readonly string _connectionString;
        public TarefaRepo(string ConnectionStrings)
        {
            _connectionString = ConnectionStrings;
        }

        public List<Tarefa> TodasTarefas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            using (MySqlConnection Conn = new MySqlConnection(_connectionString))
            {
                Conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TB_TAREFAS", Conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tarefa tarefa = new Tarefa();
                    {
                        tarefa.Tarefa_id = Convert.ToInt32(reader["Tarefa_id"]);
                        tarefa.Titulo = reader["Titulo"].ToString();
                        tarefa.Descricao = reader["Descricao"].ToString();
                        tarefa.Feito = Convert.ToBoolean(reader["Feito"]);
                        tarefa.Desfeito = Convert.ToBoolean(reader["Desfeito"]);
                        tarefas.Add(tarefa);
                    };
                }
            }
            return tarefas;
        }

        public void AdicionarParametros(MySqlCommand cmd, Tarefa tarefa)
        {

            if (tarefa.Tarefa_id > 0)
            {
                cmd.Parameters.AddWithValue("@Tarefa_id", tarefa.Tarefa_id);
            }

            cmd.Parameters.AddWithValue("@Titulo", tarefa.Titulo);
            cmd.Parameters.AddWithValue("@Descricao", tarefa.Descricao);
            cmd.Parameters.AddWithValue("@Feito", tarefa.Feito);
            cmd.Parameters.AddWithValue("@Desfeito", tarefa.Desfeito);

        }

        public Tarefa Tarefa_id(int tarefa_id) 
        {

            Tarefa tarefa = new Tarefa();
            using (MySqlConnection Conn = new MySqlConnection(_connectionString))
            {
                Conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TB_TAREFAS WHERE Tarefa_id = @Tarefa_id", Conn);
                cmd.Parameters.AddWithValue("@Tarefa_id", tarefa_id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tarefa.Tarefa_id = Convert.ToInt32(reader["Tarefa_id"]);
                    tarefa.Titulo = reader["Titulo"].ToString();
                    tarefa.Descricao = reader["Descricao"].ToString();
                    tarefa.Feito = Convert.ToBoolean(reader["Feito"]);
                    tarefa.Desfeito = Convert.ToBoolean(reader["Desfeito"]);
                }
            }
            return tarefa;
        }
        public void AdicionarTarefa(Tarefa tarefa) 
        {

            using (MySqlConnection Conn = new MySqlConnection(_connectionString))
            {
                Conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO TB_TAREFAS (Titulo, Descricao, Feito, Desfeito) VALUES (@Titulo, @Descricao, @Feito, @Desfeito)", Conn);
                AdicionarParametros(cmd, tarefa);
                cmd.ExecuteNonQuery();
            }
        }
        public void AtualizarTarefa(Tarefa tarefa)
        {
            using (MySqlConnection Conn = new MySqlConnection(_connectionString))
            {
                Conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE TB_TAREFAS SET Titulo = @Titulo, Descricao = @Descricao, Feito = @Feito, Desfeito = @Desfeito Where Tarefa_id = @Tarefa_id", Conn);
                AdicionarParametros(cmd, tarefa);
                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirTarefa(int tarefa_id)
        {
            using (MySqlConnection Conn = new MySqlConnection(_connectionString))
            {
                Conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM TB_TAREFAS WHERE Tarefa_id = @Tarefa_id", Conn);
                cmd.Parameters.AddWithValue("@Tarefa_id", tarefa_id);
                cmd.ExecuteNonQuery();
            }
        }

        public bool TarefaExiste(string titulo)
        {
            using (MySqlConnection Conn = new MySqlConnection(_connectionString))
            {
                Conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM TB_TAREFAS WHERE Titulo = @Titulo", Conn);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}