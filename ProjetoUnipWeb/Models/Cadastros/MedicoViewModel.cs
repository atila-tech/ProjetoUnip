using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoUnipWeb.Models.Cadastros
{
    public class MedicoViewModel
    {
        public long Id { get; set; }
        public string Crm { get; set; }
        public long EspecialidadeId { get; set; }
        public EspecialidadeViewModel Especialidade { get; set; }
        public long? PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }
    }
}