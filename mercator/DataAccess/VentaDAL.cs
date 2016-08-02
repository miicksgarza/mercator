using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VentaDAL
    {
        #region CrearVenta
        //CREATE
        public static bool createVenta(Venta venta)
        {

            try
            {
                using (var db = new MercatorEntities())
                {
                    db.Ventas.Add(venta);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (DbEntityValidationResult entityErr in dbEx.EntityValidationErrors)
                {
                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        Console.WriteLine("Error Property Name {0} : Error Message: {1}",
                            error.PropertyName, error.ErrorMessage);
                    }

                }
            }
            return false;

        }
        #endregion


        #region MostrarVentas
        //READ ALL
        public static List<DetalleVenta> getVentas()
        {
            using (var db = new MercatorEntities())
            {
                var query = (from v in db.DetalleVentas
                             select v).ToList();

                return query;
            }
        }
        #endregion

        #region BuscarVentas
        //READ BY SERIE
        
        public static Venta getVentasBySr(int serie)
        {
            using (var db = new MercatorEntities())
            {
                var query = (from v in db.Ventas
                             where v.Serie == serie
                             select v).Single();

                return query;
            }

        }
        #endregion

    }
}
