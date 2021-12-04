using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula08112021
{
    class Conexao
    {
        private static MySqlConnection con;

        public static MySqlConnection conectar()
        {
            string caminho = "SERVER=localhost;DATABASE=empresa;UID=root;PASSWORD=;SSL Mode=None";
            try
            {
                con = new MySqlConnection(caminho);
                con.Open();
                return con;
            }
            catch (MySqlException e)
            {
                return null;
            }
        }
    }
}
