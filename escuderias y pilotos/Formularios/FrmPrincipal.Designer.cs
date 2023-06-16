
namespace Formularios
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.btnEscuderia = new System.Windows.Forms.Button();
            this.btnPilotos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEscuderia
            // 
            this.btnEscuderia.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEscuderia.Location = new System.Drawing.Point(12, 127);
            this.btnEscuderia.Name = "btnEscuderia";
            this.btnEscuderia.Size = new System.Drawing.Size(185, 84);
            this.btnEscuderia.TabIndex = 1;
            this.btnEscuderia.Text = "Escuderia";
            this.btnEscuderia.UseVisualStyleBackColor = true;
            this.btnEscuderia.Click += new System.EventHandler(this.btnEscuderia_Click);
            // 
            // btnPilotos
            // 
            this.btnPilotos.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPilotos.Location = new System.Drawing.Point(215, 127);
            this.btnPilotos.Name = "btnPilotos";
            this.btnPilotos.Size = new System.Drawing.Size(185, 84);
            this.btnPilotos.TabIndex = 2;
            this.btnPilotos.Text = "Pilotos";
            this.btnPilotos.UseVisualStyleBackColor = true;
            this.btnPilotos.Click += new System.EventHandler(this.btnPilotos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(141, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 109);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 215);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPilotos);
            this.Controls.Add(this.btnEscuderia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "¡Bienvenido!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEscuderia;
        private System.Windows.Forms.Button btnPilotos;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

