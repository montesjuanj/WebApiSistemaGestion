using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSistemaGestion.service
{
    public static class UsuarioService
    {
        public static List<Usuario> ObtenerTodosLosUsuarios()
        {
            using (CoderContext contexto = new CoderContext())
            {
                List<Usuario> usuarios = contexto.Usuarios.ToList();
                return usuarios;
            }
        }

        public static Usuario ObtenerUsuarioPorID(int id)
        {
            using (CoderContext contexto = new CoderContext())
            {
                Usuario? usuarioBuscado = contexto.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                return usuarioBuscado;
            }
        }

        public static bool AgregarUsuario(Usuario usuario)
        {
            using (CoderContext contexto = new CoderContext())
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
                return true;
            }
        }

        public static bool EliminarUsuario(int id)
        {

            using (CoderContext contexto = new CoderContext())
            {
                Usuario UsuarioAEliminar = contexto.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                if (UsuarioAEliminar is not null)
                {
                    contexto.Usuarios.Remove(UsuarioAEliminar);
                    contexto.SaveChanges();
                    return true;
                }

            }
            return false;

        }


        public static bool ActualizarUsuarioPorId(Usuario usuario, int id)
        {

            using (CoderContext contexto = new CoderContext())
            {
                Usuario? usuarioBuscado = contexto.Usuarios.Where(u => u.Id == id).FirstOrDefault();


                usuarioBuscado.Nombre = usuario.Nombre;
                usuarioBuscado.Apellido = usuario.Apellido;
                usuarioBuscado.NombreUsuario = usuario.NombreUsuario;
                usuarioBuscado.Mail = usuario.Mail;

                contexto.Usuarios.Update(usuarioBuscado);

                contexto.SaveChanges();

                return true;
            }

        }
    }


}

