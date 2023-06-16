
namespace Formularios
{
    partial class FrmGestionarPiloto
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
            this.lstPilotosDisponibles = new System.Windows.Forms.ListBox();
            this.lstPilotosDeLaEscuderia = new System.Windows.Forms.ListBox();
            this.lblPilotosEscuderia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPilotosDisponibles
            // 
            this.lstPilotosDisponibles.FormattingEnabled = true;
            this.lstPilotosDisponibles.ItemHeight = 15;
            this.lstPilotosDisponibles.Location = new System.Drawing.Point(12, 277);
            this.lstPilotosDisponibles.Name = "lstPilotosDisponibles";
            this.lstPilotosDisponibles.Size = new System.Drawing.Size(776, 184);
            this.lstPilotosDisponibles.TabIndex = 0;
            this.lstPilotosDisponibles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPilotosDisponibles_MouseDoubleClick);
            // 
            // lstPilotosDeLaEscuderia
            // 
            this.lstPilotosDeLaEscuderia.FormattingEnabled = true;
            this.lstPilotosDeLaEscuderia.ItemHeight = 15;
            this.lstPilotosDeLaEscuderia.Location = new System.Drawing.Point(12, 47);
            this.lstPilotosDeLaEscuderia.Name = "lstPilotosDeLaEscuderia";
            this.lstPilotosDeLaEscuderia.Size = new System.Drawing.Size(776, 184);
            this.lstPilotosDeLaEscuderia.TabIndex = 1;
            this.lstPilotosDeLaEscuderia.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPilotosDeLaEscuderia_MouseDoubleClick);
            // 
            // lblPilotosEscuderia
            // 
            this.lblPilotosEscuderia.AutoSize = true;
            this.lblPilotosEscuderia.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPilotosEscuderia.Location = new System.Drawing.Point(12, 9);
            this.lblPilotosEscuderia.Name = "lblPilotosEscuderia";
            this.lblPilotosEscuderia.Size = new System.Drawing.Size(517, 25);
            this.lblPilotosEscuderia.TabIndex = 2;
            this.lblPilotosEscuderia.Text = "Pilotos actuales de la escuderia seleccionada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(582, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pilotos listados en el sistema para ocupar asientos";
            // 
            // FrmGestionarPiloto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPilotosEscuderia);
            this.Controls.Add(this.lstPilotosDeLaEscuderia);
            this.Controls.Add(this.lstPilotosDisponibles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGestionarPiloto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar pilotos a la escuderia";
            this.Load += new System.EventHandler(this.FrmCargarPiloto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPilotosDisponibles;
        private System.Windows.Forms.ListBox lstPilotosDeLaEscuderia;
        private System.Windows.Forms.Label lblPilotosEscuderia;
        private System.Windows.Forms.Label label1;
    }
}