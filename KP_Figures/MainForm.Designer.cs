﻿namespace KP_Figures
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelShapes = new System.Windows.Forms.Panel();
            this.buttonPencil = new System.Windows.Forms.Button();
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
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panelShapes.Controls.Add(this.buttonPencil);
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
            this.panelShapes.Size = new System.Drawing.Size(684, 28);
            this.panelShapes.TabIndex = 0;
            // 
            // buttonPencil
            // 
            this.buttonPencil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPencil.Image = ((System.Drawing.Image)(resources.GetObject("buttonPencil.Image")));
            this.buttonPencil.Location = new System.Drawing.Point(144, 4);
            this.buttonPencil.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPencil.Name = "buttonPencil";
            this.buttonPencil.Size = new System.Drawing.Size(20, 20);
            this.buttonPencil.TabIndex = 14;
            this.buttonPencil.UseVisualStyleBackColor = true;
            this.buttonPencil.Click += new System.EventHandler(this.ButtonPencil_Click);
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
            this.buttonSetWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetWidth.Location = new System.Drawing.Point(631, 4);
            this.buttonSetWidth.Name = "buttonSetWidth";
            this.buttonSetWidth.Size = new System.Drawing.Size(50, 20);
            this.buttonSetWidth.TabIndex = 12;
            this.buttonSetWidth.Text = "Set";
            this.buttonSetWidth.UseVisualStyleBackColor = true;
            this.buttonSetWidth.Click += new System.EventHandler(this.buttonSetWidth_Click);
            // 
            // textBoxLineWidth
            // 
            this.textBoxLineWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLineWidth.Location = new System.Drawing.Point(584, 4);
            this.textBoxLineWidth.Name = "textBoxLineWidth";
            this.textBoxLineWidth.Size = new System.Drawing.Size(41, 20);
            this.textBoxLineWidth.TabIndex = 11;
            this.textBoxLineWidth.Text = "1";
            this.textBoxLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Line width:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fill color: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Line color: ";
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.BackColor = System.Drawing.Color.White;
            this.buttonFillColor.Location = new System.Drawing.Point(402, 4);
            this.buttonFillColor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(20, 20);
            this.buttonFillColor.TabIndex = 7;
            this.buttonFillColor.UseVisualStyleBackColor = false;
            this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.BackColor = System.Drawing.Color.Black;
            this.buttonLineColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLineColor.Location = new System.Drawing.Point(304, 4);
            this.buttonLineColor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(20, 20);
            this.buttonLineColor.TabIndex = 6;
            this.buttonLineColor.UseVisualStyleBackColor = false;
            this.buttonLineColor.Click += new System.EventHandler(this.buttonLineColor_Click);
            // 
            // drawTriangle
            // 
            this.drawTriangle.Image = ((System.Drawing.Image)(resources.GetObject("drawTriangle.Image")));
            this.drawTriangle.Location = new System.Drawing.Point(116, 4);
            this.drawTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.drawTriangle.Name = "drawTriangle";
            this.drawTriangle.Size = new System.Drawing.Size(20, 20);
            this.drawTriangle.TabIndex = 4;
            this.drawTriangle.UseVisualStyleBackColor = true;
            this.drawTriangle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawTriangle_MouseDown);
            // 
            // drawEllipse
            // 
            this.drawEllipse.Image = ((System.Drawing.Image)(resources.GetObject("drawEllipse.Image")));
            this.drawEllipse.Location = new System.Drawing.Point(88, 4);
            this.drawEllipse.Margin = new System.Windows.Forms.Padding(4);
            this.drawEllipse.Name = "drawEllipse";
            this.drawEllipse.Size = new System.Drawing.Size(20, 20);
            this.drawEllipse.TabIndex = 3;
            this.drawEllipse.UseVisualStyleBackColor = true;
            this.drawEllipse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawEllipse_MouseDown);
            // 
            // drawCircle
            // 
            this.drawCircle.Image = ((System.Drawing.Image)(resources.GetObject("drawCircle.Image")));
            this.drawCircle.Location = new System.Drawing.Point(60, 4);
            this.drawCircle.Margin = new System.Windows.Forms.Padding(4);
            this.drawCircle.Name = "drawCircle";
            this.drawCircle.Size = new System.Drawing.Size(20, 20);
            this.drawCircle.TabIndex = 2;
            this.drawCircle.UseVisualStyleBackColor = true;
            this.drawCircle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawCircle_MouseDown);
            // 
            // drawRectangle
            // 
            this.drawRectangle.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangle.Image")));
            this.drawRectangle.Location = new System.Drawing.Point(32, 4);
            this.drawRectangle.Margin = new System.Windows.Forms.Padding(4);
            this.drawRectangle.Name = "drawRectangle";
            this.drawRectangle.Size = new System.Drawing.Size(20, 20);
            this.drawRectangle.TabIndex = 1;
            this.drawRectangle.UseVisualStyleBackColor = true;
            this.drawRectangle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawRectangle_MouseDown);
            // 
            // drawSquare
            // 
            this.drawSquare.AccessibleName = "";
            this.drawSquare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.drawSquare.Image = ((System.Drawing.Image)(resources.GetObject("drawSquare.Image")));
            this.drawSquare.Location = new System.Drawing.Point(4, 4);
            this.drawSquare.Margin = new System.Windows.Forms.Padding(4);
            this.drawSquare.Name = "drawSquare";
            this.drawSquare.Size = new System.Drawing.Size(20, 20);
            this.drawSquare.TabIndex = 0;
            this.drawSquare.UseVisualStyleBackColor = true;
            this.drawSquare.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawSquare_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectShpaeToolStripMenuItem,
            this.editToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectShpaeToolStripMenuItem
            // 
            this.selectShpaeToolStripMenuItem.Name = "selectShpaeToolStripMenuItem";
            this.selectShpaeToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.selectShpaeToolStripMenuItem.Text = "Select/Move";
            this.selectShpaeToolStripMenuItem.Click += new System.EventHandler(this.SelectShapeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 387);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(684, 22);
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
            this.Canvas.Location = new System.Drawing.Point(0, 52);
            this.Canvas.Margin = new System.Windows.Forms.Padding(4);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(684, 409);
            this.Canvas.TabIndex = 1;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.panelShapes);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shapes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SelectShapeInfo;
        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button buttonPencil;
    }
}

