using System;
using System.ComponentModel.DataAnnotations;

namespace AppExercicio.Models
{
    public class Usuario
    {
        [Display (Name = "Código")]
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display (Name = "Observação")]
        public string Observacao { get; set; }

        [Display (Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        [Display (Name = "E-mail")]
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
