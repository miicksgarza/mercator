using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class ProveedorBLL
    {
        //CREATE PROVEEDOR
        public static bool createProveedor(Proveedor prov)
        {
            return ProveedorDAL.createProveedor(prov);

        }

        //READ BY NAME PROVEEDOR
        public static Proveedor getProveedorByName(string proveedor)
        {
            return ProveedorDAL.getProveedorByName(proveedor);
        }

        //READ ALL TABLE PROVEEDOR

        public static List<Proveedor> getProveedores()
        {
            return ProveedorDAL.getProveedores();
        }

        //UPDATE PROVEEDOR
        public static bool updateProveedor(Proveedor prov)
        {
            return ProveedorDAL.updateProveedor(prov);
        }

        //DELETE PROVEEDORES
        public static bool deleteProveedor(string proveedor)
        {
            return ProveedorDAL.deleteProveedor(proveedor);
        }

    }
}
