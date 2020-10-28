using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WsScan.Model;

namespace WsScan
{
    /// <summary>
    /// Descripción breve de Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        public bool insert_inventario_fisico(Inventario_Fisico escaneo)
        {
            try
            {
                using (CSLInventarioEscaneoEntities db = new CSLInventarioEscaneoEntities())
                {
                    db.Entry(escaneo).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool add_inventario_fisico(DateTime fecha_escaneo, String cadena_original, String lote, Double cantidad, String dispositivo_id)
        {
            try
            {
                using (CSLInventarioEscaneoEntities db = new CSLInventarioEscaneoEntities())
                {
                    db.Entry(new Inventario_Fisico(){ fecha_escaneo = fecha_escaneo, cadena_original = cadena_original, cantidad = cantidad, lote = lote, dispositivo_id = dispositivo_id}).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public string test_webmethod(DateTime fecha_escaneo, String cadena_original, String lote, Double cantidad, String dispositivo_id)
        {
            try
            {
                return "correcto";
            }
            catch (Exception)
            {
                return "incorrecto";
            }
        }
    }
}
