using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class ListaCategoriaBLL
    {
        public static DataTable mostrarCategoria()
        {
            return ListaCategoriaDAL.mostrarCategoria();
        }

    }
}
