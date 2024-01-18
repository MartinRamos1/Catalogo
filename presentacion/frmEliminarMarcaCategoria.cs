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
    public partial class frmEliminarMarcaCategoria : Form
    {
        AccesoDatos datos = new AccesoDatos();
        MarcaNegocio marcaNegocio = new MarcaNegocio();
        ProductoNegocio negocio = new ProductoNegocio();
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        public frmEliminarMarcaCategoria()
        {
            InitializeComponent();
        }

        private void frmEliminarMarcaCategoria_Load(object sender, EventArgs e)
        {
            cboTipo.Items.Add("Marcas");
            cboTipo.Items.Add("Categorías");
            cboTipo.SelectedIndex = 0;

            cboSeleccion.DataSource = marcaNegocio.Listar();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem.ToString() == "Marcas")

                cboSeleccion.DataSource = marcaNegocio.Listar();
            else
                cboSeleccion.DataSource = categoriaNegocio.Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string opcion = cboTipo.SelectedItem.ToString();
                
                if (opcion == "Marcas")
                {
                    Marca seleccionada = (Marca)cboSeleccion.SelectedItem;
                    DialogResult respuesta = MessageBox.Show("Eliminar " + seleccionada.Descripcion + " definitivamente?", "Eliminar", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        DialogResult respuesta1 = MessageBox.Show("Al eliminar " + seleccionada.Descripcion + " se eliminaran todos los articulos de esta marca definitivamente ¿Estás seguro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (respuesta1 == DialogResult.Yes)
                        {
                            datos.setearConsulta("Delete from MARCAS Where Id = @id");
                            datos.setearParametros("id", seleccionada.Id);
                            datos.ejecutarAccion();

                            MessageBox.Show(seleccionada.Descripcion + " eliminada correctamente de marcas");
                            Close();
                        }  
                    }
                }
                else
                {
                    Categoria seleccionada = (Categoria)cboSeleccion.SelectedItem;
                    DialogResult respuesta = MessageBox.Show("Eliminar " + seleccionada.Descripcion + " definitivamente?", "Eliminar", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        DialogResult respuesta1 = MessageBox.Show("Al eliminar " + seleccionada.Descripcion + " se eliminaran todos los articulos de esta categoría definitivamente ¿Estás seguro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (respuesta1 == DialogResult.Yes)
                        {
                            datos.setearConsulta("Delete from CATEGORIAS Where Id = @id");
                            datos.setearParametros("id", seleccionada.Id);
                            datos.ejecutarAccion();

                            MessageBox.Show(seleccionada.Descripcion + " eliminada correctamente de categorías");
                            Close();
                        }
                        
                    }
                }   
                
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }

        }

        
    }
}
