using ProjetoUnipWeb.Domain.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnipWeb.Domain.Util
{
    public class MedicoConsulta
    {
        public long ConsultaId { get; set; }
        public Consulta Consulta { get; set; }
        public long MedicoId { get; set; }
        public Medico Medico { get; set; }
        public string Tratamento { get; set; }
    }
}
