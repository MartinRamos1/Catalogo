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
    public partial class frmFiltro : Form
    {
        AccesoDatos datos = new AccesoDatos();
        ProductoNegocio negocio = new ProductoNegocio();
        List<Producto> lista;

        public frmFiltro()
        {
            InitializeComponent();

            
        }

        private void recargar()
        {
            lista = negocio.Listar();
            dgvFiltro.DataSource = lista;
        }

        private void frmFiltro_Load(object sender, EventArgs e)
        {
            cboFiltro.Items.Add("Nombre");
            cboFiltro.Items.Add("Código");
            cboFiltro.Items.Add("Marca");
            cboFiltro.Items.Add("Categoría");
            cboFiltro.Items.Add("Precio exacto");
            cboFiltro.Items.Add("Precio mayor a");
            cboFiltro.Items.Add("Precio menor a");
            cboFiltro.SelectedIndex = 0;
            recargar();
            // OCULTAR COLUMNAS 
            dgvFiltro.Columns["urlImagen"].Visible = false;
            dgvFiltro.Columns["Id"].Visible = false;


            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Producto> listaFiltrada = lista;
            string filtro = txtFiltro.Text;
            string seleccionado = cboFiltro.SelectedItem.ToString();
            if (filtro.Length > 1)
            {
                try
                {
                    if (seleccionado == "Nombre")
                    {
                        listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper() == filtro.ToUpper());
                    }
                    else if (seleccionado == "Código")
                    {
                        listaFiltrada = lista.FindAll(x => x.Codigo.ToUpper() == filtro.ToUpper());
                    }
                    else if (seleccionado == "Marca")
                    {
                        listaFiltrada = lista.FindAll(x => x.Marca.Descripcion.ToUpper() == filtro.ToUpper());
                    }
                    else if (seleccionado == "Categoría")
                    {
                        listaFiltrada = lista.FindAll(x => x.Categoria.Descripcion.ToUpper() == filtro.ToUpper());
                    }
                    else if (seleccionado == "Precio exacto")
                    {
                        listaFiltrada = lista.FindAll(x => x.Precio == decimal.Parse(filtro));
                    }
                    else if (seleccionado == "Precio mayor a")
                    {
                        listaFiltrada = lista.FindAll(x => x.Precio > decimal.Parse(filtro));
                    }
                    else if (seleccionado == "Precio menor a")
                    {
                        listaFiltrada = lista.FindAll(x => x.Precio < decimal.Parse(filtro));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("La búsqueda no es válida, revise los términos de búsqueda");
                    
                }



            }
            //else { dgvFiltro.DataSource = lista; }

            dgvFiltro.DataSource = listaFiltrada;
        }

        
    }
}
