
namespace Formularios
{
    partial class FrmEditarPiloto
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtBoxApellido = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.nroEdad = new System.Windows.Forms.NumericUpDown();
            this.lblSexo = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.nroCarrera = new System.Windows.Forms.Label();
            this.nroCompeticion = new System.Windows.Forms.NumericUpDown();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.cmbNacionalidad = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nroEdad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCompeticion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(116, 25);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre: ";
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxNombre.Location = new System.Drawing.Point(125, 9);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(141, 27);
            this.txtBoxNombre.TabIndex = 7;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.Location = new System.Drawing.Point(12, 48);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(119, 25);
            this.lblApellido.TabIndex = 8;
            this.lblApellido.Text = "Apellido: ";
            // 
            // txtBoxApellido
            // 
            this.txtBoxApellido.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxApellido.Location = new System.Drawing.Point(125, 50);
            this.txtBoxApellido.Name = "txtBoxApellido";
            this.txtBoxApellido.Size = new System.Drawing.Size(141, 27);
            this.txtBoxApellido.TabIndex = 9;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEdad.Location = new System.Drawing.Point(12, 85);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(82, 25);
            this.lblEdad.TabIndex = 10;
            this.lblEdad.Text = "Edad: ";
            // 
            // nroEdad
            // 
            this.nroEdad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nroEdad.Location = new System.Drawing.Point(125, 88);
            this.nroEdad.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nroEdad.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nroEdad.Name = "nroEdad";
            this.nroEdad.Size = new System.Drawing.Size(44, 27);
            this.nroEdad.TabIndex = 11;
            this.nroEdad.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSexo.Location = new System.Drawing.Point(13, 122);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(81, 25);
            this.lblSexo.TabIndex = 12;
            this.lblSexo.Text = "Sexo: ";
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino",
            "Otro"});
            this.cmbSexo.Location = new System.Drawing.Point(125, 122);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(141, 28);
            this.cmbSexo.TabIndex = 13;
            // 
            // nroCarrera
            // 
            this.nroCarrera.AutoSize = true;
            this.nroCarrera.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nroCarrera.Location = new System.Drawing.Point(12, 166);
            this.nroCarrera.Name = "nroCarrera";
            this.nroCarrera.Size = new System.Drawing.Size(166, 50);
            this.nroCarrera.TabIndex = 14;
            this.nroCarrera.Text = "Numero de \r\nCompeticion: ";
            // 
            // nroCompeticion
            // 
            this.nroCompeticion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nroCompeticion.Location = new System.Drawing.Point(184, 179);
            this.nroCompeticion.Maximum = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.nroCompeticion.Name = "nroCompeticion";
            this.nroCompeticion.Size = new System.Drawing.Size(62, 27);
            this.nroCompeticion.TabIndex = 15;
            this.nroCompeticion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNacionalidad.Location = new System.Drawing.Point(13, 237);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(192, 25);
            this.lblNacionalidad.TabIndex = 16;
            this.lblNacionalidad.Text = "¿Es argentino?: ";
            // 
            // cmbNacionalidad
            // 
            this.cmbNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNacionalidad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbNacionalidad.FormattingEnabled = true;
            this.cmbNacionalidad.Items.AddRange(new object[] {
            "Sí",
            "No"});
            this.cmbNacionalidad.Location = new System.Drawing.Point(201, 237);
            this.cmbNacionalidad.Name = "cmbNacionalidad";
            this.cmbNacionalidad.Size = new System.Drawing.Size(65, 28);
            this.cmbNacionalidad.TabIndex = 17;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.Location = new System.Drawing.Point(12, 271);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(263, 42);
            this.btnConfirmar.TabIndex = 18;
            this.btnConfirmar.Text = "Confirmar Cambios";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // FrmEditarPiloto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 319);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cmbNacionalidad);
            this.Controls.Add(this.lblNacionalidad);
            this.Controls.Add(this.nroCompeticion);
            this.Controls.Add(this.nroCarrera);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.nroEdad);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtBoxApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarPiloto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Piloto";
            this.Load += new System.EventHandler(this.FrmEditarPiloto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nroEdad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCompeticion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtBoxApellido;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.NumericUpDown nroEdad;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label nroCarrera;
        private System.Windows.Forms.NumericUpDown nroCompeticion;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.ComboBox cmbNacionalidad;
        private System.Windows.Forms.Button btnConfirmar;
    }
}