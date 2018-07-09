using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;

namespace MyMovie.Web.ViewModel.Usuario
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Informe o Usuário")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do campo Usuario é de 50 caracteres")]
        public string User { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do campo Senha é de 50 caracteres")]
        [MinLength(5, ErrorMessage = "A senha precisa ter no mínimo 5 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do campo Email é de 50 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido! Exemplo de Email válido: usuario@email.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirme a Senha")]
        [Compare("Senha", ErrorMessage = "Os campos Senha e Confirmar Senha devem ser iguais")]
        public string ConfirmarSenha { get; set; }
    }
}
