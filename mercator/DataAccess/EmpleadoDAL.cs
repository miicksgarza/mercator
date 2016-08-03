using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmpleadoDAL
    {
        //CREATE
        public static bool createEmpleado(Empleado emp)
        {

            try
            {
                using (var db = new MercatorEntities())
                {
                    db.Empleadoes.Add(emp);
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





        //READ BY ID

        public static Empleado getEmpleadoByName(string name)
        {
            using (var db = new MercatorEntities())
            {
                var query = (from e in db.Empleadoes
                             where e.Nombre == name
                             select e).Single();

                return query;
            }

        }




        //READ ALL
        public static List<Empleado> getEmpleados()
        {
            using (var db = new MercatorEntities())
            {
                var query = (from p in db.Empleadoes
                             select p).ToList();

                return query;
            }
        }





        //UPDATE

        public static bool updateEmpleado(Empleado emp)
        {
            try
            {
                using (var db = new MercatorEntities())
                {
                    db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
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

        //DELETE

        public static bool deleteEmpleado(string apellido)
        {
            try
            {
                using (var db = new MercatorEntities())
                {
                    var query = (from e in db.Empleadoes
                                 where e.Apellido == apellido
                                 select e).Single();

                    db.Empleadoes.Remove(query);
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
    }
}
