using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CompraDAL
    {

        #region Crearcompra
        //CREATE
        public static bool createCompra(Compra compra)
        {

            try
            {
                using (var db = new MercatorEntities())
                {
                    db.Compras.Add(compra);
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

        #region MostrarCompras
        //READ ALL
        public static List<DetalleCompra> getCompra()
        {
            using (var db = new MercatorEntities())
            {
                var query = (from c in db.DetalleCompras
                             select c).ToList();

                return query;
            }
        }
        #endregion

        #region Buscarcompras
        //READ BY SERIE

        public static Compra getCompraBySr(string serie)
        {
            using (var db = new MercatorEntities())
            {
                var query = (from c in db.Compras
                             where c.Serie == serie
                             select c).Single();

                return query;
            }

        }
        #endregion
    }
}
