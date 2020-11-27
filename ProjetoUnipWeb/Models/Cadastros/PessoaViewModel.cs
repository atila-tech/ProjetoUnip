using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoUnipWeb.Models.Cadastros
{
    public class PessoaViewModel
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[Required(ErrorMessage = "Data de Nascimento Obrigatória"), MaxLength(30)]
        [Display(Name = "Nascimento")]
        public string DataNascimento { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Por favor, digite seu Nome"), MaxLength(30)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Rg")]
        public string Rg { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "CPF Obrigatório"), MaxLength(30)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public long UsuarioId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public List<EnderecoViewModel> Enderecos { get; set; }
    }
}