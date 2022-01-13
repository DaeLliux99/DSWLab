using ABB.Catalogo.Entidades.Core;
using ABB.Catalogo.LogicaNegocio.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ABB.Catalogo.ClienteWeb.Controllers
{
    public class ProductosController : Controller
    {
        string RutaApi = "https://localhost:44364/Api/"; //define la ruta del web api
        string jsonMediaType = "application/json"; // define el tipo de dat
        // GET: Productos
        public ActionResult Index()
        {
            string controladora = "Productos";
            //string metodo = "Get";
            List<Producto> listaProductos = new List<Producto>();
            using (WebClient usuario = new WebClient())
            {
                usuario.Headers.Clear();
                usuario.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                usuario.Encoding = UTF8Encoding.UTF8;
                string rutacompleta = RutaApi + controladora;
                var data = usuario.DownloadString(new Uri(rutacompleta));
                listaProductos = JsonConvert.DeserializeObject<List<Producto>>(data);
            }
            return View(listaProductos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            Producto producto = new Producto();
            List<Categoria> listaCategoria = new List<Categoria>();
            listaCategoria = new CategoriaLN().ListaCategoria();
            listaCategoria.Add(new Categoria() { IdCategoria = 0, DestCategoria = "[Seleccione Categoria...]" });
            ViewBag.listaCategorias = listaCategoria;
            return View(producto);
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            string controladora = "Productos";
            try
            {
                // TODO: Add insert logic here
                using (WebClient usuario = new WebClient())
                {
                    usuario.Headers.Clear();
                    usuario.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                    usuario.Encoding = UTF8Encoding.UTF8;
                    var usuarioJson = JsonConvert.SerializeObject(producto);
                    string rutacompleta = RutaApi + controladora;
                    var resultado = usuario.UploadString(new Uri(rutacompleta), usuarioJson);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
