
namespace Formularios
{
    partial class FrmPilotoEstadistica
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
            this.rchEstadisticas = new System.Windows.Forms.RichTextBox();
            this.btnPromedio = new System.Windows.Forms.Button();
            this.btnMaximo = new System.Windows.Forms.Button();
            this.btnMinimo = new System.Windows.Forms.Button();
            this.chkSobreescribir = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rchEstadisticas
            // 
            this.rchEstadisticas.Enabled = false;
            this.rchEstadisticas.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rchEstadisticas.Location = new System.Drawing.Point(9, 41);
            this.rchEstadisticas.Name = "rchEstadisticas";
            this.rchEstadisticas.Size = new System.Drawing.Size(593, 165);
            this.rchEstadisticas.TabIndex = 0;
            this.rchEstadisticas.Text = "";
            // 
            // btnPromedio
            // 
            this.btnPromedio.Location = new System.Drawing.Point(524, 12);
            this.btnPromedio.Name = "btnPromedio";
            this.btnPromedio.Size = new System.Drawing.Size(75, 23);
            this.btnPromedio.TabIndex = 1;
            this.btnPromedio.Text = "Promedio";
            this.btnPromedio.UseVisualStyleBackColor = true;
            this.btnPromedio.Click += new System.EventHandler(this.btnPromedio_Click);
            // 
            // btnMaximo
            // 
            this.btnMaximo.Location = new System.Drawing.Point(443, 12);
            this.btnMaximo.Name = "btnMaximo";
            this.btnMaximo.Size = new System.Drawing.Size(75, 23);
            this.btnMaximo.TabIndex = 2;
            this.btnMaximo.Text = "Maximo";
            this.btnMaximo.UseVisualStyleBackColor = true;
            this.btnMaximo.Click += new System.EventHandler(this.btnMaximo_Click);
            // 
            // btnMinimo
            // 
            this.btnMinimo.Location = new System.Drawing.Point(362, 12);
            this.btnMinimo.Name = "btnMinimo";
            this.btnMinimo.Size = new System.Drawing.Size(75, 23);
            this.btnMinimo.TabIndex = 3;
            this.btnMinimo.Text = "Minimo";
            this.btnMinimo.UseVisualStyleBackColor = true;
            this.btnMinimo.Click += new System.EventHandler(this.btnMinimo_Click);
            // 
            // chkSobreescribir
            // 
            this.chkSobreescribir.AutoSize = true;
            this.chkSobreescribir.Location = new System.Drawing.Point(341, 215);
            this.chkSobreescribir.Name = "chkSobreescribir";
            this.chkSobreescribir.Size = new System.Drawing.Size(180, 19);
            this.chkSobreescribir.TabIndex = 4;
            this.chkSobreescribir.Text = "Sobrescribir archivo existente";
            this.chkSobreescribir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSobreescribir.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(527, 212);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar Estaditica";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmPilotoEstadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 240);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkSobreescribir);
            this.Controls.Add(this.btnMinimo);
            this.Controls.Add(this.btnMaximo);
            this.Controls.Add(this.btnPromedio);
            this.Controls.Add(this.rchEstadisticas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPilotoEstadistica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas de la lista de pilotos cargados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchEstadisticas;
        private System.Windows.Forms.Button btnPromedio;
        private System.Windows.Forms.Button btnMaximo;
        private System.Windows.Forms.Button btnMinimo;
        private System.Windows.Forms.CheckBox chkSobreescribir;
        private System.Windows.Forms.Button btnGuardar;
    }
}