using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoUnipWeb.Models.Cadastros
{
    public class PacienteViewModel
    {
        public long Id { get; set; }
        public string NumeroConvenio { get; set; }
        public long? PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }
    }
}