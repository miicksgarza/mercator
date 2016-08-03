using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class EmpleadoBLL
    {
        //CREATE EMPLEADO
        public static bool createEmpleado(Empleado emp)
        {
            return EmpleadoDAL.createEmpleado(emp);
        }

        //READ BY ID EMPLEADO
        public static Empleado getEmpleadoByName(string name)
        {
            return EmpleadoDAL.getEmpleadoByName(name);
        }
        //READ ALL TABLE EMPLEADO
        public static List<Empleado> getEmpleados()
        {
            return EmpleadoDAL.getEmpleados();
        }
        //UPDATE EMPLEADO
        public static bool updateEmpleado(Empleado emp)
        {
            return EmpleadoDAL.updateEmpleado(emp);
        }
        //DELETE EMPLEADOS
        public static bool deleteEmpleado(string apellido)
        {
            return EmpleadoDAL.deleteEmpleado(apellido);
        }
    }
}
