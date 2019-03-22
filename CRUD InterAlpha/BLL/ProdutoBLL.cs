using CRUD_InterAlpha.DAL;
using CRUD_InterAlpha.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_InterAlpha.BLL
{
    public class ProdutoBLL
    {
        private ProdutoDAO dao;

        public ProdutoBLL()
        {
            dao = new ProdutoDAO();
        }

        public int Cadastrar(ProdutoDML produto)
        {
            return dao.Cadastrar(produto);
        }

        public int Alterar(ProdutoDML produto)
        {
            return dao.Alterar(produto);
        }

        public int Excluir(int id)
        {
            return dao.Excluir(id);
        }

        public ProdutoDML Consultar(int id)
        {
            return dao.Consultar(id);
        }
    }
}