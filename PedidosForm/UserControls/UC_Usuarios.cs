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
    public partial class UC_Usuarios : UserControl
    {
        private readonly UsuarioService _usuarioService;
        private Guid _idUsuarioSeleccionado = Guid.Empty;
        public UC_Usuarios()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
            ConfigurarRoles();
            CargarTablaUsuarios();
        }
        private void ConfigurarRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Mesero");
            cmbRol.Items.Add("Cocinero");

            // Opcional: para que no puedan escribir texto libre en el combo
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;

            // Seleccionar el primero por defecto
            cmbRol.SelectedIndex = 0;
        }
        private async void CargarTablaUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerTodosAsync();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios;

            if (dgvUsuarios.Columns["Id"] != null)
            {
                dgvUsuarios.Columns["Id"].Visible = true;
                dgvUsuarios.Columns["Id"].HeaderText = "ID Usuario";
                dgvUsuarios.Columns["Id"].DisplayIndex = 0; // Ponerlo al principio
            }

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Si quieres que una columna específica (como el Nombre) sea más ancha que las otras:
            if (dgvUsuarios.Columns["NombreCompleto"] != null)
                dgvUsuarios.Columns["NombreCompleto"].FillWeight = 200;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                    // 2. Capturar el ID (Asegúrate que la columna en el DGV se llame "Id")
                    if (fila.Cells["Id"].Value is Guid guidId)
                    {
                        _idUsuarioSeleccionado = guidId;

                        // 3. Rellenar los controles con los nombres exactos de tu UsuarioDTO
                        txtNombreCompleto.Text = fila.Cells["NombreCompleto"].Value?.ToString();
                        txtNombreUsuario.Text = fila.Cells["NombreUsuario"].Value?.ToString();
                        txtPassword.Text = fila.Cells["Password"].Value?.ToString();
                        cmbRol.Text = fila.Cells["Rol"].Value?.ToString();

                        // AQUÍ ESTABA EL ERROR: Cambiado de 'EstaActivo' a 'Activo'
                        chkActivo.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);

                        // Feedback visual para estar seguros en la UNI
                        Console.WriteLine($"Usuario seleccionado correctamente: {txtNombreUsuario.Text} ({_idUsuarioSeleccionado})");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar usuario: " + ex.Message);
                }
            } 
        }

        private async void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("El nombre de usuario y la contraseña son obligatorios.");
                return;
            }

            // 2. OBTENER LISTA ACTUAL PARA COMPARAR
            // Asumimos que dgvUsuarios ya tiene la lista cargada
            var listaActual = (List<UsuarioDTO>)dgvUsuarios.DataSource;

            if (listaActual != null)
            {
                // 3. VALIDAR DUPLICADOS (Username o Nombre Completo)
                bool existeDuplicado = listaActual.Any(u =>
                    u.NombreUsuario.Trim().ToLower() == txtNombreUsuario.Text.Trim().ToLower() ||
                    u.NombreCompleto.Trim().ToLower() == txtNombreCompleto.Text.Trim().ToLower()
                );

                if (existeDuplicado)
                {
                    MessageBox.Show("Error: Ya existe un usuario con el mismo Nombre de Usuario o Nombre Completo.",
                                    "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Bloquea el registro inmediatamente
                }
            }

            // 4. SI NO HAY DUPLICADOS, PROCEDER CON EL REGISTRO
            var nuevo = new UsuarioDTO
            {
                NombreCompleto = txtNombreCompleto.Text,
                NombreUsuario = txtNombreUsuario.Text,
                Password = txtPassword.Text,
                Rol = cmbRol.Text,
                Activo = chkActivo.Checked
            };

            if (await _usuarioService.CrearUsuarioAsync(nuevo))
            {
                MessageBox.Show("Usuario registrado con éxito.");
                CargarTablaUsuarios();
                LimpiarFormulario();
            }
        }

        private async void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado == Guid.Empty)
            {
                MessageBox.Show("¡Oe! Primero selecciona un usuario de la tabla.");
                return;
            }
            var editado = new UsuarioDTO
            {
                Id = _idUsuarioSeleccionado,
                NombreCompleto = txtNombreCompleto.Text,
                NombreUsuario = txtNombreUsuario.Text,
                Password = txtPassword.Text,
                Rol = cmbRol.Text,
                Activo = chkActivo.Checked
            };

            if (await _usuarioService.ActualizarUsuarioAsync(_idUsuarioSeleccionado, editado))
            {
                MessageBox.Show("Usuario actualizado.");
                CargarTablaUsuarios();
            }
        }

        private async void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado == Guid.Empty)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la tabla.");
                return;
            }

            // 2. EL REEMPLAZO QUE BUSCÁBAMOS:
            // Comparamos el ID de la fila contra el ID del usuario que inició sesión
            if (_idUsuarioSeleccionado == Sesion.UsuarioActual.Id)
            {
                MessageBox.Show("No puedes eliminar el usuario con el que estás trabajando actualmente.",
                                "Error de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Si no es el mismo, pedimos confirmación y procedemos
            var confirm = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool eliminado = await _usuarioService.EliminarUsuarioAsync(_idUsuarioSeleccionado);
                if (eliminado)
                {
                    MessageBox.Show("Usuario eliminado exitosamente.");
                    CargarTablaUsuarios();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.");
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtNombreCompleto.Clear();
            txtNombreUsuario.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = -1;
            chkActivo.Checked = false;
            _idUsuarioSeleccionado = Guid.Empty;
        }
    }
}
