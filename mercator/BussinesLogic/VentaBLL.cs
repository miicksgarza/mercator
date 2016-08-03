using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class VentaBLL
    {
        public static bool createVenta(Venta venta)
        {
            return VentaDAL.createVenta(venta);
        }

        public static List<DetalleVenta> getVentas()
        {
            return VentaDAL.getVentas();
        }

        public static Venta getVentasBySr(int serie)
        {
            return VentaDAL.getVentasBySr(serie);
        }
    }
}
