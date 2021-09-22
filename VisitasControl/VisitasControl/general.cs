using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;

namespace VisitasControl
{
    public partial class general : Form
    {
        E_Registro objE = new E_Registro();
        N_Negocios objN = new N_Negocios();
        public general()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            users users = new users();
            users.Show();
            //this.Hide();
        }
        public void mostrarE()
        {
            cbEdificio.DataSource = objN.MostrarEdificio();
            cbEdificio.DisplayMember = "centro";
            cbEdificio.ValueMember = "edificio";
        }
        public void mostarA(string buscar)
        {
            cbAula.DataSource = objN.aulaE(buscar);
            cbAula.DisplayMember = "aula";
            cbAula.ValueMember = "aula";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            campos campos = new campos();
            campos.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            objE.Nombre = txtNombre.Text;
            objE.Email = txtEmail.Text;
            objE.Apellido = txtApellido.Text;
            objE.Carrera = cbCarrera.Text;
            objE.Edificio = cbEdificio.Text;
            objE.Entrada = entrada.Text;
            objE.Motivo = txtMotivo.Text;
            objE.Salida = salida.Text;           
            objE.Aula = cbAula.Text;
            objN.insertarRegistros(objE);
            MessageBox.Show("Registrado");
            mostrarVisitas("");
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtMotivo.Clear();

        }
        public void mostrarVisitas(string buscar)
        {
            dgvVisitas.DataSource = objN.mostrarR(buscar);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbE_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarVisitas(cbE.Text);
        }

        private void general_Load(object sender, EventArgs e)
        {
            mostrarVisitas("");
            mostrarE();
        }

        private void cbEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostarA(cbEdificio.Text);
        }
    }
}
