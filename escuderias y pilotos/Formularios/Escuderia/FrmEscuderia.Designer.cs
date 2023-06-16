
namespace Formularios
{
    partial class FrmEscuderia<T>
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
            this.lstEscuderias = new System.Windows.Forms.ListBox();
            this.lblListaEscuderia = new System.Windows.Forms.Label();
            this.btnEstadisticasGenerales = new System.Windows.Forms.Button();
            this.btnGenerarEscuderia = new System.Windows.Forms.Button();
            this.btnGuardarLista = new System.Windows.Forms.Button();
            this.btnCargarLista = new System.Windows.Forms.Button();
            this.btnGestionarPilotos = new System.Windows.Forms.Button();
            this.btnEstadisticasIndividuales = new System.Windows.Forms.Button();
            this.btnBorrarEscuderia = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstEscuderias
            // 
            this.lstEscuderias.FormattingEnabled = true;
            this.lstEscuderias.ItemHeight = 15;
            this.lstEscuderias.Location = new System.Drawing.Point(12, 52);
            this.lstEscuderias.Name = "lstEscuderias";
            this.lstEscuderias.Size = new System.Drawing.Size(703, 214);
            this.lstEscuderias.TabIndex = 3;
            // 
            // lblListaEscuderia
            // 
            this.lblListaEscuderia.AutoSize = true;
            this.lblListaEscuderia.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblListaEscuderia.Location = new System.Drawing.Point(146, 9);
            this.lblListaEscuderia.Name = "lblListaEscuderia";
            this.lblListaEscuderia.Size = new System.Drawing.Size(483, 30);
            this.lblListaEscuderia.TabIndex = 4;
            this.lblListaEscuderia.Text = "LISTA DE ESCUDERIAS CARGADAS EN EL SISTEMA";
            // 
            // btnEstadisticasGenerales
            // 
            this.btnEstadisticasGenerales.Location = new System.Drawing.Point(721, 61);
            this.btnEstadisticasGenerales.Name = "btnEstadisticasGenerales";
            this.btnEstadisticasGenerales.Size = new System.Drawing.Size(83, 52);
            this.btnEstadisticasGenerales.TabIndex = 7;
            this.btnEstadisticasGenerales.Text = "Estadisticas Generales";
            this.btnEstadisticasGenerales.UseVisualStyleBackColor = true;
            this.btnEstadisticasGenerales.Click += new System.EventHandler(this.btnEstadisticasGenerales_Click);
            // 
            // btnGenerarEscuderia
            // 
            this.btnGenerarEscuderia.Location = new System.Drawing.Point(12, 272);
            this.btnGenerarEscuderia.Name = "btnGenerarEscuderia";
            this.btnGenerarEscuderia.Size = new System.Drawing.Size(127, 45);
            this.btnGenerarEscuderia.TabIndex = 8;
            this.btnGenerarEscuderia.Text = "Generar Nueva Escuderia";
            this.btnGenerarEscuderia.UseVisualStyleBackColor = true;
            this.btnGenerarEscuderia.Click += new System.EventHandler(this.btnGenerarEscuderia_Click);
            // 
            // btnGuardarLista
            // 
            this.btnGuardarLista.Location = new System.Drawing.Point(300, 272);
            this.btnGuardarLista.Name = "btnGuardarLista";
            this.btnGuardarLista.Size = new System.Drawing.Size(127, 45);
            this.btnGuardarLista.TabIndex = 9;
            this.btnGuardarLista.Text = "Guardar Lista de Escuderias";
            this.btnGuardarLista.UseVisualStyleBackColor = true;
            this.btnGuardarLista.Click += new System.EventHandler(this.btnGuardarLista_Click);
            // 
            // btnCargarLista
            // 
            this.btnCargarLista.Location = new System.Drawing.Point(444, 272);
            this.btnCargarLista.Name = "btnCargarLista";
            this.btnCargarLista.Size = new System.Drawing.Size(127, 45);
            this.btnCargarLista.TabIndex = 10;
            this.btnCargarLista.Text = "Cargar Lista de Escuderias";
            this.btnCargarLista.UseVisualStyleBackColor = true;
            this.btnCargarLista.Click += new System.EventHandler(this.btnCargarLista_Click);
            // 
            // btnGestionarPilotos
            // 
            this.btnGestionarPilotos.Location = new System.Drawing.Point(721, 177);
            this.btnGestionarPilotos.Name = "btnGestionarPilotos";
            this.btnGestionarPilotos.Size = new System.Drawing.Size(83, 73);
            this.btnGestionarPilotos.TabIndex = 11;
            this.btnGestionarPilotos.Text = "Gestionar Pilotos de las Escuderias";
            this.btnGestionarPilotos.UseVisualStyleBackColor = true;
            this.btnGestionarPilotos.Click += new System.EventHandler(this.btnGestionarPilotos_Click);
            // 
            // btnEstadisticasIndividuales
            // 
            this.btnEstadisticasIndividuales.Location = new System.Drawing.Point(721, 119);
            this.btnEstadisticasIndividuales.Name = "btnEstadisticasIndividuales";
            this.btnEstadisticasIndividuales.Size = new System.Drawing.Size(83, 52);
            this.btnEstadisticasIndividuales.TabIndex = 13;
            this.btnEstadisticasIndividuales.Text = "Estadisticas Individuales";
            this.btnEstadisticasIndividuales.UseVisualStyleBackColor = true;
            this.btnEstadisticasIndividuales.Click += new System.EventHandler(this.btnEstadisticasIndividuales_Click);
            // 
            // btnBorrarEscuderia
            // 
            this.btnBorrarEscuderia.Location = new System.Drawing.Point(156, 272);
            this.btnBorrarEscuderia.Name = "btnBorrarEscuderia";
            this.btnBorrarEscuderia.Size = new System.Drawing.Size(127, 45);
            this.btnBorrarEscuderia.TabIndex = 14;
            this.btnBorrarEscuderia.Text = "Borrar Escuderia Seleccionada";
            this.btnBorrarEscuderia.UseVisualStyleBackColor = true;
            this.btnBorrarEscuderia.Click += new System.EventHandler(this.btnBorrarEscuderia_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(585, 272);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(127, 45);
            this.btnEditar.TabIndex = 15;
            this.btnEditar.Text = "Editar Escuderia";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FrmEscuderia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 324);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBorrarEscuderia);
            this.Controls.Add(this.btnEstadisticasIndividuales);
            this.Controls.Add(this.btnGestionarPilotos);
            this.Controls.Add(this.btnCargarLista);
            this.Controls.Add(this.btnGuardarLista);
            this.Controls.Add(this.btnGenerarEscuderia);
            this.Controls.Add(this.btnEstadisticasGenerales);
            this.Controls.Add(this.lblListaEscuderia);
            this.Controls.Add(this.lstEscuderias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmEscuderia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escuderias";
            this.Activated += new System.EventHandler(this.FrmEscuderia_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEscuderia_FormClosing);
            this.Load += new System.EventHandler(this.FrmEscuderia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstEscuderias;
        private System.Windows.Forms.Label lblListaEscuderia;
        private System.Windows.Forms.Button btnEstadisticasGenerales;
        private System.Windows.Forms.Button btnGenerarEscuderia;
        private System.Windows.Forms.Button btnGuardarLista;
        private System.Windows.Forms.Button btnCargarLista;
        private System.Windows.Forms.Button btnGestionarPilotos;
        private System.Windows.Forms.Button btnEstadisticasIndividuales;
        private System.Windows.Forms.Button btnBorrarEscuderia;
        private System.Windows.Forms.Button btnEditar;
    }
}