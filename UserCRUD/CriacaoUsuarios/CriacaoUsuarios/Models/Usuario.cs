using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriacaoUsuarios.Models
{
    public class Usuario
    {
        // Propriedades do usuário
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfimaSenha { get; set; }
    }
}