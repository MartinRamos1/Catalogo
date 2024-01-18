using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace presentacion
{
    
    public partial class frmAgregarMarcaCategoria : Form
    {
        bool marca = false;
        ProductoNegocio negocio = new ProductoNegocio();
        AccesoDatos datos = new AccesoDatos();
        public frmAgregarMarcaCategoria()
        {
            InitializeComponent();
        }

        public frmAgregarMarcaCategoria(bool marca = false)
        {
            this.marca = marca;
            InitializeComponent();
        }

        private void frmAgregarMarcaCategoria_Load(object sender, EventArgs e)
        {

            if (marca)
                lblMarcaCategoria.Text = "Agregar Marca";
            else
                lblMarcaCategoria.Text = "Agregar Categoría";

        }

        private void btnMarcaCategoria_Click(object sender, EventArgs e)
        {
            
            try
            {   
                if(txtMarcaCategoria.Text != "")
                {
                    DialogResult respuesta = MessageBox.Show("Agregar " + txtMarcaCategoria.Text + "? " + " ", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (marca)
                        {
                            datos.setearConsulta("Insert into MARCAS values(@marca)");
                            datos.setearParametros("@marca", txtMarcaCategoria.Text);
                            MessageBox.Show(txtMarcaCategoria.Text + " agregado a marcas");
                        }

                        else
                        {
                            datos.setearConsulta("Insert into CATEGORIAS values(@categoria)");
                            datos.setearParametros("@categoria", txtMarcaCategoria.Text);
                            MessageBox.Show(txtMarcaCategoria.Text + " agregado a categorías");
                        }

                        datos.ejecutarAccion();
                        Close();

                    }                  
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
