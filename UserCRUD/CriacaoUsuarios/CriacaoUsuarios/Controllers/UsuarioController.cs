using CriacaoUsuarios.Models;
using CriacaoUsuarios.Persistence;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CriacaoUsuarios.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuariosDAO repo = new UsuariosDAO();
        // Lista com Usuarios
        private static IList<Usuario> usuarios = new List<Usuario>()
            {
                new Usuario()
                {
                    Id=1,
                    Nome="Joe",
                    Email="Joe.dav@gmail.com",
                    Senha="123",
                    ConfimaSenha="123"
                },
                new Usuario()
                {
                    Id=2,
                    Nome="Joe",
                    Email="Joe.dav@gmail.com",
                    Senha="123",
                    ConfimaSenha="123"
                },
                new Usuario()
                {
                    Id=3,
                    Nome="Joe",
                    Email="Joe.dav@gmail.com",
                    Senha="123",
                    ConfimaSenha="123"
                },
            };

        public void GetAll()
        {
            usuarios = repo.GetAll();
        }

        public void Insert()
        {
            Usuario user = this.repo.GetById(1);
            usuarios.Add(user);
        }
        

        // GET: Usuario
        public ActionResult Index()
        {
            Insert();
            return View(usuarios);
        }
    }
}
