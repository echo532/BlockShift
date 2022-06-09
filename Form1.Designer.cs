namespace BlockShift {
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
            this.pb_canvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.winButton = new System.Windows.Forms.Label();
            this.solve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_canvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_canvas
            // 
            this.pb_canvas.BackColor = System.Drawing.Color.White;
            this.pb_canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_canvas.Location = new System.Drawing.Point(130, 40);
            this.pb_canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_canvas.Name = "pb_canvas";
            this.pb_canvas.Size = new System.Drawing.Size(322, 365);
            this.pb_canvas.TabIndex = 0;
            this.pb_canvas.TabStop = false;
            this.pb_canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_canvas_MouseDown);
            this.pb_canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_canvas_MouseMove);
            this.pb_canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_canvas_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(828, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.exitToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Arial", 10F);
            this.leftButton.Location = new System.Drawing.Point(527, 236);
            this.leftButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(69, 53);
            this.leftButton.TabIndex = 7;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // upButton
            // 
            this.upButton.Font = new System.Drawing.Font("Arial", 10F);
            this.upButton.Location = new System.Drawing.Point(624, 160);
            this.upButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(69, 53);
            this.upButton.TabIndex = 8;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Font = new System.Drawing.Font("Arial", 10F);
            this.rightButton.Location = new System.Drawing.Point(721, 236);
            this.rightButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(69, 53);
            this.rightButton.TabIndex = 9;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // downButton
            // 
            this.downButton.Font = new System.Drawing.Font("Arial", 10F);
            this.downButton.Location = new System.Drawing.Point(624, 328);
            this.downButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(69, 53);
            this.downButton.TabIndex = 10;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // winButton
            // 
            this.winButton.AutoSize = true;
            this.winButton.Font = new System.Drawing.Font("Arial", 40F);
            this.winButton.Location = new System.Drawing.Point(248, 160);
            this.winButton.Name = "winButton";
            this.winButton.Size = new System.Drawing.Size(348, 75);
            this.winButton.TabIndex = 11;
            this.winButton.Text = "You Win!!!";
            this.winButton.Visible = false;
            // 
            // solve
            // 
            this.solve.Font = new System.Drawing.Font("Arial", 10F);
            this.solve.Location = new System.Drawing.Point(487, 49);
            this.solve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.solve.Name = "solve";
            this.solve.Size = new System.Drawing.Size(69, 53);
            this.solve.TabIndex = 12;
            this.solve.Text = "Solve";
            this.solve.UseVisualStyleBackColor = true;
            this.solve.Click += new System.EventHandler(this.solve_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(828, 447);
            this.Controls.Add(this.solve);
            this.Controls.Add(this.winButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.pb_canvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drawing Application";
            ((System.ComponentModel.ISupportInitialize)(this.pb_canvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_canvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.TextBox winMessage;
        private System.Windows.Forms.Label winButton;

        public void winGame() {
            winButton.Visible = true;
        }

        private System.Windows.Forms.Button solve;
    }
}