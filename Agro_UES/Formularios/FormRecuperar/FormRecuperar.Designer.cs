namespace Agro_UES
{
    partial class FormRecuperar
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
            this.panelEnvio = new System.Windows.Forms.GroupBox();
            this.bltitulo = new System.Windows.Forms.Label();
            this.btnEnviarCodigo = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.panelVerificacion = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNuevaContraseña = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.panelEnvio.SuspendLayout();
            this.panelVerificacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnvio
            // 
            this.panelEnvio.Controls.Add(this.txtCorreo);
            this.panelEnvio.Controls.Add(this.btnEnviarCodigo);
            this.panelEnvio.Controls.Add(this.bltitulo);
            this.panelEnvio.Location = new System.Drawing.Point(183, 63);
            this.panelEnvio.Name = "panelEnvio";
            this.panelEnvio.Size = new System.Drawing.Size(443, 211);
            this.panelEnvio.TabIndex = 0;
            this.panelEnvio.TabStop = false;
            this.panelEnvio.Text = "verifica tu correo";
            // 
            // bltitulo
            // 
            this.bltitulo.AutoSize = true;
            this.bltitulo.Location = new System.Drawing.Point(140, 47);
            this.bltitulo.Name = "bltitulo";
            this.bltitulo.Size = new System.Drawing.Size(107, 16);
            this.bltitulo.TabIndex = 0;
            this.bltitulo.Text = "Ingresa tu correo";
            // 
            // btnEnviarCodigo
            // 
            this.btnEnviarCodigo.Location = new System.Drawing.Point(158, 157);
            this.btnEnviarCodigo.Name = "btnEnviarCodigo";
            this.btnEnviarCodigo.Size = new System.Drawing.Size(75, 23);
            this.btnEnviarCodigo.TabIndex = 1;
            this.btnEnviarCodigo.Text = "enviar";
            this.btnEnviarCodigo.UseVisualStyleBackColor = true;
            this.btnEnviarCodigo.Click += new System.EventHandler(this.btnEnviarCodigo_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(147, 94);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(100, 22);
            this.txtCorreo.TabIndex = 2;
            // 
            // panelVerificacion
            // 
            this.panelVerificacion.Controls.Add(this.btnVerificar);
            this.panelVerificacion.Controls.Add(this.txtCodigo);
            this.panelVerificacion.Controls.Add(this.txtNuevaContraseña);
            this.panelVerificacion.Controls.Add(this.label2);
            this.panelVerificacion.Controls.Add(this.label1);
            this.panelVerificacion.Location = new System.Drawing.Point(183, 306);
            this.panelVerificacion.Name = "panelVerificacion";
            this.panelVerificacion.Size = new System.Drawing.Size(450, 209);
            this.panelVerificacion.TabIndex = 1;
            this.panelVerificacion.TabStop = false;
            this.panelVerificacion.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de verificacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nueva contraseña";
            // 
            // txtNuevaContraseña
            // 
            this.txtNuevaContraseña.Location = new System.Drawing.Point(219, 37);
            this.txtNuevaContraseña.Name = "txtNuevaContraseña";
            this.txtNuevaContraseña.Size = new System.Drawing.Size(100, 22);
            this.txtNuevaContraseña.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(219, 78);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 22);
            this.txtCodigo.TabIndex = 1;
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(190, 159);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(75, 23);
            this.btnVerificar.TabIndex = 2;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // FormRecuperar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 565);
            this.Controls.Add(this.panelVerificacion);
            this.Controls.Add(this.panelEnvio);
            this.Name = "FormRecuperar";
            this.Text = "FormRecuperar";
            this.panelEnvio.ResumeLayout(false);
            this.panelEnvio.PerformLayout();
            this.panelVerificacion.ResumeLayout(false);
            this.panelVerificacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox panelEnvio;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button btnEnviarCodigo;
        private System.Windows.Forms.Label bltitulo;
        private System.Windows.Forms.GroupBox panelVerificacion;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNuevaContraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}