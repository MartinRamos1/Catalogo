using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace presentacion
{
    public partial class frmModificar : Form
    {
        private Producto modificar = new Producto();
        public frmModificar()
        {
            InitializeComponent();
        }

        public frmModificar(Producto modificar)
        {   
            this.modificar = modificar;
            
            InitializeComponent();

        }

        private void frmModificar_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboCategoriaModificar.DataSource = categoriaNegocio.Listar();
                cboCategoriaModificar.ValueMember = "Id";
                cboCategoriaModificar.DisplayMember = "Descripcion";

                cboMarcaModificar.DataSource = marcaNegocio.Listar();
                cboMarcaModificar.ValueMember = "Id";
                cboMarcaModificar.DisplayMember = "Descripcion";
                txtCodigoModificar.Text = modificar.Codigo;
                txtNombreModificar.Text = modificar.Nombre;
                txtDescripcionModificar.Text = modificar.Descripcion;
                cboMarcaModificar.SelectedValue = modificar.Marca.Id;
                cboCategoriaModificar.SelectedValue = modificar.Categoria.Id;
                txtImgModificar.Text = modificar.urlImagen;
                txtPrecioModificar.Text = modificar.Precio.ToString();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptarModificar_Click_1(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            try
            {
                modificar.Codigo = txtCodigoModificar.Text;
                modificar.Nombre = txtNombreModificar.Text;
                modificar.Descripcion = txtDescripcionModificar.Text;
                modificar.Marca = (Marca)cboMarcaModificar.SelectedItem;
                modificar.Categoria = (Categoria)cboCategoriaModificar.SelectedItem;
                modificar.urlImagen = txtImgModificar.Text;
                modificar.Precio = decimal.Parse(txtPrecioModificar.Text);

                if (txtNombreModificar.Text != "")
                {
                    if (txtDescripcionModificar.Text.Length > 150)
                    {
                        lblErrorDescripcion.Text = "Límite 150 caracteres";
                    }
                    else
                    {
                        negocio.modificarProducto(modificar);
                        MessageBox.Show(modificar.Nombre + " modificado exitosamente");
                        Close();
                    }
                }
                else
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
        }

        private void btnCancelarModificar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }

