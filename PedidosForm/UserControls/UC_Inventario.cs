using SistemaPedidosYa.WinForms.Models;
using SistemaPedidosYa.WinForms.Services;

namespace PedidosForm.UserControls
{
    public partial class UC_Inventario : UserControl
    {
        private string _imagenBase64 = "";
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvInventario.Rows[e.RowIndex];

                _idProductoSeleccionado = Guid.Parse(fila.Cells["Id"].Value.ToString()!);

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                cmbCategoria.Text = fila.Cells["Categoria"].Value.ToString();
                chkDisponible.Checked = (bool)fila.Cells["EstaDisponible"].Value;

                var imagen = fila.Cells["ImagenUrl"].Value?.ToString();

                _imagenBase64 = imagen ?? "";

                if (!string.IsNullOrEmpty(imagen))
                {
                    byte[] imageBytes = Convert.FromBase64String(imagen);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
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
                    ImagenUrl = string.IsNullOrEmpty(_imagenBase64)
                    ? ""
                    : _imagenBase64
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
                EstaDisponible = chkDisponible.Checked,
                ImagenUrl = string.IsNullOrEmpty(_imagenBase64) ? "" : _imagenBase64
            };

            if (await _productoService.ActualizarProductoAsync(_idProductoSeleccionado, productoEditado))
            {
                MessageBox.Show("Producto actualizado.");
                CargarTablaProductos();
                LimpiarCampos();
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
            txtNombre.Focus();
            pictureBox1.Image = null;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquea cualquier otra tecla que no sea numero o punto decimal
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png";
                ofd.Title = "Seleccionar imagen del producto";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Mostrar en PictureBox
                    pictureBox1.Image = Image.FromFile(ofd.FileName);

                    // Convertir a Base64
                    byte[] imageBytes = File.ReadAllBytes(ofd.FileName);
                    _imagenBase64 = Convert.ToBase64String(imageBytes);
                }
            }
        }
    }
}
