using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class ProductoBLL
    {
        //CREATE PRODUCTO
        public static bool createProducto(Producto producto)
        {
            return ProductoDAL.createProducto(producto);
        }

        //READ BY DESCRIPCION PRODUCTO
        public static Producto getProductoByDescription(int id)
        {
            return ProductoDAL.getProductoByDescription(id);
        }

        //READ ALL TABLE PRODUCTO
        public static List<Producto> getProductos()
        {
            return ProductoDAL.getProductos();
        }

        //UPDATE PRODUCTO
        public static bool updateProducto(Producto producto)
        {
            return ProductoDAL.updateProducto(producto);
        }

        //DELETE PRODUCTOS
        public static bool deleteProducto(int id)
        {
            return ProductoDAL.deleteProducto(id);
        }


    }
}