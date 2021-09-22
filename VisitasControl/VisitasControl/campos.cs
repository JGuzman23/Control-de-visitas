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
    public partial class campos : Form
    {
        E_Registro objE = new E_Registro();
        N_Negocios objN = new N_Negocios();
        public campos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            objE.Edificio = txtAgreEdi.Text;
            objN.insertarEdificios(objE);
            MessageBox.Show("INSERTADO");
            mostrarE();



            txtAgreEdi.Clear();
        }

        private void txtAgreEdi_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objE.Edificio = cbEdificio.Text;


            DialogResult dialogResult = MessageBox.Show("Estas seguro de que quieres eliminar esta edificio?", "Eliminar Edificio", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                objN.eliminarE(objE);
                MessageBox.Show("ELIMINADO");
                mostrarE();



            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        public void mostrarE()
        {
            cbEdificio.DataSource = objN.MostrarEdificio();
            cbEdificio.DisplayMember = "centro";
            cbEdificio.ValueMember = "edificio";

            cbAula_E.DataSource = objN.MostrarEdificio();
            cbAula_E.DisplayMember = "centro";
            cbAula_E.ValueMember = "edificio";

            cbE.DataSource = objN.MostrarEdificio();
            cbE.DisplayMember = "centro";
            cbE.ValueMember = "edificio";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            objE.Edificio = cbAula_E.Text;
            objE.Aula = txtAula.Text;
            objN.insertarAula(objE);
            MessageBox.Show("INSERTADO");
            


            txtAula.Clear();
        }
        public void mostarA(string buscar)
        {
            cbA.DataSource = objN.aulaE(buscar);
            cbA.DisplayMember = "aula";
            cbA.ValueMember = "aula";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            objE.Aula = cbA.Text;
            objE.Edificio = cbE.Text;



            DialogResult dialogResult = MessageBox.Show("Estas seguro de que quieres eliminar esta aula?", "Eliminar Aula", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                objN.EliminarAula(objE);
                MessageBox.Show("Eliminado");
                mostarA(cbEdificio.Text);





            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void campos_Load(object sender, EventArgs e)
        {
            mostrarE();
        }

        private void cbE_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostarA(cbE.Text); 
        }

        private void cbA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
