using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class RegisterViewModel
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

        [DataType(DataType.Text)]
        [Display(Name = "Perfis de usuário : ")]
        [UIHint("List")]
        public List<SelectListItem> Roles { get; set; }
        public string Cpf { get; set; }

        public string Role { get; set; }

        public RegisterViewModel()
        {
            Roles = new List<SelectListItem>();
            Roles.Add(new SelectListItem() { Value = "1", Text = "Admin" });
            Roles.Add(new SelectListItem() { Value = "2", Text = "Aluno" });
            Roles.Add(new SelectListItem() { Value = "3", Text = "Mentor" });
        }
    }
}
