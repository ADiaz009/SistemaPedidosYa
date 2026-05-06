using SistemaPedidosYa.WinForms.Models;
using SistemaPedidosYa.WinForms.Services;
using SistemaPedidosYa.WinForms.Utils;

namespace PedidosForm.UserControls
{
    public partial class UC_Pedidos : UserControl
    {
        private readonly PedidoService _pedidoService = new PedidoService();
        private readonly ProductoService _productoService = new ProductoService();
        private Guid _idPedidoSeleccionado = Guid.Empty;
        public UC_Pedidos()
        {
            InitializeComponent();
            ConfigurarPantalla();
            CargarTablaPedidos();
            CargarEstados();
        }

        private void CargarEstados()
        {
            cmbEstado.Items.AddRange(new string[]
            {
                "Pendiente",
                "En preparación",
                "Listo",
                "Entregado",
                "Cancelado"
            });
        }

        private void LimpiarCampos()
        {
            _idPedidoSeleccionado = Guid.Empty;
            cmbMesa.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            numCantidad.Value = 1;
            cmbEstado.SelectedIndex = -1;
        }

        private async void ConfigurarPantalla()
        {
            // Llenamos mesas del 1 al 15
            for (int i = 1; i <= 15; i++) cmbMesa.Items.Add($"Mesa {i}");

            // Cargamos productos reales desde MongoDB
            var productos = await _productoService.ObtenerTodoAsync();
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";

            // Mesero actual de la sesión
            txtMesero.Text = Sesion.UsuarioActual!.NombreCompleto;
            txtMesero.ReadOnly = true;
        }

        private async void CargarTablaPedidos()
        {
            // Refresca el DataGridView con lo que hay en la base de datos
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = await _pedidoService.GetPedidosAsync();
        }

        private async void btnCrearOrden_Click(object sender, EventArgs e)
        {
            if (cmbMesa.SelectedIndex == -1 || cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona una Mesa y un Producto.");
                return;
            }

            if (cmbProducto.SelectedItem is ProductoDTO prod)
            {
                var item = new ItemPedidoDTO
                {
                    ProductoId = prod.Id,
                    ProductoNombre = prod.Nombre,
                    PrecioUnitario = prod.Precio,
                    Categoria = prod.Categoria,
                    Cantidad = (int)numCantidad.Value
                };

                var nuevoPedido = new PedidosDetalleDTO
                {
                    Mesa = cmbMesa.Text,
                    Mesero = txtMesero.Text,
                    Estado = "Pendiente",
                    NumeroOrden = "ORD-" + DateTime.Now.Ticks.ToString().Substring(12),
                    Items = new List<ItemPedidoDTO> { item }
                };

                if (await _pedidoService.CrearPedidoAsync(nuevoPedido))
                {
                    MessageBox.Show("Pedido registrado directamente.");

                    // --- AQUÍ SE DISPARA LA LIMPIEZA ---
                    LimpiarCampos();

                    CargarTablaPedidos();
                }
            }
        }

        private async void btnModificarOrden_Click(object sender, EventArgs e)
        {
            if (_idPedidoSeleccionado == Guid.Empty)
            {
                MessageBox.Show("Seleccione un pedido.");
                return;
            }

            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            if (!decimal.TryParse(numCantidad.Value.ToString(), out _))
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }

            // 🔥 RECONSTRUIR ITEM DESDE LA UI
            var prod = (ProductoDTO)cmbProducto.SelectedItem;

            var item = new ItemPedidoDTO
            {
                ProductoId = prod.Id,
                ProductoNombre = prod.Nombre,
                PrecioUnitario = prod.Precio,
                Categoria = prod.Categoria,
                Cantidad = (int)numCantidad.Value
            };

            var pedidoActualizado = new PedidosDetalleDTO
            {
                Id = _idPedidoSeleccionado,
                NumeroOrden = txtNumeroOrden.Text,
                Mesero = txtMesero.Text,
                Mesa = cmbMesa.Text,
                Estado = cmbEstado.Text,

                // 🔥 AQUÍ ESTÁ LA CLAVE
                Items = new List<ItemPedidoDTO> { item }
            };

            bool ok = await _pedidoService.ActualizarEstadoAsync(_idPedidoSeleccionado, pedidoActualizado);

            if (ok)
            {
                MessageBox.Show("Pedido actualizado correctamente.");
                CargarTablaPedidos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar pedido.");
            }
        }

        private async void btnEliminarOrden_Click(object sender, EventArgs e)
        {
            if (_idPedidoSeleccionado == Guid.Empty)
            {
                MessageBox.Show("Seleccione un pedido.");
                return;
            }

            var confirm = MessageBox.Show(
                "¿Eliminar este pedido?",
                "Confirmar",
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                bool ok = await _pedidoService.EliminarPedidoAsync(_idPedidoSeleccionado);

                if (ok)
                {
                    MessageBox.Show("Pedido eliminado.");
                    CargarTablaPedidos();
                    LimpiarCampos();
                }
            }
        }

        private void dgvPedidos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvPedidos.Rows[e.RowIndex];

            var pedido = (PedidosDetalleDTO)fila.DataBoundItem;

            _idPedidoSeleccionado = pedido.Id;

            txtNumeroOrden.Text = pedido.NumeroOrden;
            txtMesero.Text = pedido.Mesero;
            cmbMesa.Text = pedido.Mesa;
            cmbEstado.Text = pedido.Estado;

            if (pedido.Items != null && pedido.Items.Count > 0)
            {
                var item = pedido.Items.First();

                cmbProducto.SelectedValue = item.ProductoId;
                numCantidad.Value = item.Cantidad;
            }
        }
    }
}
