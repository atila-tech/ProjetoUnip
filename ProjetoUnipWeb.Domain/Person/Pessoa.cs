﻿using ProjetoUnipWeb.Domain.Address;
using ProjetoUnipWeb.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnipWeb.Domain.Person
{
    public class Pessoa
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
