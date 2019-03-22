using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CRUD_InterAlpha.DAL
{
    public class AcessoBD
    {
        public SqlConnection Acesso()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["localHost"].ConnectionString);

                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                return conn;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public int Executar(string query)
        {
            using (SqlConnection conexao = Acesso())
            {
                SqlCommand comando = new SqlCommand(query);
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexao;

                return comando.ExecuteNonQuery();
            }
        }

        public DataTable Tabela(string table)
        {
            using (SqlConnection conexao = Acesso())
            {
                SqlCommand comando = new SqlCommand(table);
                comando.CommandType = CommandType.Text;
                comando.Connection = conexao;

                DataTable dt = new DataTable();
                dt.Load(comando.ExecuteReader());

                return dt;
            }
        }
    }
}