using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using PrjEcommersProyect.DAO;
using PrjEcommersProyect.Models;
using System.Data;

using System.Data.SqlClient;


namespace PrjEcommersProyect.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO dao;

        public UsuarioController(UsuarioDAO usu)
        {
            dao = usu;
        }

        #region VALIDARINGRESO
        //GET
        public IActionResult ValidarIngreso()
        {
            return View();
        }


        //POST
        [HttpPost]
        public IActionResult ValidarIngreso(Usuario obj)
        {
            if (ModelState.IsValid)
            {
                string mensaje = dao.Validar_Usuario(obj);
                if (mensaje[0].ToString() == "B")
                {
                    TempData["mensaje"] = mensaje;
                    return RedirectToAction("ListaProductos", "Producto");
                }
                else
                    ViewBag.mensaje = mensaje;
            }

            return View(obj);

        }
        #endregion

        // GET: UsuarioController/Create
        public ActionResult CreateUsuario()
        {
            Usuario nuevo =new Usuario();

            return View(nuevo);
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsuario(Usuario obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] = dao.GrabarUsuario(obj);
                    return RedirectToAction(nameof(ValidarIngreso));
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = "Error" + ex.Message;
            }
            return View(obj);
            }
        }
    }
