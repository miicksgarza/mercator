using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class UsuarioBLL
    {
        public static bool createUsuario(Usuario user)
        {
            return UsuarioDAL.createUsuario(user);
        }

        public static bool loginUser(string user, string pass)
        {
            return UsuarioDAL.loginUser(user, pass);
        }
            
    }
}
