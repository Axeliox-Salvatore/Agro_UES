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
            this.components = new System.ComponentModel.Container();
            this.btnregistro = new System.Windows.Forms.Button();
            this.btnactualizarinv = new System.Windows.Forms.Button();
            this.btncategorias = new System.Windows.Forms.Button();
            this.btnalertas = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.dgvStocBajo = new System.Windows.Forms.DataGridView();
            this.dgvVecimientos = new System.Windows.Forms.DataGridView();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.relojHora = new System.Windows.Forms.Timer(this.components);
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProductoV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelLateral.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocBajo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVecimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnregistro
            // 
            this.btnregistro.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnregistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregistro.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnregistro.ForeColor = System.Drawing.Color.White;
            this.btnregistro.Location = new System.Drawing.Point(3, 22);
            this.btnregistro.Margin = new System.Windows.Forms.Padding(4);
            this.btnregistro.Name = "btnregistro";
            this.btnregistro.Size = new System.Drawing.Size(213, 64);
            this.btnregistro.TabIndex = 0;
            this.btnregistro.Text = "Registrar productos";
            this.btnregistro.UseVisualStyleBackColor = false;
            this.btnregistro.Click += new System.EventHandler(this.btnregistro_Click);
            // 
            // btnactualizarinv
            // 
            this.btnactualizarinv.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnactualizarinv.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnactualizarinv.ForeColor = System.Drawing.Color.White;
            this.btnactualizarinv.Location = new System.Drawing.Point(0, 94);
            this.btnactualizarinv.Margin = new System.Windows.Forms.Padding(4);
            this.btnactualizarinv.Name = "btnactualizarinv";
            this.btnactualizarinv.Size = new System.Drawing.Size(213, 64);
            this.btnactualizarinv.TabIndex = 1;
            this.btnactualizarinv.Text = "Actualizar inventario";
            this.btnactualizarinv.UseVisualStyleBackColor = false;
            this.btnactualizarinv.Click += new System.EventHandler(this.btnactualizarinv_Click);
            // 
            // btncategorias
            // 
            this.btncategorias.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btncategorias.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btncategorias.ForeColor = System.Drawing.Color.White;
            this.btncategorias.Location = new System.Drawing.Point(0, 176);
            this.btncategorias.Margin = new System.Windows.Forms.Padding(4);
            this.btncategorias.Name = "btncategorias";
            this.btncategorias.Size = new System.Drawing.Size(213, 64);
            this.btncategorias.TabIndex = 2;
            this.btncategorias.Text = "Gestionar categorias";
            this.btncategorias.UseVisualStyleBackColor = false;
            this.btncategorias.Click += new System.EventHandler(this.btncategorias_Click);
            // 
            // btnalertas
            // 
            this.btnalertas.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnalertas.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnalertas.ForeColor = System.Drawing.Color.White;
            this.btnalertas.Location = new System.Drawing.Point(0, 264);
            this.btnalertas.Margin = new System.Windows.Forms.Padding(4);
            this.btnalertas.Name = "btnalertas";
            this.btnalertas.Size = new System.Drawing.Size(213, 64);
            this.btnalertas.TabIndex = 3;
            this.btnalertas.Text = "Generar alertas";
            this.btnalertas.UseVisualStyleBackColor = false;
            this.btnalertas.Click += new System.EventHandler(this.btnalertas_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnsalir.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnsalir.ForeColor = System.Drawing.Color.White;
            this.btnsalir.Location = new System.Drawing.Point(0, 472);
            this.btnsalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(213, 55);
            this.btnsalir.TabIndex = 8;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(227)))), ((int)(((byte)(196)))));
            this.panelLateral.Controls.Add(this.btnRegresar);
            this.panelLateral.Controls.Add(this.btnregistro);
            this.panelLateral.Controls.Add(this.btnactualizarinv);
            this.panelLateral.Controls.Add(this.btnsalir);
            this.panelLateral.Controls.Add(this.btncategorias);
            this.panelLateral.Controls.Add(this.btnalertas);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 94);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(213, 759);
            this.panelLateral.TabIndex = 9;
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.panelSuperior.Controls.Add(this.pictureBox2);
            this.panelSuperior.Controls.Add(this.lblHora);
            this.panelSuperior.Controls.Add(this.lblRol);
            this.panelSuperior.Controls.Add(this.lblUsuario);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1047, 94);
            this.panelSuperior.TabIndex = 10;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(3, 364);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(210, 61);
            this.btnRegresar.TabIndex = 9;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.dgvSolicitudes);
            this.panelContenido.Controls.Add(this.dgvVecimientos);
            this.panelContenido.Controls.Add(this.dgvStocBajo);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(213, 94);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(834, 759);
            this.panelContenido.TabIndex = 11;
            // 
            // dgvStocBajo
            // 
            this.dgvStocBajo.AllowUserToAddRows = false;
            this.dgvStocBajo.AllowUserToDeleteRows = false;
            this.dgvStocBajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStocBajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStocBajo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreProducto,
            this.Stock,
            this.Categoria});
            this.dgvStocBajo.Location = new System.Drawing.Point(128, 25);
            this.dgvStocBajo.Name = "dgvStocBajo";
            this.dgvStocBajo.ReadOnly = true;
            this.dgvStocBajo.RowHeadersWidth = 51;
            this.dgvStocBajo.RowTemplate.Height = 24;
            this.dgvStocBajo.Size = new System.Drawing.Size(508, 150);
            this.dgvStocBajo.TabIndex = 0;
            // 
            // dgvVecimientos
            // 
            this.dgvVecimientos.AllowUserToAddRows = false;
            this.dgvVecimientos.AllowUserToDeleteRows = false;
            this.dgvVecimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVecimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVecimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreProductoV,
            this.FechaVencimiento});
            this.dgvVecimientos.Location = new System.Drawing.Point(128, 275);
            this.dgvVecimientos.Name = "dgvVecimientos";
            this.dgvVecimientos.ReadOnly = true;
            this.dgvVecimientos.RowHeadersWidth = 51;
            this.dgvVecimientos.RowTemplate.Height = 24;
            this.dgvVecimientos.Size = new System.Drawing.Size(508, 150);
            this.dgvVecimientos.TabIndex = 1;
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.AllowUserToAddRows = false;
            this.dgvSolicitudes.AllowUserToDeleteRows = false;
            this.dgvSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TipoProceso,
            this.Descripcion,
            this.Estado,
            this.FechaHora});
            this.dgvSolicitudes.Location = new System.Drawing.Point(128, 524);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.RowHeadersWidth = 51;
            this.dgvSolicitudes.RowTemplate.Height = 24;
            this.dgvSolicitudes.Size = new System.Drawing.Size(508, 150);
            this.dgvSolicitudes.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblUsuario.Location = new System.Drawing.Point(200, 45);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(26, 25);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "--";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblHora.Location = new System.Drawing.Point(825, 45);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(26, 25);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "--";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblRol.Location = new System.Drawing.Point(343, 45);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(26, 25);
            this.lblRol.TabIndex = 0;
            this.lblRol.Text = "--";
            // 
            // relojHora
            // 
            this.relojHora.Enabled = true;
            this.relojHora.Interval = 1000;
            this.relojHora.Tick += new System.EventHandler(this.relojHora_Tick_1);
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Producto";
            this.NombreProducto.MinimumWidth = 6;
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // NombreProductoV
            // 
            this.NombreProductoV.HeaderText = "Producto";
            this.NombreProductoV.MinimumWidth = 6;
            this.NombreProductoV.Name = "NombreProductoV";
            this.NombreProductoV.ReadOnly = true;
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.HeaderText = "Fecha de Vencimiento";
            this.FechaVencimiento.MinimumWidth = 6;
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // TipoProceso
            // 
            this.TipoProceso.HeaderText = "Proceso";
            this.TipoProceso.MinimumWidth = 6;
            this.TipoProceso.Name = "TipoProceso";
            this.TipoProceso.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // FechaHora
            // 
            this.FechaHora.HeaderText = "Fecha";
            this.FechaHora.MinimumWidth = 6;
            this.FechaHora.Name = "FechaHora";
            this.FechaHora.ReadOnly = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(239)))));
            this.pictureBox2.Image = global::Agro_UES.Properties.Resources.logo2;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(93, 94);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // FormAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 853);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.panelSuperior);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(900, 900);
            this.Name = "FormAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAlmacen";
            this.panelLateral.ResumeLayout(false);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocBajo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVecimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnregistro;
        private System.Windows.Forms.Button btnactualizarinv;
        private System.Windows.Forms.Button btncategorias;
        private System.Windows.Forms.Button btnalertas;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.DataGridView dgvVecimientos;
        private System.Windows.Forms.DataGridView dgvStocBajo;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Timer relojHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProductoV;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}