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
        public static Producto getProductoByDescription(string Description)
        {
            return ProductoDAL.getProductoByDescription(Description);
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
        public static bool deleteProducto(int IdProducto)
        {
            return ProductoDAL.deleteProducto(IdProducto);
        }


    }
}