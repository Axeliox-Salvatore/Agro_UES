namespace Agro_UES
{
    partial class FormAlmacen
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
            this.btnregistro = new System.Windows.Forms.Button();
            this.btnactualizarinv = new System.Windows.Forms.Button();
            this.btncategorias = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnalertas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnregistro
            // 
            this.btnregistro.Location = new System.Drawing.Point(105, 43);
            this.btnregistro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnregistro.Name = "btnregistro";
            this.btnregistro.Size = new System.Drawing.Size(271, 64);
            this.btnregistro.TabIndex = 0;
            this.btnregistro.Text = "Registrar productos";
            this.btnregistro.UseVisualStyleBackColor = true;
            this.btnregistro.Click += new System.EventHandler(this.btnregistro_Click);
            // 
            // btnactualizarinv
            // 
            this.btnactualizarinv.Location = new System.Drawing.Point(105, 146);
            this.btnactualizarinv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnactualizarinv.Name = "btnactualizarinv";
            this.btnactualizarinv.Size = new System.Drawing.Size(271, 64);
            this.btnactualizarinv.TabIndex = 1;
            this.btnactualizarinv.Text = "Actualizar inventario";
            this.btnactualizarinv.UseVisualStyleBackColor = true;
            this.btnactualizarinv.Click += new System.EventHandler(this.btnactualizarinv_Click);
            // 
            // btncategorias
            // 
            this.btncategorias.Location = new System.Drawing.Point(105, 309);
            this.btncategorias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btncategorias.Name = "btncategorias";
            this.btncategorias.Size = new System.Drawing.Size(271, 64);
            this.btncategorias.TabIndex = 2;
            this.btncategorias.Text = "Gestionar categorias";
            this.btncategorias.UseVisualStyleBackColor = true;
            this.btncategorias.Click += new System.EventHandler(this.btncategorias_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.Location = new System.Drawing.Point(268, 497);
            this.btnsalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(185, 42);
            this.btnsalir.TabIndex = 8;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btnalertas
            // 
            this.btnalertas.Location = new System.Drawing.Point(105, 400);
            this.btnalertas.Margin = new System.Windows.Forms.Padding(4);
            this.btnalertas.Name = "btnalertas";
            this.btnalertas.Size = new System.Drawing.Size(271, 64);
            this.btnalertas.TabIndex = 3;
            this.btnalertas.Text = "Generar alertas";
            this.btnalertas.UseVisualStyleBackColor = true;
            this.btnalertas.Click += new System.EventHandler(this.btnalertas_Click);
            // 
            // FormAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 554);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btnalertas);
            this.Controls.Add(this.btncategorias);
            this.Controls.Add(this.btnactualizarinv);
            this.Controls.Add(this.btnregistro);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAlmacen";
            this.Text = "FormAlmacen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnregistro;
        private System.Windows.Forms.Button btnactualizarinv;
        private System.Windows.Forms.Button btncategorias;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnalertas;
    }
}