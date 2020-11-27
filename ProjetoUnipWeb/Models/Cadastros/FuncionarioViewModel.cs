using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoUnipWeb.Models.Cadastros
{
    public class FuncionarioViewModel
    {
        public long Id { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Por favor, digite seu Salário"), MaxLength(30)]
        [Display(Name = "Salário")]
        public string Salario { get; set; }
        public bool Terceirizado { get; set; }
        public long CargoId { get; set; }
        public CargoViewModel Cargo { get; set; }
        public long PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }
    }
}