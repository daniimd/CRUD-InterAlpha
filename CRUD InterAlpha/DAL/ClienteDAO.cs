using CRUD_InterAlpha.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CRUD_InterAlpha.DAL
{
    public class ClienteDAO
    {
        private AcessoBD bd;

        public ClienteDAO()
        {
            bd = new AcessoBD();
        }

        public int Cadastrar(ClienteDML cliente)
        {
            StringBuilder str = new StringBuilder();

            str.Append("INSERT INTO Clientes VALUES ('");
            str.Append(cliente.Nome);
            str.Append("', '");
            str.Append(cliente.CPF);
            str.Append("', '");
            str.Append(cliente.Sexo);
            str.Append("', '");
            str.Append(cliente.Endereco);
            str.Append("', '");
            str.Append(cliente.Bairro);
            str.Append("', '");
            str.Append(cliente.Telefone);
            str.Append("', '");
            str.Append(cliente.Email);
            str.Append("')");


            return bd.Executar(str.ToString());
        }

        public int Alterar(ClienteDML cliente)
        {
            StringBuilder str = new StringBuilder();

            str.Append("UPDATE Clientes SET Nome= '");
            str.Append(cliente.Nome);
            str.Append("', CPF = '");
            str.Append(cliente.CPF);
            str.Append("', Sexo= '");
            str.Append(cliente.Sexo);
            str.Append("', Endereco= '");
            str.Append(cliente.Endereco);
            str.Append("', Bairro= '");
            str.Append(cliente.Bairro);
            str.Append("', Telefone= '");
            str.Append(cliente.Telefone);
            str.Append("', Email= '");
            str.Append(cliente.Email);
            str.Append("' WHERE ClienteId=");
            str.Append(cliente.ClienteId);

            return bd.Executar(str.ToString());
        }

        public int Excluir(int id)
        {

            StringBuilder str = new StringBuilder();

            str.Append("DELETE Clientes WHERE ClienteId=");
            str.Append(id);

            return bd.Executar(str.ToString());
        }

        public ClienteDML Consultar(int id)
        {
            ClienteDML cliente = new ClienteDML();
            StringBuilder str = new StringBuilder();

            str.Append("SELECT * FROM Clientes WHERE ClienteId=");
            str.Append(id);


            DataTable dt = bd.Tabela(str.ToString());

            if (dt.Rows.Count > 0)
            {
                cliente.ClienteId = Convert.ToInt32(dt.Rows[0]["ClienteId"].ToString());
                cliente.Nome = dt.Rows[0]["Nome"].ToString();
                cliente.CPF = dt.Rows[0]["CPF"].ToString();
                cliente.Sexo = dt.Rows[0]["Sexo"].ToString();
                cliente.Endereco = dt.Rows[0]["Endereco"].ToString();
                cliente.Bairro = dt.Rows[0]["Bairro"].ToString();
                cliente.Telefone = dt.Rows[0]["Telefone"].ToString();
                cliente.Email = dt.Rows[0]["Email"].ToString();
            }
            return cliente;
        }
    }
}