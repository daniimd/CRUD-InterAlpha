using CRUD_InterAlpha.BLL;
using CRUD_InterAlpha.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_InterAlpha
{
    public partial class ProdCli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AlimentarComboBox();
                HabilitaCampo();
                LimpaTela();
            }
        }

        private void AlimentarComboBox()
        {
            Array tipoOperacao = Enum.GetValues(typeof(eTipoOperacao));
            foreach (var item in tipoOperacao)
            {
                ddlTipoOperacao.Items.Add(new ListItem(item.ToString()));
            }
        }

        protected void ddlTipoOperacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperacaoSelecionada();
            HabilitaCampo();
            LimpaTela();
        }

        private void OperacaoSelecionada()
        {
            if (ddlTipoOperacao.SelectedIndex == 0)
                txtClienteNome.Focus();
            else
                txtClienteId.Focus();
        }
        private void Mensagem(string mensagem)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + mensagem + "');", true);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            ProdCliDML prodcli = new ProdCliDML();
            ProdCliBLL bll = new ProdCliBLL();


            if (txtProdCliId.Text != "")
                prodcli.ProdCliId = Convert.ToInt32(txtProdCliId.Text);

            prodcli.ProdutoId = Convert.ToInt32(txtProdutoId.Text);
            prodcli.ClienteId = Convert.ToInt32(txtClienteId.Text);

            int resultado = -1;

            if (ddlTipoOperacao.SelectedIndex == 0)
            {
                resultado = bll.Cadastrar(prodcli);
                if (resultado > -1)
                    Mensagem("Cliente vinculado ao produto com sucesso!");
                else
                    Mensagem("Falha ao tentar vincular cliente ao produto!");
            }
            else if (ddlTipoOperacao.SelectedIndex == 1)
            {
                resultado = bll.Alterar(prodcli);
                if (resultado > -1)
                    Mensagem("Cliente vinculado ao produto foi alterado com sucesso!");
                else
                    Mensagem("Falha ao tentar alterar cliente vinculado ao produto!");
            }
            else if (ddlTipoOperacao.SelectedIndex == 2)
            {
                resultado = bll.Excluir(prodcli.ProdCliId);
                if (resultado > -1)
                    Mensagem("Cliente vinculado ao produto foi excluído com sucesso!");
                else
                    Mensagem("Falha ao tentar excluir cliente vinculado ao produto!");
            }
            else if (ddlTipoOperacao.SelectedIndex == 3)
                bll.Consultar(prodcli.ProdCliId);

            LimpaTela();
        }

        protected void txtProdCliId_TextChanged(object sender, EventArgs e)
        {
            ProdCliDML prodcli = new ProdCliDML();
            ProdCliBLL bll = new ProdCliBLL();
            ProdutoBLL produtobll = new ProdutoBLL();
            ProdutoDML produto = new ProdutoDML();
            ClienteBLL clientebll = new ClienteBLL();
            ClienteDML cliente = new ClienteDML();

            if (ddlTipoOperacao.SelectedIndex != 0)
            {
                prodcli = bll.Consultar(Convert.ToInt32(txtProdCliId.Text));


                cliente = clientebll.Consultar(Convert.ToInt32(prodcli.ClienteId));

                produto = produtobll.Consultar(Convert.ToInt32(prodcli.ProdutoId));

                if (cliente.Nome != null)
                {
                    txtClienteNome.Text = cliente.Nome;
                    txtClienteId.Text = cliente.ClienteId.ToString();
                }

                if (produto.Nome != null)
                {
                    txtProdutoNome.Text = produto.Nome;
                    txtProdutoId.Text = produto.ProdutoId.ToString();
                }
            }
        }

        private void HabilitaCampo()
        {
            if (ddlTipoOperacao.SelectedIndex == 0)
            {
                txtClienteId.Enabled = true;
                txtClienteNome.Enabled = false;
                txtProdutoId.Enabled = true;
                txtProdutoNome.Enabled = false;
                txtProdCliId.Enabled = false;
            }
            else if (ddlTipoOperacao.SelectedIndex == 1)
            {
                txtClienteId.Enabled = true;
                txtClienteNome.Enabled = false;
                txtProdutoId.Enabled = true;
                txtProdutoNome.Enabled = false;
                txtProdCliId.Enabled = true;
            }
            else
            {
                txtClienteId.Enabled = false;
                txtClienteNome.Enabled = false;
                txtProdutoId.Enabled = false;
                txtProdutoNome.Enabled = false;
                txtProdCliId.Enabled = true;
            }
        }
        private void LimpaTela()
        {
            txtProdCliId.Text = "";
            txtProdutoId.Text = "";
            txtProdutoNome.Text = "";
            txtClienteId.Text = "";
            txtClienteNome.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            LimpaTela();

            if (ddlTipoOperacao.SelectedIndex == 0)
                txtClienteNome.Focus();
            else
                txtProdCliId.Focus();
        }

        protected void txtClienteId_TextChanged(object sender, EventArgs e)
        {
            ClienteBLL clientebll = new ClienteBLL();
            ClienteDML cliente = new ClienteDML();

            if (txtClienteId.Text != "")
            {
                cliente = clientebll.Consultar(Convert.ToInt32(txtClienteId.Text));
                txtClienteNome.Text = cliente.Nome;
            }
        }

        protected void txtProdutoId_TextChanged(object sender, EventArgs e)
        {
            ProdutoBLL produtobll = new ProdutoBLL();
            ProdutoDML produto = new ProdutoDML();

            if (txtProdutoId.Text != "")
            {
                produto = produtobll.Consultar(Convert.ToInt32(txtProdutoId.Text));
                txtProdutoNome.Text = produto.Nome;
            }
        }
    }
}