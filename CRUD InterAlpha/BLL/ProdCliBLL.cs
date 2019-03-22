using CRUD_InterAlpha.DAL;
using CRUD_InterAlpha.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_InterAlpha.BLL
{
    public class ProdCliBLL
    {
        private ProdCliDAO dao;

        public ProdCliBLL()
        {
            dao = new ProdCliDAO();
        }

        public int Cadastrar(ProdCliDML prodcli)
        {
            return dao.Cadastrar(prodcli);
        }

        public int Alterar(ProdCliDML prodcli)
        {
            return dao.Alterar(prodcli);
        }

        public int Excluir(int id)
        {
            return dao.Excluir(id);
        }

        public ProdCliDML Consultar(int id)
        {
            return dao.Consultar(id);
        }
    }
}