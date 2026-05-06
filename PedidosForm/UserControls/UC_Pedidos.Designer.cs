namespace PedidosForm.UserControls
{
    partial class UC_Pedidos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPedidos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNumeroOrden = new TextBox();
            txtMesero = new TextBox();
            groupBox1 = new GroupBox();
            numCantidad = new NumericUpDown();
            label5 = new Label();
            cmbProducto = new ComboBox();
            btnEliminarOrden = new Button();
            btnModificarOrden = new Button();
            btnCrearOrden = new Button();
            cmbMesa = new ComboBox();
            cmbEstado = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Dock = DockStyle.Fill;
            dgvPedidos.Location = new Point(0, 0);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.Size = new Size(742, 366);
            dgvPedidos.TabIndex = 0;
            dgvPedidos.CellClick += dgvPedidos_CellClick_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 13);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 1;
            label1.Text = "Numero de Orden";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 56);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 2;
            label2.Text = "Mesa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 104);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 3;
            label3.Text = "Mesero";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 149);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 4;
            label4.Text = "Estado";
            // 
            // txtNumeroOrden
            // 
            txtNumeroOrden.BackColor = Color.White;
            txtNumeroOrden.BorderStyle = BorderStyle.None;
            txtNumeroOrden.Location = new Point(158, 12);
            txtNumeroOrden.Name = "txtNumeroOrden";
            txtNumeroOrden.ReadOnly = true;
            txtNumeroOrden.Size = new Size(121, 16);
            txtNumeroOrden.TabIndex = 5;
            // 
            // txtMesero
            // 
            txtMesero.BorderStyle = BorderStyle.None;
            txtMesero.Location = new Point(158, 96);
            txtMesero.Name = "txtMesero";
            txtMesero.Size = new Size(121, 16);
            txtMesero.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.WhiteSmoke;
            groupBox1.Controls.Add(numCantidad);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cmbProducto);
            groupBox1.Controls.Add(btnEliminarOrden);
            groupBox1.Controls.Add(btnModificarOrden);
            groupBox1.Controls.Add(btnCrearOrden);
            groupBox1.Controls.Add(cmbMesa);
            groupBox1.Controls.Add(cmbEstado);
            groupBox1.Controls.Add(txtMesero);
            groupBox1.Controls.Add(txtNumeroOrden);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(290, 366);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(236, 184);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(43, 23);
            numCantidad.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 191);
            label5.Name = "label5";
            label5.Size = new Size(116, 15);
            label5.TabIndex = 14;
            label5.Text = "Producto y Cantidad";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(158, 183);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(64, 23);
            cmbProducto.TabIndex = 13;
            // 
            // btnEliminarOrden
            // 
            btnEliminarOrden.BackColor = Color.FromArgb(192, 192, 255);
            btnEliminarOrden.FlatStyle = FlatStyle.Flat;
            btnEliminarOrden.Location = new Point(32, 306);
            btnEliminarOrden.Name = "btnEliminarOrden";
            btnEliminarOrden.Size = new Size(209, 33);
            btnEliminarOrden.TabIndex = 12;
            btnEliminarOrden.Text = "Eliminar Orden";
            btnEliminarOrden.UseVisualStyleBackColor = false;
            btnEliminarOrden.Click += btnEliminarOrden_Click;
            // 
            // btnModificarOrden
            // 
            btnModificarOrden.BackColor = Color.FromArgb(192, 192, 255);
            btnModificarOrden.FlatStyle = FlatStyle.Flat;
            btnModificarOrden.Location = new Point(32, 267);
            btnModificarOrden.Name = "btnModificarOrden";
            btnModificarOrden.Size = new Size(209, 33);
            btnModificarOrden.TabIndex = 11;
            btnModificarOrden.Text = "Modificar Orden";
            btnModificarOrden.UseVisualStyleBackColor = false;
            btnModificarOrden.Click += btnModificarOrden_Click;
            // 
            // btnCrearOrden
            // 
            btnCrearOrden.BackColor = Color.FromArgb(192, 192, 255);
            btnCrearOrden.FlatStyle = FlatStyle.Flat;
            btnCrearOrden.Location = new Point(32, 228);
            btnCrearOrden.Name = "btnCrearOrden";
            btnCrearOrden.Size = new Size(209, 33);
            btnCrearOrden.TabIndex = 10;
            btnCrearOrden.Text = "Crear Orden";
            btnCrearOrden.UseVisualStyleBackColor = false;
            btnCrearOrden.Click += btnCrearOrden_Click;
            // 
            // cmbMesa
            // 
            cmbMesa.FormattingEnabled = true;
            cmbMesa.Location = new Point(158, 48);
            cmbMesa.Name = "cmbMesa";
            cmbMesa.Size = new Size(121, 23);
            cmbMesa.TabIndex = 9;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(158, 141);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 8;
            // 
            // UC_Pedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(groupBox1);
            Controls.Add(dgvPedidos);
            Name = "UC_Pedidos";
            Size = new Size(742, 366);
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPedidos;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNumeroOrden;
        private TextBox txtMesero;
        private GroupBox groupBox1;
        private ComboBox cmbEstado;
        private Button btnEliminarOrden;
        private Button btnModificarOrden;
        private Button btnCrearOrden;
        private ComboBox cmbMesa;
        private Label label5;
        private ComboBox cmbProducto;
        private NumericUpDown numCantidad;
    }
}
