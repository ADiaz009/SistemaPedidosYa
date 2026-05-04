using PedidosForm.UserControls;
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
            if (Sesion.UsuarioActual.Rol == "Administrador")
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

        }
    }
}
