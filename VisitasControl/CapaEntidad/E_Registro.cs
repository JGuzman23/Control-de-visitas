using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Registro
    {
        private string nombre;
        private string apellido;
        private string carrera;
        private string aula;
        private string email;
        private string edificio;
        private string entrada;
        private string salida;
        private string motivo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public string Aula { get => aula; set => aula = value; }
        public string Email { get => email; set => email = value; }
        public string Edificio { get => edificio; set => edificio = value; }
        public string Entrada { get => entrada; set => entrada = value; }
        public string Salida { get => salida; set => salida = value; }
        public string Motivo { get => motivo; set => motivo = value; }
    }
}
