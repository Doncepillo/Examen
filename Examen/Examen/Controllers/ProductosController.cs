using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class ProductosController : Controller
    {
            ExamenEntities cnx;

            public ProductosController()
            {
                cnx = new ExamenEntities();

            }
            public ActionResult NuevoProducto()
            {

                return View();
            }


            public ActionResult Listado()
            {

                cnx.Database.Connection.Open();

                List<Producto> producto = cnx.Producto.ToList();
                cnx.Database.Connection.Close();
                return View(producto);
            }



            public ActionResult Guardar(string Nombre, string CodigoBarra, string Familia, int Precio, int Descuento, string Descripcion)
            {
                Producto producto = new Producto()
                {

                    Nombre = Nombre,
                    CodigoBarra = CodigoBarra,
                    Familia = Familia,
                    Precio = Precio,
                    Descuento = Descuento,
                    Descripcion = Descripcion

                };

                cnx.Producto.Add(producto);
                cnx.SaveChanges();
                return View("Listado", cnx.Producto.ToList());

            }



            public ActionResult Ficha(int Id)
            {

                return View(cnx.Producto.Where(x => x.Id == Id).First());

            }




            public ActionResult Ver(int Id)
            {


                return View("Ficha", null);
            }


          
    }
}
