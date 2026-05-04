namespace PedidosForm
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIniciarSesion = new Button();
            label1 = new Label();
            contraseña = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.FromArgb(128, 128, 255);
            btnIniciarSesion.Location = new Point(71, 211);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(209, 39);
            btnIniciarSesion.TabIndex = 0;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 99);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Usuario";
            // 
            // contraseña
            // 
            contraseña.AutoSize = true;
            contraseña.Location = new Point(28, 156);
            contraseña.Name = "contraseña";
            contraseña.Size = new Size(67, 15);
            contraseña.TabIndex = 2;
            contraseña.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(101, 91);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(214, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(101, 148);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(214, 23);
            txtContraseña.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(88, 19);
            label2.Name = "label2";
            label2.Size = new Size(164, 27);
            label2.TabIndex = 5;
            label2.Text = "Inicio de Sesión";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(128, 128, 255);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 64);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(128, 128, 255);
            groupBox2.Location = new Point(0, 282);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(347, 25);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(345, 305);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(contraseña);
            Controls.Add(label1);
            Controls.Add(btnIniciarSesion);
            Name = "FrmLogin";
            Text = "Sistena Diquiri";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIniciarSesion;
        private Label label1;
        private Label contraseña;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
