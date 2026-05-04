using SistemaPedidosYa.WinForms.Services;
using SistemaPedidosYa.WinForms.Utils;

namespace PedidosForm
{
    public partial class FrmLogin : Form
    {
        private readonly AuthService _authService;
        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, ingrese sus credenciales.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deshabilitar botón para evitar múltiples clics
            btnIniciarSesion.Enabled = false;

            try
            {
                // 2. Llamada al servicio que conecta con la API
                var usuario = await _authService.LoginAsync(txtUsuario.Text, txtContraseña.Text);

                if (usuario != null)
                {
                    // 3. Guardar el usuario en la sesión global para usarlo en los pedidos
                    Sesion.UsuarioActual = usuario;

                    MessageBox.Show($"¡Bienvenido {usuario.NombreCompleto}!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Abrir el formulario principal y ocultar el login
                    FrmMenu menu = new FrmMenu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión con el servidor: {ex.Message}", "Error Técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnIniciarSesion.Enabled = true;
            }
        }
    }
}
