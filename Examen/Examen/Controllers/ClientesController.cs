using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class ClientesController : Controller
    {
        ExamenEntities cnx;

        public ClientesController()
        {
            cnx = new ExamenEntities();

        }
        public ActionResult NuevoCliente()
        {

            return View();
        }


        public ActionResult Listado()
        {

            cnx.Database.Connection.Open();

            List<Cliente> cliente = cnx.Cliente.ToList();
            cnx.Database.Connection.Close();
            return View(cliente);
        }



        public ActionResult Guardar(string Rut, string Nombre, string Apellidos, string Direccion, string TipoCliente)
        {
            Cliente cliente = new Cliente()
            {
                Rut = Rut,
                Nombre = Nombre,
                Apellidos = Apellidos,
                Direccion = Direccion,
                TipoCliente = TipoCliente

            };

            cnx.Cliente.Add(cliente);
            cnx.SaveChanges();
            return View("Listado", cnx.Cliente.ToList());

        }



        public ActionResult Ficha(int Id)
        {

            return View(cnx.Cliente.Where(x => x.Id == Id).First());

        }




        public ActionResult Ver(int Id)
        {


            return View("Ficha", null);
        }



    }
}
