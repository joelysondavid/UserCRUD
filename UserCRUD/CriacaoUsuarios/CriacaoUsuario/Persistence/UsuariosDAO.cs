using CriacaoUsuarios.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CriacaoUsuarios.Persistence
{
    public class UsuariosDAO
    {


        SqlConnection connection = DBConnection.DB_Connection;

        // obter usuario pelo id
        public Usuario GetById(int? id)
        {
            Usuario usuario = new Usuario();
            var command = new SqlCommand("SELECT Id, Nome, Email, Senha, ConfirmaSenha FROM Usuarios WHERE Id = @Id",connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    usuario.Id = reader.GetInt32(0);
                    usuario.Nome = reader.GetString(1);
                    usuario.Email = reader.GetString(2);
                    usuario.Senha = reader.GetString(3);
                    usuario.ConfimaSenha = reader.GetString(4);
                }
            }
            connection.Close();
            return usuario;
        }
        // obtendo todos os usuarios
        public IList<Usuario> GetAll()
        {
            // lista de usuarios
            IList<Usuario> usuarios = new List<Usuario>();
            // cria uma query adapter para executar o comando de seleção de usuários
            var adapter = new SqlDataAdapter("SELECT Id, Nome, Email, Senha, ConfirmaSenha FROM Usuarios", connection);
            var builder = new SqlCommandBuilder(adapter); // buida "executa" o comando
            // cria uma data table
            var table = new DataTable();
            // filtra os dados que foram recebidos na execução do build e passa para a table
            adapter.Fill(table);            
            connection.Close(); // fecha aconexao (sempre que o "build" é realizado ele automaticamente abre a conexao e a executa temos de fechar apos o filtro)
            for(int i = 0; i<table.Rows.Count; i++)
            {
                var row = table.Rows[i]; // cria uma variavel que recebe cada linha da table
                usuarios.Add(new Usuario {
                    Id=Convert.ToInt32(row["Id"]), // converte o dado contido na coluna Id em inteiro
                    Nome=(string)row["Nome"], // realiza um cast no dado da coluna nome para string
                    Email=(string)row["Email"],
                    Senha=(string)row["Senha"],
                    ConfimaSenha=(string)row["ConfirmaSenha"]
                });

            }
            return usuarios;
        }

        // método que identificara se é uma inserção ou atualiação
        public void Save(Usuario usuario)
        {
            // caso id for diferente de vázio será uma atualização
            if (usuario.Id != null)
                Update(usuario);
            // caso constáro é uma inserção
            else
                Insert(usuario);
        }
        // método para inserção de dados na tabela de usuario
        public void Insert(Usuario usuario)
        {
            // comando para inserir dados na tabela de usuarios
            var command = new SqlCommand("INSERT INTO Usuarios (Nome, Email, Senha, ConfirmaSenha) VALUES (@Nome, @Email, @Senha, @ConfirmaSenha)", connection);
            // add os parametros que foram passados
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@ConfirmaSenha", usuario.ConfimaSenha);
            // abre a conexão para executar o comando
            connection.Open(); 
            command.ExecuteNonQuery();
            connection.Close();
        }
        // método para atualização dos dados do usuário
        public void Update(Usuario usuario)
        {            
            // comando para atualizar dados na tabela de usuarios
            var command = new SqlCommand("UPDATE Usuarios SET Nome=@Nome, Email=@Email, Senha=@Senha, ConfirmaSenha=@ConfirmaSenha WHERE Id = @Id", connection);
            // adicionando os parametros passados
            command.Parameters.AddWithValue("@Id", usuario.Id);
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@ConfirmaSenha", usuario.ConfimaSenha);
            // abre a conexão para executar o comando
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        // comando para apagar um usuário da tabela
        public void Delete(int id)
        {
            // comando para deltar
            var command = new SqlCommand("DELETE Usuarios WHERE Id=@Id", this.connection);
            command.Parameters.AddWithValue("@Id", id); // parametro do Id
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}