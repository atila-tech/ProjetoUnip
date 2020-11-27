using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoUnipWeb.Models
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Por favor, digite seu Login"), MaxLength(30)]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Por favor, digite sua Senha"), MaxLength(30)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}