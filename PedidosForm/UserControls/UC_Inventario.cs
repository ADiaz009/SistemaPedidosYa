using SistemaPedidosYa.WinForms.Models;
using SistemaPedidosYa.WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PedidosForm.UserControls
{
    public partial class UC_Inventario : UserControl
    {
        private readonly ProductoService _productoService = new ProductoService();
        private Guid _idProductoSeleccionado = Guid.Empty;
        public UC_Inventario()
        {
            InitializeComponent();
            ConfigurarCategorias();
            CargarTablaProductos();
        }

        private void ConfigurarCategorias()
        {
            // Evitamos errores de escritura usando un ComboBox
            cmbCategoria.Items.AddRange(new string[] { "Entradas", "Platos Fuertes", "Bebidas", "Postres" });
        }
        private async void CargarTablaProductos()
        {
            try
            {
                // 1. Obtenemos la lista fresca de MongoDB
                var lista = await _productoService.ObtenerTodoAsync();

                // 2. IMPORTANTE: Desvincular la fuente actual
                dgvInventario.DataSource = null;

                // 3. Vincular la nueva lista
                dgvInventario.DataSource = lista;

                // 4. Forzar el dibujado de la tabla
                dgvInventario.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tabla: {ex.Message}");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvInventario.Rows[e.RowIndex];
                _idProductoSeleccionado = (Guid)fila.Cells["Id"].Value;

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                cmbCategoria.Text = fila.Cells["Categoria"].Value.ToString();
                chkDisponible.Checked = (bool)fila.Cells["EstaDisponible"].Value;
            }
        }

        private async void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Iniciando proceso de guardado...");

            try
            {
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio)) return;

                var nuevo = new ProductoDTO
                {
                    Id = Guid.NewGuid(),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    Categoria = cmbCategoria.Text,
                    EstaDisponible = chkDisponible.Checked,
                    // AGREGAMOS LA URL DE IMAGEN (El campo que faltaba)
                    ImagenUrl = "https://via.placeholder.com/150" // URL genérica para que la API valide
                };

                bool exito = await _productoService.CrearProductoAsync(nuevo);

                if (exito)
                {
                    MessageBox.Show("¡Producto guardado con éxito!");
                    LimpiarCampos();
                    CargarTablaProductos();
                }
                else
                {
                    MessageBox.Show("La API rechazó el producto. Verifica que 'ImagenUrl' no sea obligatorio en el Backend.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (_idProductoSeleccionado == Guid.Empty)
            {
                MessageBox.Show("Seleccione un producto de la tabla para editar.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio)) return;

            var productoEditado = new ProductoDTO
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = precio,
                Categoria = cmbCategoria.Text,
                EstaDisponible = chkDisponible.Checked
            };

            if (await _productoService.ActualizarProductoAsync(_idProductoSeleccionado, productoEditado))
            {
                MessageBox.Show("Producto actualizado.");
                CargarTablaProductos();
            }
        }

        private async void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (_idProductoSeleccionado == Guid.Empty) return;

            var confirm = MessageBox.Show("¿Seguro que desea eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (await _productoService.EliminarProductoAsync(_idProductoSeleccionado))
                {
                    MessageBox.Show("Producto eliminado.");
                    LimpiarCampos();
                    CargarTablaProductos();
                }
            }
        }

        private void LimpiarCampos()
        {
            _idProductoSeleccionado = Guid.Empty;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            cmbCategoria.SelectedIndex = -1;
            chkDisponible.Checked = true;
            txtNombre.Focus(); // El foco vuelve al inicio para rapidez
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Especificamos System.Windows.Forms.TextBox para eliminar la ambigüedad
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
