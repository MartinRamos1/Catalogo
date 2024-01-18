using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace presentacion
{
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboCategoria.DataSource = categoriaNegocio.Listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                cboMarca.DataSource = marcaNegocio.Listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();
            Producto prod = new Producto();
            
            try
            {
                
                prod.Codigo = txtCodigo.Text;
                prod.Nombre = txtNombre.Text;
                prod.Descripcion = txtDescripcion.Text;
                prod.Marca = new Marca();
                prod.Marca = (Marca)cboMarca.SelectedItem;
                prod.Categoria = (Categoria)cboCategoria.SelectedItem;
                prod.urlImagen = txtImg.Text;
                prod.Precio = decimal.Parse(txtPrecio.Text);


                if (txtNombre.Text != "")
                {
                    if (txtDescripcion.Text.Length > 150)
                    {
                        lblErrorDescripcion.Text = "Límite 150 caracteres";
                        
                    }
                    else
                    {
                        negocio.agregarProducto(prod);
                        MessageBox.Show(prod.Nombre + " agregado correctamente!");
                        Close();
                    }

                }else 
                {
                    lblErrorNombre.Text = "Ingresar un nombre";
                    lblErrorPrecio.Text = "";
                    lblErrorDescripcion.Text = "";
                } 
                

            }
            catch (FormatException)
            {
                lblErrorPrecio.Text = "Ingresar un precio válido";
                lblErrorNombre.Text = "";
                lblErrorDescripcion.Text = "";

            }

            catch (Exception)
            {
                lblError.Text = "Carga fallida, revisar los campos cargados";
                lblErrorNombre.Text = "";
                lblErrorPrecio.Text = "";
                lblErrorDescripcion.Text = "";
            }
          
             //

            
        }

        private void lblImg_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
