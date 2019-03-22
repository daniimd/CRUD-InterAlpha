using CRUD_InterAlpha.DAL;
using CRUD_InterAlpha.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_InterAlpha.BLL
{
    public class ClienteBLL
    {
        private ClienteDAO dao;

        public ClienteBLL()
        {
            dao = new ClienteDAO();
        }

        public int Cadastrar(ClienteDML cliente)
        {
            return dao.Cadastrar(cliente);
        }

        public int Alterar(ClienteDML cliente)
        {
            return dao.Alterar(cliente);
        }

        public int Excluir(int id)
        {
            return dao.Excluir(id);
        }

        public ClienteDML Consultar(int id)
        {
            return dao.Consultar(id);
        }
    }
}