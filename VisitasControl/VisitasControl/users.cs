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
    public partial class users : Form
    {

        E_User objE = new E_User();
        N_Negocios objN = new N_Negocios();
        string eliminar;
        public users()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin admin = new admin();
            admin.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            objE.Nombre = txtNombre.Text;
            objE.Apellido = txtApellido.Text;
            objE.Fecha = fecha.Text;
            objE.Usuario = txtUsuario.Text;
            objE.Contrasena = txtPass.Text;
            objE.Tipo  = cbTipo.Text;
            objN.insertarUsuarios(objE);

            MessageBox.Show("Registrado");
            mostrarUsuarios("");

            txtNombre.Clear();
            txtApellido.Clear();
            txtUsuario.Clear();
            txtPass.Clear();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvUser.Rows[e.RowIndex]; ;
            if (dgvUser.Rows[e.RowIndex].Cells[0].Value == null)
            {
                dgvUser.Rows[e.RowIndex].Cells[0].Value = true;
            }
            else
            {
                dgvUser.Rows[e.RowIndex].Cells[0].Value = null;
               

            }

            eliminar = dgvUser.Rows[e.RowIndex].Cells[5].Value.ToString();

        }
        public void mostrarUsuarios(string buscar)
        {
            dgvUser.DataSource = objN.MostarUsuarios(buscar);


            dgvUser.Columns[3].Visible = false;
            dgvUser.Columns[6].Visible = false;


            // MessageBox.Show("se busco");

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            objE.Usuario = eliminar;


            DialogResult dialogResult = MessageBox.Show("Estas seguro de que quieres eliminar esta usuario?", "Eliminar User", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                objN.EliminarUsuarios(objE);
                MessageBox.Show("Eliminado");
                mostrarUsuarios("");

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarUsuarios(txtBuscar.Text);
        }

        private void users_Load(object sender, EventArgs e)
        {
            mostrarUsuarios("");
        }
    }
}
