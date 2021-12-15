﻿using ABB.Catalogo.Entidades.Core;
using ABB.Catalogo.LogicaNegocio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ABB.Catalogo.ClienteWeb.Controllers
{
    public class UsuariosController : Controller
    {
        string rutaApi = "https://localhost:44364/Api/";
        string jsonMediaType = "application/json";
        // GET: Usuarios
        public ActionResult Index()
        {
            string controladora = "Usuarios";
            string metodo = "Get";
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (WebClient usuario = new WebClient())
            {
                usuario.Headers.Clear();
                usuario.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                usuario.Encoding = UTF8Encoding.UTF8;
                string rutaCompleta = rutaApi + controladora;
                var data = usuario.DownloadString(new Uri(rutaCompleta));
                listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(data);
            }
            return View(listaUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            List<Rol> listaRol = new List<Rol>();
            listaRol = new RolLN().ListaRol();
            listaRol.Add(new Rol() { IdRol = 0, DesRol = "[Seleccione Rol...]" });
            ViewBag.listaRoles = listaRol;
            return View(usuario);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario collection)
        {
            string controladora = "Usuarios";
            try
            {
                // TODO: Add insert logic here
                using (WebClient usuario = new WebClient())
                {
                    usuario.Headers.Clear();
                    usuario.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                    usuario.Encoding = Encoding.UTF8;
                    var usuarioJson = JsonConvert.SerializeObject(collection);
                    string rutaCompleta = rutaApi + controladora;
                    var resultado = usuario.UploadString(new Uri(rutaCompleta), usuarioJson);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
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

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
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
