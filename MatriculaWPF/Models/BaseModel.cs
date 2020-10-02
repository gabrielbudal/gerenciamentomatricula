using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatriculaWPF.Models
{
    class BaseModel
    {
        public BaseModel()
        {
            CriadoEm = DateTime.Now;
            Ativo = true;
        }
        [Key]
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public Boolean Ativo { get; set; }
    }
}
