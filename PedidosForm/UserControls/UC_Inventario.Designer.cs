namespace PedidosForm.UserControls
{
    partial class UC_Inventario
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
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            cmbCategoria = new ComboBox();
            txtPrecio = new TextBox();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            chkDisponible = new CheckBox();
            btnEliminarProducto = new Button();
            btnSeleccionarImagen = new Button();
            btnAgregarProducto = new Button();
            btnEditarProducto = new Button();
            dgvInventario = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.WhiteSmoke;
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(cmbCategoria);
            groupBox1.Controls.Add(txtPrecio);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(chkDisponible);
            groupBox1.Controls.Add(btnEliminarProducto);
            groupBox1.Controls.Add(btnSeleccionarImagen);
            groupBox1.Controls.Add(btnAgregarProducto);
            groupBox1.Controls.Add(btnEditarProducto);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(293, 538);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(31, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(241, 152);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(119, 353);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(153, 23);
            cmbCategoria.TabIndex = 23;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(121, 319);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(151, 23);
            txtPrecio.TabIndex = 22;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(119, 247);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(153, 66);
            txtDescripcion.TabIndex = 21;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(121, 210);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 23);
            txtNombre.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 356);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 18;
            label4.Text = "Categoría";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 322);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 17;
            label3.Text = "Precio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 259);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 16;
            label2.Text = "Descripición";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 213);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 15;
            label1.Text = "Nombre";
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Location = new Point(121, 382);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(82, 19);
            chkDisponible.TabIndex = 14;
            chkDisponible.Text = "Disponible";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.BackColor = Color.FromArgb(192, 192, 255);
            btnEliminarProducto.FlatStyle = FlatStyle.Flat;
            btnEliminarProducto.Location = new Point(31, 485);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(209, 33);
            btnEliminarProducto.TabIndex = 13;
            btnEliminarProducto.Text = "Eliminar Producto";
            btnEliminarProducto.UseVisualStyleBackColor = false;
            btnEliminarProducto.Click += btnEliminarProducto_Click;
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.BackColor = Color.FromArgb(192, 192, 255);
            btnSeleccionarImagen.FlatStyle = FlatStyle.Flat;
            btnSeleccionarImagen.Location = new Point(49, 180);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(209, 24);
            btnSeleccionarImagen.TabIndex = 12;
            btnSeleccionarImagen.Text = "Agregar Imagen";
            btnSeleccionarImagen.UseVisualStyleBackColor = false;
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.FromArgb(192, 192, 255);
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Location = new Point(31, 407);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(209, 33);
            btnAgregarProducto.TabIndex = 12;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.BackColor = Color.FromArgb(192, 192, 255);
            btnEditarProducto.FlatStyle = FlatStyle.Flat;
            btnEditarProducto.Location = new Point(31, 446);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(209, 33);
            btnEditarProducto.TabIndex = 11;
            btnEditarProducto.Text = "Editar Producto";
            btnEditarProducto.UseVisualStyleBackColor = false;
            btnEditarProducto.Click += btnEditarProducto_Click;
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Dock = DockStyle.Fill;
            dgvInventario.Location = new Point(293, 0);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.Size = new Size(449, 538);
            dgvInventario.TabIndex = 1;
            dgvInventario.CellClick += dataGridView1_CellClick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // UC_Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(dgvInventario);
            Controls.Add(groupBox1);
            Name = "UC_Inventario";
            Size = new Size(742, 538);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvInventario;
        private Button btnEliminarProducto;
        private Button btnAgregarProducto;
        private Button btnEditarProducto;
        private TextBox txtPrecio;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox chkDisponible;
        private ComboBox cmbCategoria;
        private PictureBox pictureBox1;
        private Button btnSeleccionarImagen;
        private OpenFileDialog openFileDialog1;
    }
}
