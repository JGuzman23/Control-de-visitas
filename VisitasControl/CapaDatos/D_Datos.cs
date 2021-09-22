using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class D_Datos
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

        public void insertarRegistros(E_Registro categorias)
        {
            SqlCommand cmd = new SqlCommand("insertarRegistro", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@nombre", categorias.Nombre);
            cmd.Parameters.AddWithValue("@apellido", categorias.Apellido);
            cmd.Parameters.AddWithValue("@carrera", categorias.Carrera);
            cmd.Parameters.AddWithValue("@correo", categorias.Email);
            cmd.Parameters.AddWithValue("@edificio", categorias.Edificio);
            cmd.Parameters.AddWithValue("@entrada", categorias.Entrada);
            cmd.Parameters.AddWithValue("@salida", categorias.Salida);
            cmd.Parameters.AddWithValue("@motivo", categorias.Motivo);
            cmd.Parameters.AddWithValue("@aula", categorias.Aula);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void insertarUsuarios(E_User categorias)
        {
            SqlCommand cmd = new SqlCommand("insertarUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@nombre", categorias.Nombre);
            cmd.Parameters.AddWithValue("@apellido", categorias.Apellido);
            cmd.Parameters.AddWithValue("@fecha", categorias.Fecha);
            cmd.Parameters.AddWithValue("@tipo", categorias.Tipo);
            cmd.Parameters.AddWithValue("@usuario", categorias.Usuario);
            cmd.Parameters.AddWithValue("@contrasena", categorias.Contrasena);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void EiminarUser(E_User categorias)
        {
            SqlCommand cmd = new SqlCommand("eliminarUser", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@usuario", categorias.Usuario);



            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public List<E_User> MostarUsuarios(String buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("mostrarUsuarios", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", buscar);
            leerFilas = cmd.ExecuteReader();

            List<E_User> listar = new List<E_User>();
            while (leerFilas.Read())
            {
                listar.Add(new E_User
                {
                    Nombre = leerFilas.GetString(1),
                    Apellido = leerFilas.GetString(2),
                    Tipo = leerFilas.GetString(4),
                    Usuario = leerFilas.GetString(5)


                });
            }
            conexion.Close();
            leerFilas.Close();
            return listar;
        }
        public void insertarEdificio(E_Registro categorias)
        {
            SqlCommand cmd = new SqlCommand("insertarE", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@insertar", categorias.Edificio);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void EiminarE(E_Registro categorias)
        {
            SqlCommand cmd = new SqlCommand("eliminarE", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@eliminar", categorias.Edificio);
     
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable login(E_User categorias)
        {
            SqlCommand cmd = new SqlCommand("iniciar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", categorias.Usuario);
            cmd.Parameters.AddWithValue("@pass", categorias.Contrasena);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public List<E_Registro> mostrarR(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("mostrarR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", buscar);
            leerFilas = cmd.ExecuteReader();

            List<E_Registro> listar = new List<E_Registro>();
            while (leerFilas.Read())
            {
                listar.Add(new E_Registro
                {

                    Nombre = leerFilas.GetString(1),
                    Apellido = leerFilas.GetString(2),
                    Carrera = leerFilas.GetString(3),
                    Entrada = leerFilas.GetString(6),
                    Salida = leerFilas.GetString(7),
                    Email = leerFilas.GetString(4),
                    Edificio = leerFilas.GetString(5),
                    Motivo = leerFilas.GetString(8),
                    Aula = leerFilas.GetString(9),

                });
            }
            conexion.Close();
            leerFilas.Close();
            return listar;
        }
        public List<E_Registro> aula_edificio(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("sp_aula_edificio ", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", buscar);
            leerFilas = cmd.ExecuteReader();

            List<E_Registro> listar = new List<E_Registro>();
            while (leerFilas.Read())
            {
                listar.Add(new E_Registro
                {

                    Aula = leerFilas.GetString(0),

                });
            }
            conexion.Close();
            leerFilas.Close();
            return listar;
        }
        public List<E_Registro> MostrarE()
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("mostarE ", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();


            leerFilas = cmd.ExecuteReader();

            List<E_Registro> listar = new List<E_Registro>();
            while (leerFilas.Read())
            {
                listar.Add(new E_Registro
                {


                    Edificio = leerFilas.GetString(1),


                });
            }
            conexion.Close();
            leerFilas.Close();
            return listar;
        }
        public void EiminarAula(E_Registro categorias)
        {
            SqlCommand cmd = new SqlCommand("EliminarAula", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@edificio", categorias.Edificio);
            cmd.Parameters.AddWithValue("@aula", categorias.Aula);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void insertarAula(E_Registro categorias)
        {
            SqlCommand cmd = new SqlCommand("insertarAula", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@edificio", categorias.Edificio);
            cmd.Parameters.AddWithValue("@aula", categorias.Aula);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
