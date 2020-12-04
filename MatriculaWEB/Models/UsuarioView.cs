using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class UsuarioView : BaseModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]

        public string Senha { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]

        [Display(Name = "Confirmação da senha")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "Valores não coincidem!")]
        public string ConfirmacaoSenha { get; set; }
    }
}
