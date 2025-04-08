
namespace Sistema_de_facturación
{
    partial class V3P
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
            this.CRVP = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CRV3P1 = new Sistema_de_facturación.CRV3P();
            this.numero = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CRVP
            // 
            this.CRVP.ActiveViewIndex = 0;
            this.CRVP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVP.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVP.Location = new System.Drawing.Point(0, 0);
            this.CRVP.Name = "CRVP";
            this.CRVP.ReportSource = this.CRV3P1;
            this.CRVP.Size = new System.Drawing.Size(800, 450);
            this.CRVP.TabIndex = 0;
            this.CRVP.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(352, 36);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(100, 22);
            this.numero.TabIndex = 1;
            // 
            // V3P
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.CRVP);
            this.Name = "V3P";
            this.Text = "V3P";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVP;
        private CRV3P CRV3P1;
        public System.Windows.Forms.TextBox numero;
    }
}