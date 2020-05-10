namespace KP_Figures
{
    partial class Form1
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
            this.panelShapes = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSetWidth = new System.Windows.Forms.Button();
            this.textBoxLineWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFillColor = new System.Windows.Forms.Button();
            this.buttonLineColor = new System.Windows.Forms.Button();
            this.drawTriangle = new System.Windows.Forms.Button();
            this.drawEllipse = new System.Windows.Forms.Button();
            this.drawCircle = new System.Windows.Forms.Button();
            this.drawRectangle = new System.Windows.Forms.Button();
            this.drawSquare = new System.Windows.Forms.Button();
            this.selectColorDialog = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.selectShpaeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.SelectShapeInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Canvas = new System.Windows.Forms.Panel();
            this.panelShapes.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.Canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelShapes
            // 
            this.panelShapes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelShapes.Controls.Add(this.label4);
            this.panelShapes.Controls.Add(this.buttonSetWidth);
            this.panelShapes.Controls.Add(this.textBoxLineWidth);
            this.panelShapes.Controls.Add(this.label3);
            this.panelShapes.Controls.Add(this.label2);
            this.panelShapes.Controls.Add(this.label1);
            this.panelShapes.Controls.Add(this.buttonFillColor);
            this.panelShapes.Controls.Add(this.buttonLineColor);
            this.panelShapes.Controls.Add(this.drawTriangle);
            this.panelShapes.Controls.Add(this.drawEllipse);
            this.panelShapes.Controls.Add(this.drawCircle);
            this.panelShapes.Controls.Add(this.drawRectangle);
            this.panelShapes.Controls.Add(this.drawSquare);
            this.panelShapes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShapes.Location = new System.Drawing.Point(0, 24);
            this.panelShapes.Margin = new System.Windows.Forms.Padding(4);
            this.panelShapes.Name = "panelShapes";
            this.panelShapes.Size = new System.Drawing.Size(1167, 39);
            this.panelShapes.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1057, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 13;
            // 
            // buttonSetWidth
            // 
            this.buttonSetWidth.Location = new System.Drawing.Point(657, 9);
            this.buttonSetWidth.Name = "buttonSetWidth";
            this.buttonSetWidth.Size = new System.Drawing.Size(54, 23);
            this.buttonSetWidth.TabIndex = 12;
            this.buttonSetWidth.Text = "Set";
            this.buttonSetWidth.UseVisualStyleBackColor = true;
            this.buttonSetWidth.Click += new System.EventHandler(this.buttonSetWidth_Click);
            // 
            // textBoxLineWidth
            // 
            this.textBoxLineWidth.Location = new System.Drawing.Point(584, 9);
            this.textBoxLineWidth.Name = "textBoxLineWidth";
            this.textBoxLineWidth.Size = new System.Drawing.Size(67, 22);
            this.textBoxLineWidth.TabIndex = 11;
            this.textBoxLineWidth.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Line width:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fill color: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Line color: ";
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.BackColor = System.Drawing.Color.White;
            this.buttonFillColor.Location = new System.Drawing.Point(435, 5);
            this.buttonFillColor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(30, 30);
            this.buttonFillColor.TabIndex = 7;
            this.buttonFillColor.UseVisualStyleBackColor = false;
            this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.BackColor = System.Drawing.Color.Black;
            this.buttonLineColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLineColor.Location = new System.Drawing.Point(327, 5);
            this.buttonLineColor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(30, 30);
            this.buttonLineColor.TabIndex = 6;
            this.buttonLineColor.UseVisualStyleBackColor = false;
            this.buttonLineColor.Click += new System.EventHandler(this.buttonLineColor_Click);
            // 
            // drawTriangle
            // 
            this.drawTriangle.Location = new System.Drawing.Point(156, 5);
            this.drawTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.drawTriangle.Name = "drawTriangle";
            this.drawTriangle.Size = new System.Drawing.Size(30, 30);
            this.drawTriangle.TabIndex = 4;
            this.drawTriangle.UseVisualStyleBackColor = true;
            this.drawTriangle.Click += new System.EventHandler(this.drawTriangle_Click);
            this.drawTriangle.Paint += new System.Windows.Forms.PaintEventHandler(this.drawTriangle_Paint);
            // 
            // drawEllipse
            // 
            this.drawEllipse.Location = new System.Drawing.Point(118, 5);
            this.drawEllipse.Margin = new System.Windows.Forms.Padding(4);
            this.drawEllipse.Name = "drawEllipse";
            this.drawEllipse.Size = new System.Drawing.Size(30, 30);
            this.drawEllipse.TabIndex = 3;
            this.drawEllipse.UseVisualStyleBackColor = true;
            this.drawEllipse.Click += new System.EventHandler(this.drawEllipse_Click);
            this.drawEllipse.Paint += new System.Windows.Forms.PaintEventHandler(this.drawEllipse_Paint);
            // 
            // drawCircle
            // 
            this.drawCircle.Location = new System.Drawing.Point(80, 5);
            this.drawCircle.Margin = new System.Windows.Forms.Padding(4);
            this.drawCircle.Name = "drawCircle";
            this.drawCircle.Size = new System.Drawing.Size(30, 30);
            this.drawCircle.TabIndex = 2;
            this.drawCircle.UseVisualStyleBackColor = true;
            this.drawCircle.Click += new System.EventHandler(this.drawCircle_Click);
            this.drawCircle.Paint += new System.Windows.Forms.PaintEventHandler(this.drawCircle_Paint);
            // 
            // drawRectangle
            // 
            this.drawRectangle.Location = new System.Drawing.Point(42, 5);
            this.drawRectangle.Margin = new System.Windows.Forms.Padding(4);
            this.drawRectangle.Name = "drawRectangle";
            this.drawRectangle.Size = new System.Drawing.Size(30, 30);
            this.drawRectangle.TabIndex = 1;
            this.drawRectangle.UseVisualStyleBackColor = true;
            this.drawRectangle.Click += new System.EventHandler(this.drawRectangle_Click);
            this.drawRectangle.Paint += new System.Windows.Forms.PaintEventHandler(this.drawRectangle_Paint);
            // 
            // drawSquare
            // 
            this.drawSquare.AccessibleName = "";
            this.drawSquare.Location = new System.Drawing.Point(4, 5);
            this.drawSquare.Margin = new System.Windows.Forms.Padding(4);
            this.drawSquare.Name = "drawSquare";
            this.drawSquare.Size = new System.Drawing.Size(30, 30);
            this.drawSquare.TabIndex = 0;
            this.drawSquare.UseVisualStyleBackColor = true;
            this.drawSquare.Click += new System.EventHandler(this.drawSquare_Click);
            this.drawSquare.Paint += new System.Windows.Forms.PaintEventHandler(this.drawSquare_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectShpaeToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1167, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectShpaeToolStripMenuItem
            // 
            this.selectShpaeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleShapeToolStripMenuItem,
            this.multipleShapesToolStripMenuItem});
            this.selectShpaeToolStripMenuItem.Name = "selectShpaeToolStripMenuItem";
            this.selectShpaeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.selectShpaeToolStripMenuItem.Text = "Select";
            // 
            // singleShapeToolStripMenuItem
            // 
            this.singleShapeToolStripMenuItem.Name = "singleShapeToolStripMenuItem";
            this.singleShapeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.singleShapeToolStripMenuItem.Text = "Single shape";
            this.singleShapeToolStripMenuItem.Click += new System.EventHandler(this.singleShapeToolStripMenuItem_Click);
            // 
            // multipleShapesToolStripMenuItem
            // 
            this.multipleShapesToolStripMenuItem.Name = "multipleShapesToolStripMenuItem";
            this.multipleShapesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.multipleShapesToolStripMenuItem.Text = "Multiple shapes";
            this.multipleShapesToolStripMenuItem.Click += new System.EventHandler(this.multipleShapesToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectShapeInfo,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 514);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1167, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // SelectShapeInfo
            // 
            this.SelectShapeInfo.Name = "SelectShapeInfo";
            this.SelectShapeInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.Controls.Add(this.statusStrip);
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Canvas.Location = new System.Drawing.Point(0, 63);
            this.Canvas.Margin = new System.Windows.Forms.Padding(4);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1167, 536);
            this.Canvas.TabIndex = 1;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 599);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.panelShapes);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panelShapes.ResumeLayout(false);
            this.panelShapes.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.Canvas.ResumeLayout(false);
            this.Canvas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelShapes;
        private System.Windows.Forms.Button drawSquare;
        private System.Windows.Forms.Button drawTriangle;
        private System.Windows.Forms.Button drawEllipse;
        private System.Windows.Forms.Button drawCircle;
        private System.Windows.Forms.Button drawRectangle;
        private System.Windows.Forms.Button buttonFillColor;
        private System.Windows.Forms.Button buttonLineColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog selectColorDialog;
        private System.Windows.Forms.Button buttonSetWidth;
        private System.Windows.Forms.TextBox textBoxLineWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectShpaeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SelectShapeInfo;
        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

