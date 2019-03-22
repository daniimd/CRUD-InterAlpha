using CRUD_InterAlpha.BLL;
using CRUD_InterAlpha.DML;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_InterAlpha
{
    public partial class Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AlimentarComboBox();
                AlimentarComboTipoProduto();
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
                txtNome.Focus();
            else
                txtProdutoId.Focus();
        }

        private void Mensagem(string mensagem)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + mensagem + "');", true);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            {
                ProdutoDML produtos = new ProdutoDML();
                ProdutoBLL produtoBLL = new ProdutoBLL();
                
                if (txtProdutoId.Text != "")
                    produtos.ProdutoId = Convert.ToInt32(txtProdutoId.Text);

                produtos.Nome = txtNome.Text;
                CultureInfo culture = new CultureInfo("pt-BR");
                produtos.Preco = Convert.ToDecimal(txtPreco.Text, culture);
                produtos.Descricao = txtDescricao.Text;
                produtos.Tipo = ddlTipoProduto.Text;

                int resultado = -1;

                if (ddlTipoOperacao.SelectedIndex == 0)
                {
                    resultado = produtoBLL.Cadastrar(produtos);
                    if (resultado > -1)
                        Mensagem("Produto foi cadastrado com sucesso!");
                    else
                        Mensagem("Falha ao tentar incluir o produto!");
                }

                else if (ddlTipoOperacao.SelectedIndex == 1)
                {
                    resultado = produtoBLL.Alterar(produtos);
                    if (resultado > -1)
                        Mensagem("Produto foi alterado com sucesso!");
                    else
                        Mensagem("Falha ao tentar alterar o produto!");
                }
                else if (ddlTipoOperacao.SelectedIndex == 2)
                {
                    resultado = produtoBLL.Excluir(produtos.ProdutoId);
                    if (resultado > -1)
                        Mensagem("Produto foi excluído com sucesso!");
                    else
                        Mensagem("Falha ao tentar excluir o produto!");
                }
                else if (ddlTipoOperacao.SelectedIndex == 3)
                    produtoBLL.Consultar(produtos.ProdutoId);
                
                LimpaTela();
            }
        }

        protected void txtProdutoId_TextChanged(object sender, EventArgs e)
        {
            ProdutoDML produto = new ProdutoDML();
            ProdutoBLL bll = new ProdutoBLL();

            if (ddlTipoOperacao.SelectedIndex != 0)
            {
                produto = bll.Consultar(Convert.ToInt32(txtProdutoId.Text));
                txtNome.Text = produto.Nome;
                txtDescricao.Text = produto.Descricao;
                txtPreco.Text = Convert.ToDecimal(produto.Preco).ToString();
                ddlTipoProduto.Text = produto.Tipo;
            }

        }

        private void HabilitaCampo()
        {
            if (ddlTipoOperacao.SelectedIndex == 0)
            {
                txtProdutoId.Enabled = false;
                txtNome.Enabled = true;
                txtDescricao.Enabled = true;
                txtPreco.Enabled = true;
                ddlTipoProduto.Enabled = true;

            }
            else if (ddlTipoOperacao.SelectedIndex == 1)
            {
                txtProdutoId.Enabled = true;
                txtNome.Enabled = true;
                txtDescricao.Enabled = true;
                txtPreco.Enabled = true;
                ddlTipoProduto.Enabled = true;
            }
            else
            {
                txtProdutoId.Enabled = true;
                txtNome.Enabled = false;
                txtDescricao.Enabled = false;
                txtPreco.Enabled = false;
                ddlTipoProduto.Enabled = false;
            }
        }

        private void LimpaTela()
        {
            txtProdutoId.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
        }

        private void AlimentarComboTipoProduto()
        {
            Array tipoProduto = Enum.GetValues(typeof(eTipoProduto));
            foreach (var item in tipoProduto)
            {
                ddlTipoProduto.Items.Add(new ListItem(item.ToString()));
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            LimpaTela();

            if (ddlTipoOperacao.SelectedIndex == 0)
                txtNome.Focus();
            else
                txtProdutoId.Focus();
        }
    }
}
