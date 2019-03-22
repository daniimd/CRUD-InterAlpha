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
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AlimentarComboBox();
                AlimentarComboSexo();
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
                txtClienteId.Focus();
        }

        private void Mensagem(string mensagem)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + mensagem + "');", true);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            ClienteDML clientes = new ClienteDML();
            ClienteBLL clienteBLL = new ClienteBLL();

            if (txtClienteId.Text != "")
                clientes.ClienteId = Convert.ToInt32(txtClienteId.Text);

            clientes.Nome = txtNome.Text;
            clientes.CPF = txtCPF.Text;
            clientes.Sexo = ddlSexo.Text;
            clientes.Endereco = txtEndereco.Text;
            clientes.Bairro = txtBairro.Text;
            clientes.Telefone = txtTelefone.Text;
            clientes.Email = txtEmail.Text;

            int resultado = -1;

            if (ddlTipoOperacao.SelectedIndex == 0)
            {
                resultado = clienteBLL.Cadastrar(clientes);
                if ( resultado > -1 )
                    Mensagem("Cliente foi cadastrado com sucesso!");
                else
                    Mensagem("Falha ao tentar excluir o cliente!");
            }
            else if (ddlTipoOperacao.SelectedIndex == 1)
            {
                resultado = clienteBLL.Alterar(clientes);
                if (resultado > -1)
                    Mensagem("Cliente foi alterado com sucesso!");
                else
                    Mensagem("Falha ao tentar alterar o cliente!");
            }
            else if (ddlTipoOperacao.SelectedIndex == 2)
            {
                resultado = clienteBLL.Excluir(clientes.ClienteId);
                if (resultado > -1)
                    Mensagem("Cliente foi excluído com sucesso!");
                else
                    Mensagem("Falha ao tentar excluir o cliente!");
            }
            else if (ddlTipoOperacao.SelectedIndex == 3)
                clienteBLL.Consultar(clientes.ClienteId);

            LimpaTela();
        }

        protected void txtClienteId_TextChanged(object sender, EventArgs e)
        {
            ClienteDML cliente = new ClienteDML();
            ClienteBLL bll = new ClienteBLL();

            if (ddlTipoOperacao.SelectedIndex != 0)
            {
                cliente = bll.Consultar(Convert.ToInt32(txtClienteId.Text));
                txtNome.Text = cliente.Nome;
                txtCPF.Text = cliente.CPF;
                ddlSexo.Text = cliente.Sexo;
                txtEndereco.Text = cliente.Endereco;
                txtBairro.Text = cliente.Bairro;
                txtTelefone.Text = cliente.Telefone;
                txtEmail.Text = cliente.Email;
            }

        }

        private void HabilitaCampo()
        {
            if (ddlTipoOperacao.SelectedIndex == 0)
            {
                txtClienteId.Enabled = false;
                txtNome.Enabled = true;
                txtCPF.Enabled = true;
                ddlSexo.Enabled = true;
                txtEndereco.Enabled = true;
                txtBairro.Enabled = true;
                txtTelefone.Enabled = true;
                txtEmail.Enabled = true;
            }
            else if (ddlTipoOperacao.SelectedIndex == 1)
            {
                txtClienteId.Enabled = true;
                txtNome.Enabled = true;
                txtCPF.Enabled = true;
                ddlSexo.Enabled = true;
                txtEndereco.Enabled = true;
                txtBairro.Enabled = true;
                txtTelefone.Enabled = true;
                txtEmail.Enabled = true; ;
            }
            else
            {
                txtClienteId.Enabled = true;
                txtNome.Enabled = false;
                txtNome.Enabled = false;
                txtCPF.Enabled = false;
                ddlSexo.Enabled = false;
                txtEndereco.Enabled = false;
                txtBairro.Enabled = false;
                txtTelefone.Enabled = false;
                txtEmail.Enabled = false;
            }
        }

        private void LimpaTela()
        {
            txtClienteId.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
        }

        private void AlimentarComboSexo()
        {
            Array tipoSexo = Enum.GetValues(typeof(eTipoSexo));
            foreach (var item in tipoSexo)
            {
                ddlSexo.Items.Add(new ListItem(item.ToString()));
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
                txtClienteId.Focus();
        }
    }
}
