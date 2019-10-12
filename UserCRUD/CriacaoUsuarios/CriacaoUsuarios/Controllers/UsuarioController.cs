using CriacaoUsuarios.Models;
using CriacaoUsuarios.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CriacaoUsuarios.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuariosDAO repo = new UsuariosDAO();
        // Lista com Usuarios
        private static IList<Usuario> usuarios = new List<Usuario>();
        public void GetAll()
        {
           usuarios = repo.GetAll();
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ValidaUsuario(usuario))
            {
                // usuarios.Add(usuario);
                this.repo.Save(usuario);
                // usuario.Id = usuarios.Select(m => m.Id).Max() + 1;
                GetAll();
                return RedirectToAction("Index");
            }
            ViewBag.Alerta = "Todos os dados devem ser preenchidos corretamente!";
            return View("Create");
        }
        // GET: Edit
        public ActionResult Edit(int id)
        {
            return View (usuarios.Where(m => m.Id == id).First());
        }
        // Update Usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ValidaUsuario(usuario))
            {
                this.repo.Save(usuario);
                GetAll();
                return RedirectToAction("Index");
            }
            return Content("Todos os dados devem ser informados");
        }
        // Delete: Usuario:id
        public ActionResult Delete(int id)
        {
            this.repo.Delete(id);
            GetAll();
            return this.RedirectToAction("Index");
        }

        // GET: Usuario
        public ActionResult Index()
        {
            GetAll();
            return View(usuarios.OrderBy(u=>u.Nome));
        }
        // GET: Usuario:Id
        public ActionResult Details(int id)
        {
            return View(usuarios.Where(m => m.Id == id).First());
        }



        // métodos auxiliares
        // Valida usuario
        public bool ValidaUsuario(Usuario usuario)
        {
            if ((usuario.Nome != null && usuario.Email != null && usuario.Senha != null && usuario.ConfimaSenha != null) && (usuario.Senha.Length>=4 && usuario.Senha.Length <= 10 ) && (usuario.Senha == usuario.ConfimaSenha))
            {
                return true;
            }
            return false;
        }
    }
}
