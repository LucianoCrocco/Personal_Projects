
namespace Formularios
{
    partial class FrmPiloto
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
            this.btnGenerarPiloto = new System.Windows.Forms.Button();
            this.lstPilotos = new System.Windows.Forms.ListBox();
            this.lblListaPilotos = new System.Windows.Forms.Label();
            this.btnGuardarLista = new System.Windows.Forms.Button();
            this.btnCargarLista = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnBorrarPiloto = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblPilotosCargados = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerarPiloto
            // 
            this.btnGenerarPiloto.Location = new System.Drawing.Point(665, 101);
            this.btnGenerarPiloto.Name = "btnGenerarPiloto";
            this.btnGenerarPiloto.Size = new System.Drawing.Size(138, 45);
            this.btnGenerarPiloto.TabIndex = 1;
            this.btnGenerarPiloto.Text = "Generar Nuevo Piloto";
            this.btnGenerarPiloto.UseVisualStyleBackColor = true;
            this.btnGenerarPiloto.Click += new System.EventHandler(this.btnGenerarPiloto_Click);
            // 
            // lstPilotos
            // 
            this.lstPilotos.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstPilotos.FormattingEnabled = true;
            this.lstPilotos.ItemHeight = 16;
            this.lstPilotos.Location = new System.Drawing.Point(12, 42);
            this.lstPilotos.Name = "lstPilotos";
            this.lstPilotos.Size = new System.Drawing.Size(647, 212);
            this.lstPilotos.TabIndex = 2;
            // 
            // lblListaPilotos
            // 
            this.lblListaPilotos.AutoSize = true;
            this.lblListaPilotos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblListaPilotos.Location = new System.Drawing.Point(12, 9);
            this.lblListaPilotos.Name = "lblListaPilotos";
            this.lblListaPilotos.Size = new System.Drawing.Size(446, 30);
            this.lblListaPilotos.TabIndex = 3;
            this.lblListaPilotos.Text = "LISTA DE PILOTOS CARGADOS EN EL SISTEMA";
            // 
            // btnGuardarLista
            // 
            this.btnGuardarLista.Location = new System.Drawing.Point(665, 152);
            this.btnGuardarLista.Name = "btnGuardarLista";
            this.btnGuardarLista.Size = new System.Drawing.Size(138, 45);
            this.btnGuardarLista.TabIndex = 4;
            this.btnGuardarLista.Text = "Guardar Lista de Pilotos";
            this.btnGuardarLista.UseVisualStyleBackColor = true;
            this.btnGuardarLista.Click += new System.EventHandler(this.btnGuardarLista_Click);
            // 
            // btnCargarLista
            // 
            this.btnCargarLista.Location = new System.Drawing.Point(665, 203);
            this.btnCargarLista.Name = "btnCargarLista";
            this.btnCargarLista.Size = new System.Drawing.Size(138, 45);
            this.btnCargarLista.TabIndex = 5;
            this.btnCargarLista.Text = "Cargar Lista de Pilotos";
            this.btnCargarLista.UseVisualStyleBackColor = true;
            this.btnCargarLista.Click += new System.EventHandler(this.btnCargarLista_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Location = new System.Drawing.Point(665, 50);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(138, 45);
            this.btnEstadisticas.TabIndex = 6;
            this.btnEstadisticas.Text = "Estadisticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(809, 181);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(138, 45);
            this.btnHistorial.TabIndex = 7;
            this.btnHistorial.Text = "Historial de Pilotos";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnBorrarPiloto
            // 
            this.btnBorrarPiloto.Location = new System.Drawing.Point(809, 126);
            this.btnBorrarPiloto.Name = "btnBorrarPiloto";
            this.btnBorrarPiloto.Size = new System.Drawing.Size(138, 45);
            this.btnBorrarPiloto.TabIndex = 8;
            this.btnBorrarPiloto.Text = "Borrar Piloto";
            this.btnBorrarPiloto.UseVisualStyleBackColor = true;
            this.btnBorrarPiloto.Click += new System.EventHandler(this.btnBorrarPiloto_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(809, 72);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(138, 45);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar Piloto";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblPilotosCargados
            // 
            this.lblPilotosCargados.AutoSize = true;
            this.lblPilotosCargados.Font = new System.Drawing.Font("Segoe UI", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPilotosCargados.Location = new System.Drawing.Point(665, 9);
            this.lblPilotosCargados.Name = "lblPilotosCargados";
            this.lblPilotosCargados.Size = new System.Drawing.Size(212, 25);
            this.lblPilotosCargados.TabIndex = 10;
            this.lblPilotosCargados.Text = "Cargados Actualmente: ";
            // 
            // FrmPiloto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 266);
            this.Controls.Add(this.lblPilotosCargados);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBorrarPiloto);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnEstadisticas);
            this.Controls.Add(this.btnCargarLista);
            this.Controls.Add(this.btnGuardarLista);
            this.Controls.Add(this.lblListaPilotos);
            this.Controls.Add(this.lstPilotos);
            this.Controls.Add(this.btnGenerarPiloto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPiloto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informacion de Pilotos";
            this.Activated += new System.EventHandler(this.FrmPiloto_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPiloto_FormClosing);
            this.Load += new System.EventHandler(this.FrmPiloto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerarPiloto;
        private System.Windows.Forms.ListBox lstPilotos;
        private System.Windows.Forms.Label lblListaPilotos;
        private System.Windows.Forms.Button btnGuardarLista;
        private System.Windows.Forms.Button btnCargarLista;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnBorrarPiloto;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblPilotosCargados;
    }
}