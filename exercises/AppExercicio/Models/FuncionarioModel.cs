using System.ComponentModel.DataAnnotations;

namespace AppExercicio.Models
{
    public class Funcionario
    {
        [Display (Name = "Código")]
        [Required (ErrorMessage = "O campo é obrigatório")]
        [Range (1, 200, ErrorMessage = "Deve ser um número entre 1 e 200")]
        public int? Id { get; set; }

        [Required (ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Informe o cargo")]
        public string Cargo { get; set; }
    }
}
