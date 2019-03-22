using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_InterAlpha.DML
{
    public class ProdutoDML
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Tipo { get; set; }
    }
}
