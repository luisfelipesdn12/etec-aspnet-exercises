using System;
using System.ComponentModel.DataAnnotations;

namespace AppExercicio.Models
{
    public class Usuario
    {
        [Display (Name = "Código")]
        [Required (ErrorMessage = "O campo é obrigatório")]
        [Range (1, 200, ErrorMessage = "Deve ser um número entre 1 e 200")]
        public int? Id { get; set; }

        [Required (ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Display (Name = "Observação")]
        [StringLength (50, MinimumLength = 5, ErrorMessage = "O campo deve ter entre 5 e 50 caracteres")]
        public string Observacao { get; set; }

        [DataType (DataType.Date)]
        [Display (Name = "Data de Nascimento")]
        [Required (ErrorMessage = "A data de nascimento é obrigatória")]
        [DisplayFormat (DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataDeNascimento { get; set; }

        [Display (Name = "E-mail")]
        [Required (ErrorMessage = "Informe o e-mail")]
        [EmailAddress (ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Informe o login")]
        public string Login { get; set; }

        [Required (ErrorMessage = "Informe a senha")]
        [Compare ("ConfirmaSenha", ErrorMessage = "As senhas devem ser iguais")]
        public string Senha { get; set; }

        [Display (Name = "Confirme a senha")]
        [Required (ErrorMessage = "Confirme a senha")]
        [Compare ("Senha", ErrorMessage = "As senhas devem ser iguais")]
        public string ConfirmaSenha { get; set; }
    }
}
