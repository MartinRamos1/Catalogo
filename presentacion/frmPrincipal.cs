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
    public partial class frmPrincipal : Form
    {
        private List<Producto> lista;
        Producto seleccionado;



        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            tssFecha.Text = fecha.ToString("dddd dd/MM/yyyy");

            ProductoNegocio negocio = new ProductoNegocio();
            lista = negocio.Listar();
            dgvProductos.DataSource = lista;

            // OCULTAR COLUMNAS Y ARREGLAR FORMATO DEL PRECIO
            dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "0.000";
            dgvProductos.Columns["Codigo"].Visible = false;
            dgvProductos.Columns["urlImagen"].Visible = false;
            dgvProductos.Columns["Id"].Visible = false;

        }
        // RECARGAR LA LISTA
        public void recargar()
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                lista = negocio.Listar();
                dgvProductos.DataSource = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // SELECCIONAR EL ARTICULO ACTUAL
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
           if (dgvProductos.CurrentRow != null)
           seleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
        }

        // BOTÓN AGREGAR

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar ventana = new frmAgregar();
            ventana.ShowDialog();
            recargar();
        }

        // BOTÓN ELIMINAR
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                DialogResult respuesta = MessageBox.Show("¿Eliminar " + seleccionado.Nombre.ToUpper() + " definitivamente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    negocio.eliminarProducto(seleccionado);
                    recargar();
                }    
            }
        }

        // BOTÓN ACTUALIZAR
        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            recargar();
        }

        // BOTÓN MODIFICAR
        private void tsbModificar_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                frmModificar modificar = new frmModificar(seleccionado);
                modificar.ShowDialog();
                recargar();
            }
        }

        // VER PROPIEDADES
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionado != null)
            {
                frmDetalles detalles = new frmDetalles(seleccionado);
                detalles.ShowDialog();
            }
        }

        // FILTRO RAPIDO
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro.Length > 1)
            {
                listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                //dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaFiltrada;
            }
            else { dgvProductos.DataSource = lista; }

            
        }

        // TOOL STRIP MENU

        private void tsMarca_Click(object sender, EventArgs e)
        {
            frmAgregarMarcaCategoria ventana = new frmAgregarMarcaCategoria(true);
            ventana.ShowDialog();
            recargar();
        }

        private void tsCategoria_Click(object sender, EventArgs e)
        {
            frmAgregarMarcaCategoria ventana = new frmAgregarMarcaCategoria();
            ventana.ShowDialog();
            recargar();
        }

        private void tsProducto_Click(object sender, EventArgs e)
        {
            frmAgregar ventana = new frmAgregar();
            ventana.ShowDialog();
            recargar();
        }

        private void tsBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            recargar();
            frmFiltro ventana = new frmFiltro();
            ventana.ShowDialog();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            frmEliminarMarcaCategoria ventana = new frmEliminarMarcaCategoria();
            ventana.ShowDialog();
            recargar();


        }

        
    }
}
