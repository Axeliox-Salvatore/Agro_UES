namespace Agro_UES.Formularios.Formgerente
{
    partial class FormSolicitudes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRechazarSolicitud = new System.Windows.Forms.Button();
            this.btnAprobarProceso = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTipoProceso = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFechaSolicitud = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSolicitudUsuario = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSolicitudesPendientes = new System.Windows.Forms.DataGridView();
            this.dgvUsuarioSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTipoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFechaSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvHistorialSolicitudes = new System.Windows.Forms.DataGridView();
            this.dgvUsuarioSolicitud2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTipoProceso2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDescripcion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFechaSolicitud2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudesPendientes)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnRechazarSolicitud);
            this.panel1.Controls.Add(this.btnAprobarProceso);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblTipoProceso);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblFechaSolicitud);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblDescripción);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblSolicitudUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(585, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 602);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 406);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(325, 196);
            this.panel4.TabIndex = 15;
            // 
            // btnRechazarSolicitud
            // 
            this.btnRechazarSolicitud.Location = new System.Drawing.Point(25, 332);
            this.btnRechazarSolicitud.Name = "btnRechazarSolicitud";
            this.btnRechazarSolicitud.Size = new System.Drawing.Size(75, 38);
            this.btnRechazarSolicitud.TabIndex = 14;
            this.btnRechazarSolicitud.Text = "Rechazar";
            this.btnRechazarSolicitud.UseVisualStyleBackColor = true;
            // 
            // btnAprobarProceso
            // 
            this.btnAprobarProceso.Location = new System.Drawing.Point(214, 332);
            this.btnAprobarProceso.Name = "btnAprobarProceso";
            this.btnAprobarProceso.Size = new System.Drawing.Size(75, 38);
            this.btnAprobarProceso.TabIndex = 14;
            this.btnAprobarProceso.Text = "Aprobar";
            this.btnAprobarProceso.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label12.Location = new System.Drawing.Point(89, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Tipo de proceso:";
            // 
            // lblTipoProceso
            // 
            this.lblTipoProceso.AutoSize = true;
            this.lblTipoProceso.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoProceso.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblTipoProceso.Location = new System.Drawing.Point(123, 80);
            this.lblTipoProceso.Name = "lblTipoProceso";
            this.lblTipoProceso.Size = new System.Drawing.Size(37, 20);
            this.lblTipoProceso.TabIndex = 6;
            this.lblTipoProceso.Text = "N/A";
            this.lblTipoProceso.Click += new System.EventHandler(this.lblTipoProceso_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label11.Location = new System.Drawing.Point(100, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 40);
            this.label11.TabIndex = 8;
            this.label11.Text = "Fecha y hora \r\nde solicitud:";
            // 
            // lblFechaSolicitud
            // 
            this.lblFechaSolicitud.AutoSize = true;
            this.lblFechaSolicitud.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaSolicitud.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblFechaSolicitud.Location = new System.Drawing.Point(134, 277);
            this.lblFechaSolicitud.Name = "lblFechaSolicitud";
            this.lblFechaSolicitud.Size = new System.Drawing.Size(37, 20);
            this.lblFechaSolicitud.TabIndex = 8;
            this.lblFechaSolicitud.Text = "N/A";
            this.lblFechaSolicitud.Click += new System.EventHandler(this.lblFechaSolicitud_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(123, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Estado:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblEstado.Location = new System.Drawing.Point(130, 192);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(37, 20);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "N/A";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label10.Location = new System.Drawing.Point(100, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Descripción:";
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescripción.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblDescripción.Location = new System.Drawing.Point(126, 132);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(37, 20);
            this.lblDescripción.TabIndex = 10;
            this.lblDescripción.Text = "N/A";
            this.lblDescripción.Click += new System.EventHandler(this.lblDescripción_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label9.Location = new System.Drawing.Point(100, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Solicitud de:";
            // 
            // lblSolicitudUsuario
            // 
            this.lblSolicitudUsuario.AutoSize = true;
            this.lblSolicitudUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSolicitudUsuario.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblSolicitudUsuario.Location = new System.Drawing.Point(123, 29);
            this.lblSolicitudUsuario.Name = "lblSolicitudUsuario";
            this.lblSolicitudUsuario.Size = new System.Drawing.Size(37, 20);
            this.lblSolicitudUsuario.TabIndex = 13;
            this.lblSolicitudUsuario.Text = "N/A";
            this.lblSolicitudUsuario.Click += new System.EventHandler(this.lblSolicitudUsuario_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dgvSolicitudesPendientes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 300);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pendiente de aprobar/rechazar";
            // 
            // dgvSolicitudesPendientes
            // 
            this.dgvSolicitudesPendientes.AllowUserToAddRows = false;
            this.dgvSolicitudesPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSolicitudesPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitudesPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudesPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUsuarioSolicitud,
            this.dgvTipoProceso,
            this.dgvDescripcion,
            this.dgvFechaSolicitud});
            this.dgvSolicitudesPendientes.Location = new System.Drawing.Point(3, 57);
            this.dgvSolicitudesPendientes.Name = "dgvSolicitudesPendientes";
            this.dgvSolicitudesPendientes.RowHeadersWidth = 51;
            this.dgvSolicitudesPendientes.RowTemplate.Height = 24;
            this.dgvSolicitudesPendientes.Size = new System.Drawing.Size(576, 213);
            this.dgvSolicitudesPendientes.TabIndex = 3;
            this.dgvSolicitudesPendientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitudesPendientes_CellClick);
            this.dgvSolicitudesPendientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitudesPendientes_CellContentClick);
            // 
            // dgvUsuarioSolicitud
            // 
            this.dgvUsuarioSolicitud.HeaderText = "Usuario";
            this.dgvUsuarioSolicitud.MinimumWidth = 6;
            this.dgvUsuarioSolicitud.Name = "dgvUsuarioSolicitud";
            this.dgvUsuarioSolicitud.ReadOnly = true;
            // 
            // dgvTipoProceso
            // 
            this.dgvTipoProceso.HeaderText = "Tipo de proceso";
            this.dgvTipoProceso.MinimumWidth = 6;
            this.dgvTipoProceso.Name = "dgvTipoProceso";
            this.dgvTipoProceso.ReadOnly = true;
            // 
            // dgvDescripcion
            // 
            this.dgvDescripcion.HeaderText = "Descrición";
            this.dgvDescripcion.MinimumWidth = 6;
            this.dgvDescripcion.Name = "dgvDescripcion";
            this.dgvDescripcion.ReadOnly = true;
            // 
            // dgvFechaSolicitud
            // 
            this.dgvFechaSolicitud.HeaderText = "Fecha de sulicitud";
            this.dgvFechaSolicitud.MinimumWidth = 6;
            this.dgvFechaSolicitud.Name = "dgvFechaSolicitud";
            this.dgvFechaSolicitud.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.dgvHistorialSolicitudes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 300);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 302);
            this.panel3.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label8.Location = new System.Drawing.Point(20, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(355, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Historial de solicitudes aprobadas/rechazadas";
            // 
            // dgvHistorialSolicitudes
            // 
            this.dgvHistorialSolicitudes.AllowUserToAddRows = false;
            this.dgvHistorialSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUsuarioSolicitud2,
            this.dgvTipoProceso2,
            this.dgvDescripcion2,
            this.dgvFechaSolicitud2});
            this.dgvHistorialSolicitudes.Location = new System.Drawing.Point(3, 69);
            this.dgvHistorialSolicitudes.Name = "dgvHistorialSolicitudes";
            this.dgvHistorialSolicitudes.RowHeadersWidth = 51;
            this.dgvHistorialSolicitudes.RowTemplate.Height = 24;
            this.dgvHistorialSolicitudes.Size = new System.Drawing.Size(576, 202);
            this.dgvHistorialSolicitudes.TabIndex = 3;
            this.dgvHistorialSolicitudes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorialSolicitudes_CellClick);
            this.dgvHistorialSolicitudes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorialSolicitudes_CellContentClick);
            // 
            // dgvUsuarioSolicitud2
            // 
            this.dgvUsuarioSolicitud2.HeaderText = "Usuario";
            this.dgvUsuarioSolicitud2.MinimumWidth = 6;
            this.dgvUsuarioSolicitud2.Name = "dgvUsuarioSolicitud2";
            this.dgvUsuarioSolicitud2.ReadOnly = true;
            // 
            // dgvTipoProceso2
            // 
            this.dgvTipoProceso2.HeaderText = "Tipo de proceso";
            this.dgvTipoProceso2.MinimumWidth = 6;
            this.dgvTipoProceso2.Name = "dgvTipoProceso2";
            this.dgvTipoProceso2.ReadOnly = true;
            // 
            // dgvDescripcion2
            // 
            this.dgvDescripcion2.HeaderText = "Descripción";
            this.dgvDescripcion2.MinimumWidth = 6;
            this.dgvDescripcion2.Name = "dgvDescripcion2";
            this.dgvDescripcion2.ReadOnly = true;
            // 
            // dgvFechaSolicitud2
            // 
            this.dgvFechaSolicitud2.HeaderText = "Fecha de solicitud";
            this.dgvFechaSolicitud2.MinimumWidth = 6;
            this.dgvFechaSolicitud2.Name = "dgvFechaSolicitud2";
            this.dgvFechaSolicitud2.ReadOnly = true;
            // 
            // FormSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 602);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormSolicitudes";
            this.Text = "FormSolicitudes";
            this.Load += new System.EventHandler(this.FormSolicitudes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudesPendientes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSolicitudesPendientes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvHistorialSolicitudes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUsuarioSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTipoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFechaSolicitud;
        private System.Windows.Forms.Button btnAprobarProceso;
        private System.Windows.Forms.Label lblTipoProceso;
        private System.Windows.Forms.Label lblFechaSolicitud;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblSolicitudUsuario;
        private System.Windows.Forms.Button btnRechazarSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUsuarioSolicitud2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTipoProceso2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDescripcion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFechaSolicitud2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
    }
}