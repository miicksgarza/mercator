using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class CompraBLL
    {
        public static bool createCompra(Compra compra)
        {
            return CompraDAL.createCompra(compra);
        }

        public static List<DetalleCompra> getCompra()
        {
            return CompraDAL.getCompra();
        }

        public static Compra getCompraBySr(string serie)
        {
            return CompraDAL.getCompraBySr(serie);
        }
    }
}
