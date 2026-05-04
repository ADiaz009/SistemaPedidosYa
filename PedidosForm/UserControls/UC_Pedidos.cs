using SistemaPedidosYa.WinForms.Models;
using SistemaPedidosYa.WinForms.Services;
using SistemaPedidosYa.WinForms.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosForm.UserControls
{
    public partial class UC_Pedidos : UserControl
    {
        private readonly PedidoService _pedidoService = new PedidoService();
        private readonly ProductoService _productoService = new ProductoService();
        private List<ItemPedidoDTO> _itemsDelPedidoActual = new List<ItemPedidoDTO>();
        private Guid _idPedidoSeleccionado = Guid.Empty;
        public UC_Pedidos()
        {
            InitializeComponent();
            ConfigurarPantalla();
            CargarTablaPedidos();
        }

        private void LimpiarCampos()
        {
            _idPedidoSeleccionado = Guid.Empty; // Resetear ID de selección
            cmbMesa.SelectedIndex = -1;         // Deseleccionar mesa
            cmbProducto.SelectedIndex = -1;    // Deseleccionar producto
            numCantidad.Value = 1;              // Resetear cantidad a 1

            // Si tienes un label de total o algún campo extra, límpialo aquí
            if (cmbEstado.Visible) cmbEstado.SelectedIndex = -1;

            // Ponemos el foco de nuevo en la mesa para la siguiente orden
            cmbMesa.Focus();
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
            txtMesero.Text = Sesion.UsuarioActual.NombreCompleto;
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

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvPedidos.Rows[e.RowIndex];
                _idPedidoSeleccionado = (Guid)fila.Cells["Id"].Value; // Guardamos ID para actualizar/borrar

                cmbMesa.Text = fila.Cells["Mesa"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();
            }
        }

        private async void btnModificarOrden_Click(object sender, EventArgs e)
        {
            if (_idPedidoSeleccionado != Guid.Empty)
            {
                // 1. Creamos el objeto que el Service espera recibir
                var pedidoActualizado = new PedidosDetalleDTO
                {
                    Id = _idPedidoSeleccionado,
                    Estado = cmbEstado.Text // Aquí es donde viaja el nuevo estado
                };

                // 2. Ahora enviamos el objeto 'pedidoActualizado', no solo el string
                if (await _pedidoService.ActualizarEstadoAsync(_idPedidoSeleccionado, pedidoActualizado))
                {
                    MessageBox.Show("Estado actualizado.");
                    CargarTablaPedidos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido de la tabla.");
            }
        }
        private async void btnEliminarOrden_Click(object sender, EventArgs e)
        {
            if (_idPedidoSeleccionado != Guid.Empty)
            {
                if (await _pedidoService.EliminarPedidoAsync(_idPedidoSeleccionado))
                {
                    MessageBox.Show("Pedido eliminado.");
                    CargarTablaPedidos();
                    _idPedidoSeleccionado = Guid.Empty;
                }
            }
        }
    }
}
