using System.ComponentModel.DataAnnotations;

namespace AppExercicio.Models
{
    public class Funcionario
    {
        [Display (Name = "Código")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
    }
}
