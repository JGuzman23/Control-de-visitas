using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using CapaEntidad;
using CapaNegocios;
namespace VisitasControl
{
    public partial class login : Form
    {
        E_User objE = new E_User();
        N_Negocios objN = new N_Negocios();
        admin Admin = new admin();
        general General = new general();
        

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            objE.Usuario = txtUser.Text;
            objE.Contrasena = txtPass.Text;
            dt = objN.login(objE);

            if (dt.Rows.Count > 0)
            {
                objE.Usuario = dt.Rows[0][0].ToString();
                objE.Usuario = dt.Rows[0][1].ToString();
                objE.Tipo = dt.Rows[0][2].ToString();

                if (objE.Tipo == "ADMINISTRATIVO")
                {
                    MessageBox.Show("Bienvenido");
                    Admin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bienvenido");
                    General.Show();
                    this.Hide();
                }



            }
            else
            {
                MessageBox.Show("USUARIO INCORRECTO");
            }


           
        }
    }
}
