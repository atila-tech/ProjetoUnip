using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoUnipWeb.Models.Cadastros
{
    public class UsuarioViewModel
    {
        public long Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Login obrigatória"), MaxLength(30)]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha obrigatória"), MaxLength(30)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirmação de Senha obrigatória"), MaxLength(30)]
        [Display(Name = "Confirmação")]
        public string ConfirmacaoSenha { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "E-mail Obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public long PerfilId { get; set; }
        public PerfilViewModel Perfil { get; set; }
    }
}