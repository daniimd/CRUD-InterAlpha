using CRUD_InterAlpha.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CRUD_InterAlpha.DAL
{
    public class ProdCliDAO
    {
        private AcessoBD bd;

        public ProdCliDAO()
        {
            bd = new AcessoBD();
        }

        public int Cadastrar(ProdCliDML prodcli)
        {
            StringBuilder str = new StringBuilder();

            str.Append("INSERT INTO ProdCli (ClienteId,ProdutoId) VALUES ('");
            str.Append(prodcli.ClienteId);
            str.Append("', '");
            str.Append(prodcli.ProdutoId);
            str.Append("')");

            return bd.Executar(str.ToString());
        }

        public int Alterar(ProdCliDML prodcli)
        {
            StringBuilder str = new StringBuilder();

            str.Append("UPDATE ProdCli SET ClienteId= '");
            str.Append(prodcli.ClienteId);
            str.Append("', ProdutoId ='");
            str.Append(prodcli.ProdutoId);
            str.Append("' WHERE ProdCliId=");
            str.Append(prodcli.ProdCliId);

            return bd.Executar(str.ToString());
        }

        public int Excluir(int id)
        {

            StringBuilder str = new StringBuilder();

            str.Append("DELETE ProdCli WHERE ProdCliId=");
            str.Append(id);

            return bd.Executar(str.ToString());
        }

        public ProdCliDML Consultar(int id)
        {
            ProdCliDML prodcli = new ProdCliDML();
            StringBuilder str = new StringBuilder();

            str.Append("SELECT * FROM ProdCli WHERE ProdCliId=");
            str.Append(id);

            DataTable dt = bd.Tabela(str.ToString());

            if (dt.Rows.Count > 0)
            {
                prodcli.ProdCliId = Convert.ToInt32(dt.Rows[0]["ProdCliId"].ToString());
                prodcli.ProdutoId = Convert.ToInt32(dt.Rows[0]["ProdutoId"].ToString());
                prodcli.ClienteId = Convert.ToInt32(dt.Rows[0]["ClienteId"].ToString());
            }
            return prodcli;
        }
    }
}
