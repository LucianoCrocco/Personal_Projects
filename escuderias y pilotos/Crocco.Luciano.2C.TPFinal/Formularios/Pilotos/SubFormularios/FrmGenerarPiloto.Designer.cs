
namespace Formularios
{
    partial class FrmGenerarPiloto
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
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.nroCarrera = new System.Windows.Forms.Label();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.txtBoxApellido = new System.Windows.Forms.TextBox();
            this.nroEdad = new System.Windows.Forms.NumericUpDown();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.nroCompeticion = new System.Windows.Forms.NumericUpDown();
            this.cmbNacionalidad = new System.Windows.Forms.ComboBox();
            this.btnCrear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nroEdad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCompeticion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(12, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(116, 25);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre: ";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.Location = new System.Drawing.Point(12, 65);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(119, 25);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido: ";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEdad.Location = new System.Drawing.Point(12, 101);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(82, 25);
            this.lblEdad.TabIndex = 2;
            this.lblEdad.Text = "Edad: ";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSexo.Location = new System.Drawing.Point(12, 136);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(81, 25);
            this.lblSexo.TabIndex = 3;
            this.lblSexo.Text = "Sexo: ";
            // 
            // nroCarrera
            // 
            this.nroCarrera.AutoSize = true;
            this.nroCarrera.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nroCarrera.Location = new System.Drawing.Point(12, 171);
            this.nroCarrera.Name = "nroCarrera";
            this.nroCarrera.Size = new System.Drawing.Size(166, 50);
            this.nroCarrera.TabIndex = 4;
            this.nroCarrera.Text = "Numero de \r\nCompeticion: ";
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNacionalidad.Location = new System.Drawing.Point(12, 232);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(192, 25);
            this.lblNacionalidad.TabIndex = 5;
            this.lblNacionalidad.Text = "¿Es argentino?: ";
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxNombre.Location = new System.Drawing.Point(134, 28);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(141, 27);
            this.txtBoxNombre.TabIndex = 6;
            // 
            // txtBoxApellido
            // 
            this.txtBoxApellido.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxApellido.Location = new System.Drawing.Point(134, 67);
            this.txtBoxApellido.Name = "txtBoxApellido";
            this.txtBoxApellido.Size = new System.Drawing.Size(141, 27);
            this.txtBoxApellido.TabIndex = 7;
            // 
            // nroEdad
            // 
            this.nroEdad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nroEdad.Location = new System.Drawing.Point(134, 103);
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
            this.nroEdad.TabIndex = 8;
            this.nroEdad.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
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
            this.cmbSexo.Location = new System.Drawing.Point(134, 136);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(141, 28);
            this.cmbSexo.TabIndex = 9;
            // 
            // nroCompeticion
            // 
            this.nroCompeticion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nroCompeticion.Location = new System.Drawing.Point(185, 181);
            this.nroCompeticion.Maximum = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.nroCompeticion.Name = "nroCompeticion";
            this.nroCompeticion.Size = new System.Drawing.Size(62, 27);
            this.nroCompeticion.TabIndex = 10;
            this.nroCompeticion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbNacionalidad
            // 
            this.cmbNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNacionalidad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbNacionalidad.FormattingEnabled = true;
            this.cmbNacionalidad.Items.AddRange(new object[] {
            "Sí",
            "No"});
            this.cmbNacionalidad.Location = new System.Drawing.Point(210, 231);
            this.cmbNacionalidad.Name = "cmbNacionalidad";
            this.cmbNacionalidad.Size = new System.Drawing.Size(65, 28);
            this.cmbNacionalidad.TabIndex = 11;
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCrear.Location = new System.Drawing.Point(12, 265);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(263, 42);
            this.btnCrear.TabIndex = 12;
            this.btnCrear.Text = "Cargar al Sistema";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // FrmGenerarPiloto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 319);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.cmbNacionalidad);
            this.Controls.Add(this.nroCompeticion);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.nroEdad);
            this.Controls.Add(this.txtBoxApellido);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.lblNacionalidad);
            this.Controls.Add(this.nroCarrera);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGenerarPiloto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga de un Piloto";
            this.Load += new System.EventHandler(this.FrmGenerarPiloto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nroEdad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCompeticion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label nroCarrera;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.TextBox txtBoxApellido;
        private System.Windows.Forms.NumericUpDown nroEdad;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.NumericUpDown nroCompeticion;
        private System.Windows.Forms.ComboBox cmbNacionalidad;
        private System.Windows.Forms.Button btnCrear;
    }
}