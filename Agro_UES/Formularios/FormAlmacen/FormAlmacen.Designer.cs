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
            this.btnalertas = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnregistro
            // 
            this.btnregistro.Location = new System.Drawing.Point(79, 35);
            this.btnregistro.Name = "btnregistro";
            this.btnregistro.Size = new System.Drawing.Size(203, 52);
            this.btnregistro.TabIndex = 0;
            this.btnregistro.Text = "Registrar productos";
            this.btnregistro.UseVisualStyleBackColor = true;
            this.btnregistro.Click += new System.EventHandler(this.btnregistro_Click);
            // 
            // btnactualizarinv
            // 
            this.btnactualizarinv.Location = new System.Drawing.Point(79, 119);
            this.btnactualizarinv.Name = "btnactualizarinv";
            this.btnactualizarinv.Size = new System.Drawing.Size(203, 52);
            this.btnactualizarinv.TabIndex = 1;
            this.btnactualizarinv.Text = "Actualizar inventario";
            this.btnactualizarinv.UseVisualStyleBackColor = true;
            this.btnactualizarinv.Click += new System.EventHandler(this.btnactualizarinv_Click);
            // 
            // btncategorias
            // 
            this.btncategorias.Location = new System.Drawing.Point(79, 251);
            this.btncategorias.Name = "btncategorias";
            this.btncategorias.Size = new System.Drawing.Size(203, 52);
            this.btncategorias.TabIndex = 2;
            this.btncategorias.Text = "Gestionar categorias";
            this.btncategorias.UseVisualStyleBackColor = true;
            this.btncategorias.Click += new System.EventHandler(this.btncategorias_Click);
            // 
            // btnalertas
            // 
            this.btnalertas.Location = new System.Drawing.Point(79, 325);
            this.btnalertas.Name = "btnalertas";
            this.btnalertas.Size = new System.Drawing.Size(203, 52);
            this.btnalertas.TabIndex = 3;
            this.btnalertas.Text = "Generar alertas";
            this.btnalertas.UseVisualStyleBackColor = true;
            this.btnalertas.Click += new System.EventHandler(this.btnalertas_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.Location = new System.Drawing.Point(201, 404);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(139, 34);
            this.btnsalir.TabIndex = 8;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // FormAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 450);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btnalertas);
            this.Controls.Add(this.btncategorias);
            this.Controls.Add(this.btnactualizarinv);
            this.Controls.Add(this.btnregistro);
            this.Name = "FormAlmacen";
            this.Text = "FormAlmacen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnregistro;
        private System.Windows.Forms.Button btnactualizarinv;
        private System.Windows.Forms.Button btncategorias;
        private System.Windows.Forms.Button btnalertas;
        private System.Windows.Forms.Button btnsalir;
    }
}