using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnipWeb.Domain.Person
{
    public class Paciente
    {
        public long Id { get; set; }
        public string NumeroConvenio { get; set; }
        public long? PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
