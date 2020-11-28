using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Models
{
    public class Pessoa : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(40, ErrorMessage = "Máximo de caracteres!")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(11, ErrorMessage = "Por gentileza digitar os 11 caracteres do CPF.")]
        [MinLength(11, ErrorMessage = "Por gentileza digitar os 11 caracteres do CPF.")]
        public string Cpf { get; set; }
    }
}
