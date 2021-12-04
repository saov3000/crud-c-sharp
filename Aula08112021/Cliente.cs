using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula08112021
{
    class Cliente
    {
        private int codigo;
        private string nome;
        private string cidade;
        private string estado;

        public Cliente() { }

        public Cliente(int codigo, string nome, string cidade, string estado)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.cidade = cidade;
            this.estado = estado;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Estado { get => estado; set => estado = value; }

        public bool cadastrar()
        {
            try
            {
                MySqlConnection con = Conexao.conectar();
                string inserir = $"INSERT INTO cliente VALUES(0,'{this.nome}','{this.cidade}','{this.estado}')";
                MySqlCommand comando = new MySqlCommand(inserir, con);
                comando.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public System.Data.DataTable listar()
        {
            try
            {
                MySqlConnection con = Conexao.conectar();
                string listar = "SELECT * FROM cliente";
                MySqlDataAdapter objDadosEmMemoria = new MySqlDataAdapter(listar, con);
                System.Data.DataTable tabelaDeDados = new System.Data.DataTable();
                objDadosEmMemoria.Fill(tabelaDeDados);
                con.Close();
                return tabelaDeDados;
            }
            catch (MySqlException e)
            {
                return null;
            }
        }

        public Cliente listarPorCodigo(int id)
        {
            try
            {
                MySqlConnection con = Conexao.conectar();
                string listar = "SELECT * FROM cliente WHERE codigo = " + id;
                MySqlCommand comando = new MySqlCommand(listar, con);
                var resposta = comando.ExecuteReader();
                Cliente c = new Cliente();
                resposta.Read();
                c.Codigo = Convert.ToInt32(resposta.GetString("codigo"));
                c.Nome = resposta.GetString("nome");
                c.Cidade = resposta.GetString("cidade");
                c.Estado = resposta.GetString("estado");
                return c;
            }
            catch (MySqlException e)
            {
                return null;
            }
        }

        public bool atualizar()
        {
            try
            {
                MySqlConnection con = Conexao.conectar();
                string update = $"UPDATE Cliente SET nome='{this.nome}',cidade='{this.cidade}',estado='{this.estado}' WHERE codigo={this.codigo}";
                MySqlCommand comando = new MySqlCommand(update, con);
                comando.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public bool deletar(int id)
        {
            try
            {
                MySqlConnection con = Conexao.conectar();
                string delete = "DELETE FROM Cliente WHERE codigo =" + id;
                MySqlCommand comando = new MySqlCommand(delete, con);
                comando.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
    }
}
