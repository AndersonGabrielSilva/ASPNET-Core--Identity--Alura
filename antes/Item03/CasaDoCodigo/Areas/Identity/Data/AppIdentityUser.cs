using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Identity;

namespace CasaDoCodigo.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppIdentityUser class
    public class AppIdentityUser : IdentityUser
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

        internal void AtualizaEndereco(Cadastro cadastro)
        {
            Bairro = cadastro.Bairro;
            Complemento = cadastro.Complemento;
            Email = cadastro.Email;
            Endereco = cadastro.Endereco;
            Municipio = cadastro.Municipio;
            Nome = cadastro.Nome;
            Telefone = cadastro.Telefone;
            Uf = cadastro.UF;
        }
    }
}
