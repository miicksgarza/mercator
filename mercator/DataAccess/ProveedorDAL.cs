using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProveedorDAL
    {

        #region Guardar proveedor
        //CREATE
        public static bool createProveedor(Proveedor prov)
        {

            try
            {
                using (var db = new MercatorEntities())
                {
                    db.Proveedors.Add(prov);
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


        #region Consultar proveedor
        //READ BY NAME

        public static Proveedor getProveedorByName(string proveedor)
        {
            using (var db = new MercatorEntities())
            {
                var query = (from p in db.Proveedors
                             where p.NombreProv == proveedor
                             select p).Single();

                return query;
            }

        }
        #endregion


        #region Mostrar proveedores
        //READ ALL
        public static List<Proveedor> getProveedores()
        {
            using (var db = new MercatorEntities())
            {
                var query = (from p in db.Proveedors
                             select p).ToList();

                return query;
            }
        }

        #endregion


        #region Actualizar proveedor
        //UPDATE

        public static bool updateProveedor(Proveedor prov)
        {
            try
            {
                using (var db = new MercatorEntities())
                {
                    db.Entry(prov).State = System.Data.Entity.EntityState.Modified;
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


        #region Borrar proveedor
        //DELETE

        public static bool deleteProveedor(string proveedor)
        {
            try
            {
                using (var db = new MercatorEntities())
                {
                    var query = (from p in db.Proveedors
                                 where p.NombreProv == proveedor
                                 select p).Single();

                    db.Proveedors.Remove(query);
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
    }
}
