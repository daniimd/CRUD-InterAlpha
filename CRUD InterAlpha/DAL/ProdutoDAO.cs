using CRUD_InterAlpha.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace CRUD_InterAlpha.DAL
{
    public class ProdutoDAO
    {
        private AcessoBD bd;

        public ProdutoDAO()
        {
            bd = new AcessoBD();
        }

        public int Cadastrar(ProdutoDML produto)
        {
            StringBuilder str = new StringBuilder();

            str.Append("INSERT INTO Produtos VALUES ('");
            str.Append(produto.Nome);
            str.Append("', '");
            str.Append(produto.Descricao);
            str.Append("', ");
            str.Append(produto.Preco.ToString(new CultureInfo("en-US")));
            str.Append(", '");
            str.Append(produto.Tipo);
            str.Append("')");


            return bd.Executar(str.ToString());
        }

        public int Alterar(ProdutoDML produto)
        {
            StringBuilder str = new StringBuilder();

            str.Append("UPDATE Produtos SET Nome= '");
            str.Append(produto.Nome);
            str.Append("', Descricao = '");
            str.Append(produto.Descricao);
            str.Append("', Preco=");
            str.Append(produto.Preco.ToString(new CultureInfo("en-US")));
            str.Append(", Tipo= '");
            str.Append(produto.Tipo);
            str.Append("' WHERE ProdutoId=");
            str.Append(produto.ProdutoId);

            return bd.Executar(str.ToString());
        }

        public int Excluir(int id)
        {

            StringBuilder str = new StringBuilder();

            str.Append("DELETE Produtos WHERE ProdutoId=");
            str.Append(id);

            return bd.Executar(str.ToString());
        }

        public ProdutoDML Consultar(int id)
        {
            ProdutoDML produto = new ProdutoDML();
            StringBuilder str = new StringBuilder();

            str.Append("SELECT * FROM Produtos WHERE ProdutoId=");
            str.Append(id);


            DataTable dt = bd.Tabela(str.ToString());

            if (dt.Rows.Count > 0)
            {
                produto.ProdutoId = Convert.ToInt32(dt.Rows[0]["ProdutoId"].ToString());
                produto.Nome = dt.Rows[0]["Nome"].ToString();
                produto.Descricao = dt.Rows[0]["Descricao"].ToString();
                produto.Preco = Convert.ToDecimal(dt.Rows[0]["Preco"].ToString());
                produto.Tipo = dt.Rows[0]["Tipo"].ToString();
            }
            return produto;
        }
    }
}