namespace KP_Figures
{
    partial class SaveAsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveAsForm));
            this.buttonShps = new System.Windows.Forms.Button();
            this.buttonExportImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonShps
            // 
            this.buttonShps.Image = ((System.Drawing.Image)(resources.GetObject("buttonShps.Image")));
            this.buttonShps.Location = new System.Drawing.Point(12, 26);
            this.buttonShps.Name = "buttonShps";
            this.buttonShps.Size = new System.Drawing.Size(200, 200);
            this.buttonShps.TabIndex = 0;
            this.buttonShps.UseVisualStyleBackColor = true;
            this.buttonShps.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonExportImage
            // 
            this.buttonExportImage.Image = ((System.Drawing.Image)(resources.GetObject("buttonExportImage.Image")));
            this.buttonExportImage.Location = new System.Drawing.Point(220, 26);
            this.buttonExportImage.Name = "buttonExportImage";
            this.buttonExportImage.Size = new System.Drawing.Size(200, 200);
            this.buttonExportImage.TabIndex = 1;
            this.buttonExportImage.UseVisualStyleBackColor = true;
            this.buttonExportImage.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Save as shapes file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Export as an image";
            // 
            // SaveAsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 238);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExportImage);
            this.Controls.Add(this.buttonShps);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveAsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShps;
        private System.Windows.Forms.Button buttonExportImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}