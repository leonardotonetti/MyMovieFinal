using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Web.ViewModel.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Usuário")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do campo Usuario é de 50 caracteres")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Informe a Senha")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do campo Senha é de 50 caracteres")]
        public string Senha { get; set; }
    }
}
