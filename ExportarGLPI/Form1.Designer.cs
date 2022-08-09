namespace ExportarGLPI
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnCrm = new System.Windows.Forms.Button();
            this.btnResolverXml = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Obter GLPI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCrm
            // 
            this.btnCrm.Location = new System.Drawing.Point(67, 68);
            this.btnCrm.Name = "btnCrm";
            this.btnCrm.Size = new System.Drawing.Size(107, 33);
            this.btnCrm.TabIndex = 1;
            this.btnCrm.Text = "Dados CRM";
            this.btnCrm.UseVisualStyleBackColor = true;
            this.btnCrm.Click += new System.EventHandler(this.btnCrm_Click);
            // 
            // btnResolverXml
            // 
            this.btnResolverXml.Location = new System.Drawing.Point(67, 119);
            this.btnResolverXml.Name = "btnResolverXml";
            this.btnResolverXml.Size = new System.Drawing.Size(107, 33);
            this.btnResolverXml.TabIndex = 2;
            this.btnResolverXml.Text = "Resolver XML";
            this.btnResolverXml.UseVisualStyleBackColor = true;
            this.btnResolverXml.Click += new System.EventHandler(this.btnResolverXml_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 164);
            this.Controls.Add(this.btnResolverXml);
            this.Controls.Add(this.btnCrm);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCrm;
        private System.Windows.Forms.Button btnResolverXml;
    }
}

