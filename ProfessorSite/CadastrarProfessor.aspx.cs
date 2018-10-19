using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProfessorSite
{
    public partial class CadastrarProfessor : System.Web.UI.Page
    {
        //public static Professor ProfessorAlt { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AtualizarLvProfessores();
                PopularDDLTitulacoes();

                string qs = Request.QueryString["IdProfessor"];
                if(qs != null)
                {
                    int idProfessor = Convert.ToInt32(qs);
                    AlterarProfessor(idProfessor);
                }

            }
                
        }

        private void AlterarProfessor(int idProfessor)
        {
            try
            {
                using (var ctx = new ProfessorDBEntities())
                {
                    Professor aux = ctx.Professores.FirstOrDefault(x => x.IdProfessor == idProfessor);
                    string qs = Request.QueryString["IdProfessor"];
                    if (qs != null)
                    {
                        this.Title = "Alterar Professor";
                        this.h2_titulo.InnerText = "Alteração de Professor";
                        this.btnCadastrar.Text = "Alterar";

                        PreencherDadosNoFormulario(aux);

                    }
                    AtualizarLvProfessores();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void PreencherDadosNoFormulario(Professor aux)
        {
            txtAreaAtuacao.Text = aux.AreaAtuacao;
            txtEspecialidade.Text = aux.Especialidade;
            txtNome.Text = aux.Nome;
            ddlTitulacaoes.SelectedValue = aux.Titulacao.IdTitulacao.ToString();

        }

        private void PopularDDLTitulacoes()
        {
            try
            {
                using (var ctx =  new ProfessorDBEntities())
                {
                    //Populando o DropDownList
                    ddlTitulacaoes.DataSource = ctx.Titulacoes.ToList();
                    ddlTitulacaoes.DataTextField = "Descricao";
                    ddlTitulacaoes.DataValueField = "IdTitulacao";
                    ddlTitulacaoes.DataBind();

                    ddlTitulacaoes.Items.Insert(0, "Selecione...");
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            //cadastro usando c# (igual com windows forms)
            try
            {
                using (var ctx = new ProfessorDBEntities())
                {
                    Professor professor;
                    string qs = Request.QueryString["IdProfessor"];
                    if (qs == null)
                    {
                        professor = new Professor();
                    }
                    else
                    {
                        int idProf = Convert.ToInt32(qs);
                        professor = ctx.Professores.FirstOrDefault
                            (x => x.IdProfessor == idProf);
                    }

                    professor.Nome = txtNome.Text;
                    professor.AreaAtuacao = txtAreaAtuacao.Text;
                    professor.Especialidade = txtEspecialidade.Text;

                    if (ddlTitulacaoes.SelectedIndex > 0)
                    {
                        int idTitulacao = Convert.ToInt32(ddlTitulacaoes.SelectedValue);

                        professor.TitulacaoID = idTitulacao;

                       
                        if(qs == null)
                        {
                            ctx.Professores.Add(professor);
                        }
                            
                        ctx.SaveChanges();

                        //if (qs != null)
                        //{
                           // CadastrarProfessor.ProfessorAlt = null;
                            Response.Redirect("~/CadastrarProfessor.aspx");
                       // }
                        txtNome.Text = "";
                        txtAreaAtuacao.Text = "";
                        txtEspecialidade.Text = "";
                        ddlTitulacaoes.SelectedIndex = 0;

                        AtualizarLvProfessores();
                        this.Title = "Cadastrar Professor";
                        this.h2_titulo.InnerText = "Cadastro de Professor";
                        this.btnCadastrar.Text = "Cadastrar";
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void AtualizarLvProfessores()
        {
            try
            {
                using(var ctx = new ProfessorDBEntities())
                {
                    lvProfessores.DataSource = ctx.Professores.ToList();
                    lvProfessores.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void lvProfessores_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int idProfessor = Convert.ToInt32(e.CommandArgument);

                    using (var ctx = new ProfessorDBEntities())
                    {
                        Professor aux = ctx.Professores.FirstOrDefault(x => x.IdProfessor == idProfessor);

                        if(aux != null)
                        {
                            ctx.Professores.Remove(aux);
                            ctx.SaveChanges();
                        }
                        AtualizarLvProfessores();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}