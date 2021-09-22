using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class N_Negocios
    {
        D_Datos objDatos = new D_Datos();

        public void insertarRegistros(E_Registro categorias)
        {
            objDatos.insertarRegistros(categorias);
        }
        public void insertarEdificios(E_Registro categorias)
        {
            objDatos.insertarEdificio(categorias);
        }
        public List<E_Registro> MostrarEdificio()
        {
            return objDatos.MostrarE();
        }
        public List<E_Registro> mostrarR(string buscar)
        {
            return objDatos.mostrarR(buscar);
        }
        public DataTable login(E_User categorias)
        {
            return objDatos.login(categorias);
        }
        public List<E_Registro> aulaE(string buscar)
        {
            return objDatos.aula_edificio(buscar);
        }
        public void insertarUsuarios(E_User categorias)
        {
            objDatos.insertarUsuarios(categorias);
        }
        public void eliminarE (E_Registro categorias)
        {
            objDatos.EiminarE(categorias);
        }
        public void EliminarAula(E_Registro categorias)
        {
            objDatos.EiminarAula(categorias);
        }
        public void insertarAula(E_Registro categorias)
        {
            objDatos.insertarAula(categorias);
        }
        public void EliminarUsuarios(E_User categorias)
        {
            objDatos.EiminarUser(categorias);
        }
        public List<E_User> MostarUsuarios(String buscar)
        {
            return objDatos.MostarUsuarios(buscar);
        }
    }
}
