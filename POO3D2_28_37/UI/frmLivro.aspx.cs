using POO3D2_28_37.BLL;
using POO3D2_28_37.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POO3D2_28_37.UI
{
    public partial class frmLivro : System.Web.UI.Page
    {
        tblLivroBLL blllivraria = new tblLivroBLL();
        tblLivroDTO dtolivraria = new tblLivroDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                this.ExibirGridLivraria();
            }
        }

        public void ExibirGridLivraria()
        {
            GridLivraria.DataSource = blllivraria.ListarLivros();
            GridLivraria.DataBind();
        }

        public void LimparCampos()
        {
            txtAutor.Text = "";
            txtEditora.Text = "";
            txtTitulo.Text = "";
            txtNumpaginas.Text = "";
            txtValor.Text = "";
            txtDataCadastro.Text = "";
        }

        protected void btn_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                dtolivraria.Id_Autor = int.Parse(txtAutor.Text);
                dtolivraria.Id_Editora = int.Parse(txtEditora.Text);
                dtolivraria.Titulo = txtTitulo.Text;
                dtolivraria.DataCadastro = DateTime.Parse(txtDataCadastro.Text);
                dtolivraria.NumeroPaginas = txtNumpaginas.Text;
                dtolivraria.Valor = double.Parse(txtValor.Text);

                // Inserir na tabela de clientes
                blllivraria.InserirLivro(dtolivraria);
                msgerro.Visible = true;
                msgerro.Text = "Livro Cadastrado com Sucesso";
                this.LimparCampos();
                this.ExibirGridLivraria();
            }
            catch (Exception ex)
            {
                msgerro.Visible = true;
                msgerro.Text = ex.Message;
            }

        }

        protected void GridLivros_RowDeleting(object sender, GridViewDeleteEventArgs Registro)
        {
            try
            {
                dtolivraria.Id_Livro = Convert.ToInt32(Registro.Values[0]);
                blllivraria.ExcluirLivro(dtolivraria);
                this.ExibirGridLivraria();
            }
            catch (Exception ex)
            {
                msgerro.Visible = true;
                msgerro.Text = ex.Message;
            }
        }

        protected void GridLivros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridLivraria.EditIndex = e.NewEditIndex;
            this.ExibirGridLivraria();
        }
        // Metodo Utilizado para Salvar a Edição dos dados do grid
        protected void GridLivros_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                dtolivraria.Titulo = e.NewValues[3].ToString();
                dtolivraria.NumeroPaginas = e.NewValues[4].ToString();
                dtolivraria.Valor = Double.Parse(e.NewValues[5].ToString());
                blllivraria.AlterarLivro(dtolivraria);
                GridLivraria.EditIndex = -1;
                this.ExibirGridLivraria();
            }
            catch (Exception ex)
            {
                msgerro.Visible = true;
                msgerro.Text = ex.Message;
            }
        }
        protected void GridLivraria_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridLivraria.EditIndex = -1;
            this.ExibirGridLivraria();
        }

        protected void GridLivraria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridLivraria.PageIndex = e.NewPageIndex;
            this.ExibirGridLivraria();
        }
    }
}