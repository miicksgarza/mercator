﻿#region using directives

using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DataAccess
{
    public class ProductoDAL
    {

        #region RegistrarProducto
        //CREATE
        public static bool createProducto(Producto producto)
        {

            try
            {
                using (var db = new MercatorEntities())
                {
                    db.Productoes.Add(producto);
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

        #region BuscarProductos
        //READ BY ID

        public static Producto getProductoByDescription(string Description)
        {
            using (var db = new MercatorEntities())
            {
                var query = (from p in db.Productoes
                             where p.Nombre == Description
                             select p).Single();

                return query;
            }

        }
        #endregion

        #region MostrarProductos
        //READ ALL
        public static List<Producto> getProductos()
        {
            using (var db = new MercatorEntities())
            {
                var query = (from p in db.Productoes
                             select p).ToList();

                return query;
            }
        }
        #endregion

        #region ActualizarProductos
        //UPDATE

        public static bool updateProducto(Producto producto)
        {
            try
            {
                using (var db = new MercatorEntities())
                {
                    db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
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

        #region BorrarProductos
        //DELETE

        public static bool deleteProducto(int IdProducto)
        {
            try
            {
                using (var db = new MercatorEntities())
                {
                    var query = (from p in db.Productoes
                                 where p.IdProducto == IdProducto
                                 select p).Single();

                    db.Productoes.Remove(query);
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

