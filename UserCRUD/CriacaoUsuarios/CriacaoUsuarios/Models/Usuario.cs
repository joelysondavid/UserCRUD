using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriacaoUsuarios.Models
{
    public class Usuario
    {
        // Propriedades do usuário
        public int? Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatório!")]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigadótio!")]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório!")]
        [StringLength(10, MinimumLength = 4/*, ErrorMessage = "O campo deve conter entre 4 e 10 caracteres"*/)]
        [Display(Name="Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(10, MinimumLength = 4/*, ErrorMessage = "O campo deve conter entre 4 e 10 caracteres"*/)]
        [Display(Name = "Confirma Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Confirmação de senha diferente da senha!")]
        public string ConfimaSenha { get; set; }

        public Usuario()
        {
            this.Id = null;
        }
    }
}