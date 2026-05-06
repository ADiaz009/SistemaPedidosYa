namespace PedidosForm
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnUsuarios = new Button();
            label1 = new Label();
            btnCerrarSesion = new Button();
            btnInventario = new Button();
            btnNuevaOrden = new Button();
            pnlContenedor = new Panel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(128, 128, 255);
            groupBox1.Controls.Add(btnUsuarios);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnCerrarSesion);
            groupBox1.Controls.Add(btnInventario);
            groupBox1.Controls.Add(btnNuevaOrden);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 575);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(192, 192, 255);
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Location = new Point(5, 336);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(185, 62);
            btnUsuarios.TabIndex = 4;
            btnUsuarios.Text = "Administrar Usuarios";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Times New Roman", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 56);
            label1.Name = "label1";
            label1.Size = new Size(107, 49);
            label1.TabIndex = 3;
            label1.Text = "Menú";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(192, 192, 255);
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Location = new Point(6, 438);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(185, 62);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnInventario
            // 
            btnInventario.BackColor = Color.FromArgb(192, 192, 255);
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Location = new Point(5, 235);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(185, 62);
            btnInventario.TabIndex = 1;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnNuevaOrden
            // 
            btnNuevaOrden.BackColor = Color.FromArgb(192, 192, 255);
            btnNuevaOrden.FlatStyle = FlatStyle.Flat;
            btnNuevaOrden.Location = new Point(6, 138);
            btnNuevaOrden.Name = "btnNuevaOrden";
            btnNuevaOrden.Size = new Size(185, 62);
            btnNuevaOrden.TabIndex = 0;
            btnNuevaOrden.Text = "Nueva Orden";
            btnNuevaOrden.UseVisualStyleBackColor = false;
            btnNuevaOrden.Click += btnNuevaOrden_Click;
            // 
            // pnlContenedor
            // 
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(200, 0);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(600, 575);
            pnlContenedor.TabIndex = 1;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 575);
            Controls.Add(pnlContenedor);
            Controls.Add(groupBox1);
            Name = "FrmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMenu";
            WindowState = FormWindowState.Maximized;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnNuevaOrden;
        private Label label1;
        private Button btnCerrarSesion;
        private Button btnInventario;
        private Panel pnlContenedor;
        private Button btnUsuarios;
    }
}