namespace presentacion
{
    partial class frmAgregarMarcaCategoria
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
            this.lblMarcaCategoria = new System.Windows.Forms.Label();
            this.txtMarcaCategoria = new System.Windows.Forms.TextBox();
            this.btnMarcaCategoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMarcaCategoria
            // 
            this.lblMarcaCategoria.AutoSize = true;
            this.lblMarcaCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcaCategoria.Location = new System.Drawing.Point(46, 39);
            this.lblMarcaCategoria.Name = "lblMarcaCategoria";
            this.lblMarcaCategoria.Size = new System.Drawing.Size(132, 37);
            this.lblMarcaCategoria.TabIndex = 1;
            this.lblMarcaCategoria.Text = "Nombre";
            // 
            // txtMarcaCategoria
            // 
            this.txtMarcaCategoria.Location = new System.Drawing.Point(107, 134);
            this.txtMarcaCategoria.Name = "txtMarcaCategoria";
            this.txtMarcaCategoria.Size = new System.Drawing.Size(163, 20);
            this.txtMarcaCategoria.TabIndex = 2;
            // 
            // btnMarcaCategoria
            // 
            this.btnMarcaCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcaCategoria.Location = new System.Drawing.Point(144, 200);
            this.btnMarcaCategoria.Name = "btnMarcaCategoria";
            this.btnMarcaCategoria.Size = new System.Drawing.Size(87, 28);
            this.btnMarcaCategoria.TabIndex = 3;
            this.btnMarcaCategoria.Text = "Agregar";
            this.btnMarcaCategoria.UseVisualStyleBackColor = true;
            this.btnMarcaCategoria.Click += new System.EventHandler(this.btnMarcaCategoria_Click);
            // 
            // frmAgregarMarcaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 281);
            this.Controls.Add(this.btnMarcaCategoria);
            this.Controls.Add(this.txtMarcaCategoria);
            this.Controls.Add(this.lblMarcaCategoria);
            this.MaximumSize = new System.Drawing.Size(394, 320);
            this.MinimumSize = new System.Drawing.Size(394, 320);
            this.Name = "frmAgregarMarcaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar";
            this.Load += new System.EventHandler(this.frmAgregarMarcaCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMarcaCategoria;
        private System.Windows.Forms.TextBox txtMarcaCategoria;
        private System.Windows.Forms.Button btnMarcaCategoria;
    }
}