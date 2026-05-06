using PedidosForm.UserControls;
using SistemaPedidosYa.WinForms.Utils;

namespace PedidosForm
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void AbrirPanelHijo(UserControl ucHijo)
        {
            // 1. Limpiamos lo que haya en el panel central para que no se encimen
            if (this.pnlContenedor.Controls.Count > 0)
            {
                this.pnlContenedor.Controls.Clear();
            }

            // 2. Hacemos que el User Control ocupe todo el espacio del panel
            ucHijo.Dock = DockStyle.Fill;

            // 3. Lo agregamos a la colección de controles del panel y lo mostramos
            this.pnlContenedor.Controls.Add(ucHijo);
            ucHijo.Show();
        }
        private void btnNuevaOrden_Click(object sender, EventArgs e)
        {
            // Instanciamos el User Control que creamos con el CRUD de pedidos
            UC_Pedidos ucPedidos = new UC_Pedidos();

            // Lo mandamos a llamar al panel central
            AbrirPanelHijo(ucPedidos);

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual!.Rol == "Administrador")
            {
                AbrirPanelHijo(new UC_Inventario());

            }
            else
            {
                MessageBox.Show("Acceso denegado. Esta sección es exclusiva para Administradores.",
                                "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Seguro que desea cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Sesion.UsuarioActual = null;

                FrmLogin login = new FrmLogin();
                login.Show();

                this.Close();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual!.Rol == "Administrador")
            {
                AbrirPanelHijo(new UC_Usuarios());

            }
            else
            {
                MessageBox.Show("Acceso denegado. Esta sección es exclusiva para Administradores.",
                                "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
