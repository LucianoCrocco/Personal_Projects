
namespace Formularios
{
    partial class FrmEditarEscuderiaTC
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.cmbFabricante = new System.Windows.Forms.ComboBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.nroAsientos = new System.Windows.Forms.NumericUpDown();
            this.nroCarrera = new System.Windows.Forms.Label();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nroAsientos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.Location = new System.Drawing.Point(10, 176);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(438, 42);
            this.btnEditar.TabIndex = 21;
            this.btnEditar.Text = "Confirmar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cmbFabricante
            // 
            this.cmbFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFabricante.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbFabricante.FormattingEnabled = true;
            this.cmbFabricante.Items.AddRange(new object[] {
            "Ford",
            "Chevrolet",
            "Torino",
            "Dodge",
            "Toyota"});
            this.cmbFabricante.Location = new System.Drawing.Point(10, 141);
            this.cmbFabricante.Name = "cmbFabricante";
            this.cmbFabricante.Size = new System.Drawing.Size(438, 28);
            this.cmbFabricante.TabIndex = 20;
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFabricante.Location = new System.Drawing.Point(10, 110);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(341, 25);
            this.lblFabricante.TabIndex = 19;
            this.lblFabricante.Text = "Marca fabricante del vehiculo";
            // 
            // nroAsientos
            // 
            this.nroAsientos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nroAsientos.Location = new System.Drawing.Point(396, 76);
            this.nroAsientos.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nroAsientos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nroAsientos.Name = "nroAsientos";
            this.nroAsientos.Size = new System.Drawing.Size(52, 27);
            this.nroAsientos.TabIndex = 18;
            this.nroAsientos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nroCarrera
            // 
            this.nroCarrera.AutoSize = true;
            this.nroCarrera.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nroCarrera.Location = new System.Drawing.Point(10, 76);
            this.nroCarrera.Name = "nroCarrera";
            this.nroCarrera.Size = new System.Drawing.Size(380, 25);
            this.nroCarrera.TabIndex = 17;
            this.nroCarrera.Text = "Cantidad de asientos disponibles";
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxNombre.Location = new System.Drawing.Point(10, 41);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(438, 27);
            this.txtBoxNombre.TabIndex = 16;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(10, 11);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(277, 25);
            this.lblNombre.TabIndex = 15;
            this.lblNombre.Text = "Nombre de la escuderia";
            // 
            // FrmEditarEscuderiaTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 228);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.cmbFabricante);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.nroAsientos);
            this.Controls.Add(this.nroCarrera);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarEscuderiaTC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Escuderia";
            this.Load += new System.EventHandler(this.FrmEditarEscuderiaTC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nroAsientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ComboBox cmbFabricante;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.NumericUpDown nroAsientos;
        private System.Windows.Forms.Label nroCarrera;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Label lblNombre;
    }
}