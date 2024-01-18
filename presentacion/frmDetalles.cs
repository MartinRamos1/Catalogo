using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace presentacion
{
    public partial class frmDetalles : Form
    {
        Producto prod = new Producto();
        public frmDetalles()
        {
            InitializeComponent();
        }

        public frmDetalles(Producto prod)
        {
            this.prod = prod;
            InitializeComponent();
        }

        private void frmDetalles_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = prod.Codigo;
            lblNombre.Text = prod.Nombre;
            lblDescripcion.Text = prod.Descripcion;
            lblMarca.Text = prod.Marca.Descripcion;
            lblCategoria.Text = prod.Categoria.Descripcion;
            lblPrecio.Text = prod.Precio.ToString("0.00");

            try
            {
                pbDetalles.Load(prod.urlImagen);
            }
            catch (Exception)
            {
                pbDetalles.Load("https://img.freepik.com/premium-vector/default-image-icon-vector-missing-picture-page-website-design-mobile-app-no-photo-available_87543-11093.jpg?size=626&ext=jpg&ga=GA1.1.145471453.1705131824&semt=ais");
            }
                
                



        }

        }
    }

   

