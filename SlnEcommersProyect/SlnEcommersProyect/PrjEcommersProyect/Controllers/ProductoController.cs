using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PrjEcommersProyect.Models;
using System.Data;
using System.Data.SqlClient;

namespace PrjEcommersProyect.Controllers
{
    public class ProductoController : Controller
    {
        private readonly EcommersProyectContext db;


        public ProductoController(EcommersProyectContext ctx)
        {
            db = ctx;

        }

        List<Carrito> listaCarrito = new List<Carrito>();

        void GrabarCarrito()
        {
            HttpContext.Session.SetString("Carrito",
                JsonConvert.SerializeObject(listaCarrito));
        }

        List<Carrito> RecuperarCarrito()
        {
            return JsonConvert.DeserializeObject<List<Carrito>>(
                HttpContext.Session.GetString("Carrito")!)!;
        }




        // GET: ProductoController
        public ActionResult ListaProductos(int nropagina = 0, int? idCategoria = null)
        {
            if (HttpContext.Session.GetString("Carrito") == null)
                GrabarCarrito();

            IQueryable<Producto> query = db.Productos;

            if (idCategoria.HasValue)
            {
                query = query.Where(p => p.IdCategoria == idCategoria.Value);
            }

            var listado = query.ToList();

            int filas_pagina = 6;
            int cantidad = listado.Count;
            int paginas = (cantidad + filas_pagina - 1) / filas_pagina;  // Simplifica el cálculo de páginas
            ViewBag.PAGINAS = paginas;
            ViewBag.nropagina = nropagina;
            ViewBag.IdCategoria = idCategoria;

            // Obtener las categorías para la vista
            ViewBag.Categorias = db.Categorias.ToList();

            return View(listado.Skip(nropagina * filas_pagina).Take(filas_pagina));
        }



        // GET: ProductoController/Details/5
        public ActionResult AgregarCarrito(string id)
        {
            Producto buscar = db.Productos.Find(id)!;

            return View(buscar);
        }



        [HttpPost]
        public ActionResult AgregarCarrito(string id, int cant)
        {
            Producto buscado = db.Productos.Find(id)!;

            Carrito car = new Carrito()
            {
                Codigo = buscado.IdProducto,
                Nombre = buscado.NombreProducto,
                Precio = buscado.Precio,
                Cantidad = cant
            };
            listaCarrito = RecuperarCarrito();
            var encontrado = listaCarrito.Find(c => c.Codigo == id);

            // Recuperamos el contador actual de la sesión
            int contadorCarrito = HttpContext.Session.GetInt32("ContadorCarrito") ?? 0;

            if (encontrado == null)
            {
                listaCarrito.Add(car);
                ViewBag.mensaje = "Articulo agregado correctamente";
                contadorCarrito++;  // Incrementamos solo si es un nuevo producto
                HttpContext.Session.SetInt32("ContadorCarrito", contadorCarrito); // Guardamos el nuevo valor en la sesión
            }
            else
            {
                encontrado.Cantidad += cant;
                ViewBag.mensaje = $"Cantidad del Articulo: {encontrado.Nombre} " +
                                  $"fue actualizada a: {encontrado.Cantidad}";
            }
            GrabarCarrito();

            // Pasamos el contador actualizado a la vista, ya sea incrementado o no
            ViewBag.ContadorCarrito = contadorCarrito;

            return View(buscado);
        }


        public IActionResult VerCarritoCompra()
        {
            //lrecuperar el Carrito de compra
            listaCarrito = RecuperarCarrito();

            // si el carrito de compra esta vacio entonces 
            // regresamos a la lista de articulos
            if (listaCarrito.Count == 0)
                return RedirectToAction("ListaProductos");

            // calcular la suma de todos los importes de los 
            //articulos seleccionados
            ViewBag.suma_importes = listaCarrito.Sum(c => c.Importe);

            return View(listaCarrito);
        }

        // GET: CarritoController/Delete/5
        public ActionResult EliminarArticuloCarrito(string id)
        {
            listaCarrito = RecuperarCarrito();

            var item = listaCarrito.FirstOrDefault(a => a.Codigo == id);
            int cantidadAReducir = 0;
            if (item != null)
            {
                cantidadAReducir = item.Cantidad;
            }

            var buscado = listaCarrito.Find(c => c.Codigo == id);
            listaCarrito.Remove(buscado!);


            GrabarCarrito();

            var contadorCarrito = HttpContext.Session.GetInt32("ContadorCarrito") ?? 0;
            contadorCarrito -= cantidadAReducir;
            if (contadorCarrito < 0) contadorCarrito = 0; // Asegurarse de que el contador no sea negativo
            HttpContext.Session.SetInt32("ContadorCarrito", contadorCarrito);

            return RedirectToAction("VerCarritoCompra");
        }


    }
}
