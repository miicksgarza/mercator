using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ListaCategoriaDAL
    {
        public static DataTable mostrarCategoria()
        {
            //Creando el DataTable
            DataTable dtCategoria = new DataTable();

            //Añadiendo las columnas que llevara el DataTable
            dtCategoria.Columns.Add("IdCategoria", typeof(int));
            dtCategoria.Columns.Add("Descripcion", typeof(string));

            //Añadir una fila o registro a el DataTable
            dtCategoria.Rows.Add("0", "--Seleccione--");
            

            //Espacio de nombres de la cadena de conexion
            using (var dbCtx = new MercatorEntities())
            {
                //Query que traera la informacion de la Base de Datos
                var query = (from c in dbCtx.Categorias
                             select c).ToList();

                //Ciclo FOR para crear las filas con la informacion
                //de la base de datos
                query.ToList().ForEach((c) =>
                {
                    //Creando una fila en el DataTable
                    DataRow Row = dtCategoria.NewRow();

                    //Columnas que llevara la fila
                    Row.SetField<int>("IdCategoria", c.IdCategoria);
                    Row.SetField<string>("Descripcion", c.Descripcion);

                    //Añadir la fila creada al DataTable
                    dtCategoria.Rows.Add(Row);
                });
            }

            return dtCategoria;

        }
    }
}
