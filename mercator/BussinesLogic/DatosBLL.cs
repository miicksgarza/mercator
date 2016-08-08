using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class DatosBLL
    {
        public static bool createDatosEmpresa(Dato dato)
        {
            return DatosDAL.createDatosEmpresa(dato);
        }


        public static bool updateDatosEmpresa(Dato dato)
        {
            return DatosDAL.updateDatosEmpresa(dato);
        }

       
         
    }
}
