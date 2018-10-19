using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfessorSite
{
    public partial class Professor
    {
        public string getTitulacaoDescricao
        {
            get
            {
                return this.Titulacao.Descricao;
            }
        }
    }
}